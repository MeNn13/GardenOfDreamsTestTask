using System;
using Code.ScriptableObjects;
using Code.Scripts.InventorySystem;
using Code.Scripts.PopupSystem.Buttons;
using UnityEngine;
using Zenject;

namespace Code.Scripts.Unit
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private float maxHealth = 100;
        [SerializeField] private HealthBar healthBar;

        [SerializeField] private GameObject headSlot;
        [SerializeField] private GameObject torsoSlot;
        [SerializeField] private GameObject gameOverPanel;

        private float _health;

        [Inject] private GameInfo _gameInfo;

        private void OnEnable()
        {
            HealButton.OnHeal += Heal;
        }

        private void OnDisable()
        {
            HealButton.OnHeal -= Heal;
        }

        private void Start()
        {
            _health = _gameInfo.characterHealth;
            healthBar.UpdateHealthBar(maxHealth, _health);
        }

        public void TakeDamage(float damage, ClothesType type)
        {
            float recalculationDamage = damage;

            recalculationDamage = TryRecalculationDamage(type, recalculationDamage);

            if (_health <= recalculationDamage)
            {
                gameOverPanel.SetActive(true);
            }

            _health -= recalculationDamage;
            healthBar.UpdateHealthBar(maxHealth, _health);
            _gameInfo.characterHealth = _health;
        }
        
        private float TryRecalculationDamage(ClothesType type, float recalculationDamage)
        {
            if (type == ClothesType.Head && headSlot.transform.childCount > 0)
            {
                ClothesData clothesData = headSlot.GetComponentInChildren<InventoryItem>().itemForData.itemData as ClothesData;
                recalculationDamage -= clothesData.Defense;
            }
            else if (type == ClothesType.Torso && torsoSlot.transform.childCount > 0)
            {
                ClothesData clothesData = headSlot.GetComponentInChildren<InventoryItem>().itemForData.itemData as ClothesData;
                recalculationDamage -= clothesData.Defense;
            }
            return recalculationDamage;
        }

        private void Heal(float healPoint)
        {
            _health += healPoint;
            healthBar.UpdateHealthBar(maxHealth, _health);
        }
    }
}

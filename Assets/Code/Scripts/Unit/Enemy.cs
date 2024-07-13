using System;
using System.Collections;
using Code.ScriptableObjects;
using Code.Scripts.Weapon;
using UnityEngine;
using Zenject;

namespace Code.Scripts.Unit
{
    public class Enemy : MonoBehaviour
    {
        public static event Action OnEnemyShoot;

        [SerializeField] private float maxHealth = 100;
        [SerializeField] private HealthBar healthBar;
        [SerializeField] private float enemyDamage = 15f;

        [SerializeField] private Character character;

        private Gift _gift;
        private GameInfo _gameInfo;
        private float _health;
        private ClothesType _previousShoot = ClothesType.Torso;

        [Inject]
        private void Construct(Gift gift, GameInfo gameInfo)
        {
            _gift = gift;
            _gameInfo = gameInfo;
        }
        
        private void OnEnable()
        {
            ShootButton.OnShoot += StartShooting;
        }

        private void OnDisable()
        {
            ShootButton.OnShoot -= StartShooting;
        }

        private void Start()
        {
            _health = maxHealth;
        }

        public void TakeDamage(float damage)
        {
            if (_health <= damage)
            {
                _gift.SendGift();
                _health = maxHealth;
                SaveSystem.Save(_gameInfo);
            }

            _health -= damage;
            healthBar.UpdateHealthBar(maxHealth, _health);
        }

        private void StartShooting()
        {
            StartCoroutine(Shoot());
        }
        
        private IEnumerator Shoot()
        {
            yield return new WaitForSeconds(.7f);
            
            if (_previousShoot == ClothesType.Torso)
            {
                character.TakeDamage(enemyDamage, ClothesType.Head);
                _previousShoot = ClothesType.Head;
            }
            else
            {
                character.TakeDamage(enemyDamage, ClothesType.Torso);
                _previousShoot = ClothesType.Torso;
            }

            OnEnemyShoot?.Invoke();
        }
    }
}

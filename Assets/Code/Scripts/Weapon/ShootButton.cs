using System;
using Code.ScriptableObjects;
using Code.Scripts.InventorySystem;
using Code.Scripts.Unit;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Scripts.Weapon
{
    [RequireComponent(typeof(Button))]
    public class ShootButton : MonoBehaviour
    {
        public static event Action OnShoot;
        
        [SerializeField] private Enemy enemy;

        [Inject] private readonly InventoryManager _inventoryManager;
        
        private Button _shootButton;
        private WeaponData _selectedWeapon;

        private void Awake()
        {
            _shootButton = GetComponent<Button>();
        }

        private void Start()
        {
            _shootButton.interactable = false;
        }

        private void OnEnable()
        {
            _shootButton.onClick.AddListener(Shoot);
            SelectWeapon.OnChangeWeapon += SelectedWeapon;
            Enemy.OnEnemyShoot += ActiveButton;
        }

        private void OnDisable()
        {
            _shootButton.onClick.RemoveListener(Shoot);        
            SelectWeapon.OnChangeWeapon -= SelectedWeapon;
            Enemy.OnEnemyShoot -= ActiveButton;
        }

        private void Shoot()
        {
            enemy.TakeDamage(_selectedWeapon.Damage);
            _shootButton.interactable = false;
            _inventoryManager.TakeAmmoCount(_selectedWeapon);
            OnShoot?.Invoke();
        }

        private void SelectedWeapon(WeaponData weaponData)
        {
            _selectedWeapon = weaponData;
            _shootButton.interactable = true;
        }

        private void ActiveButton()
        {
            _shootButton.interactable = true;
        }
    }
}

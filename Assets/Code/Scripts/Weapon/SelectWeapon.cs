using System;
using Code.ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Scripts.Weapon
{
    public class SelectWeapon : MonoBehaviour
    {
        public static event Action<WeaponData> OnChangeWeapon;
        
        [SerializeField] private Button pistolButton;
        [SerializeField] private Button automaticButton;
        [SerializeField] private WeaponData pistolData;
        [SerializeField] private WeaponData automaticData;

        private void OnEnable()
        {
            pistolButton.onClick.AddListener(SelectPistol);
            automaticButton.onClick.AddListener(SelectAutomatic);
        }

        private void OnDisable()
        {
            pistolButton.onClick.RemoveListener(SelectPistol);
            automaticButton.onClick.RemoveListener(SelectAutomatic);
        }

        private void SelectPistol()
        {
            pistolButton.interactable = false;
            automaticButton.interactable = true;
            OnChangeWeapon?.Invoke(pistolData);
        }

        private void SelectAutomatic()
        {
            pistolButton.interactable = true;
            automaticButton.interactable = false;
            OnChangeWeapon?.Invoke(automaticData);
        }
    }
}

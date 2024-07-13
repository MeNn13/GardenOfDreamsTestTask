using System;
using Code.Scripts.InventorySystem;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Scripts.PopupSystem.Buttons
{
    public class UseButton : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private Popup parentPopup;

        [NonSerialized] public InventoryItem Item;

        private void OnEnable()
        {
            button.onClick.AddListener(Click);
        }

        private void OnDisable()
        {
            button.onClick.RemoveListener(Click);
        }

        protected virtual void Click()
        {
            parentPopup.gameObject.SetActive(false);
        }
    }
}

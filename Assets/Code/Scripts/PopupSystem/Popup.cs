using Code.Scripts.InventorySystem;
using Code.Scripts.PopupSystem.Buttons;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Scripts.PopupSystem
{
    public class Popup : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private TextMeshProUGUI weightText;
        [SerializeField] private Image image;
        [SerializeField] private UseButton useButton;
        [SerializeField] private Button deleteButton;

        private InventoryItem _item;
        [Inject] private InventoryManager _inventoryManager;
        
        private void OnEnable()
        {
            deleteButton.onClick.AddListener(DeleteItem);
        }

        private void OnDisable()
        {
            deleteButton.onClick.RemoveListener(DeleteItem);
        }

        private void DeleteItem()
        {
            _inventoryManager.ItemDestroy(_item);
            Destroy(_item.gameObject);
            gameObject.SetActive(false);
        }

        public void SetName(string nameText) => this.nameText.text = nameText;

        public void SetWeight(float weight) => weightText.text = weight.ToString();

        public void SetIcon(Sprite icon) => image.sprite = icon;

        public void SetInventoryItem(InventoryItem item)
        {
            useButton.Item = item;
            _item = item;
        }
    }
}

using Code.ScriptableObjects;
using Code.Scripts.InventorySystem;
using UnityEngine;

namespace Code.Scripts.PopupSystem
{
    public class PopupManager : MonoBehaviour
    {
        [SerializeField] private Popup ammoPopup;
        [SerializeField] private PopupDefense clothesPopup;
        [SerializeField] private Popup kitPopup;

        private void OnEnable()
        {
            InventoryItem.OnItemClick += InventoryItemOnClick;
        }

        private void OnDisable()
        {
            InventoryItem.OnItemClick -= InventoryItemOnClick;
        }

        private void InventoryItemOnClick(InventoryItem inventoryItem)
        {
            ItemData item = inventoryItem.itemForData.itemData;

            if (item is ClothesData clothesData)
            {
                clothesPopup.gameObject.SetActive(true);
                clothesPopup.SetName(clothesData.Name);
                clothesPopup.SetIcon(clothesData.Icon);
                clothesPopup.SetWeight(clothesData.Weight);
                clothesPopup.SetDefense(clothesData.Defense);
                clothesPopup.SetInventoryItem(inventoryItem);
            }
            else if (item is AmmoData)
            {
                ammoPopup.gameObject.SetActive(true);
                ammoPopup.SetName(item.Name);
                ammoPopup.SetIcon(item.Icon);
                ammoPopup.SetWeight(item.Weight);
                ammoPopup.SetInventoryItem(inventoryItem);
            }
            else
            {
                kitPopup.gameObject.SetActive(true);
                kitPopup.SetName(item.Name);
                kitPopup.SetIcon(item.Icon);
                kitPopup.SetWeight(item.Weight);
                kitPopup.SetInventoryItem(inventoryItem);
            }
        }
    }
}

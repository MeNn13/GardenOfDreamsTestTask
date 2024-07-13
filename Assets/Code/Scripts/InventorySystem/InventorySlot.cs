using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Code.Scripts.InventorySystem
{
    public class InventorySlot : MonoBehaviour, IDropHandler
    {
        private void Start()
        {
            if (transform.childCount > 0)
            {
                InventoryItem inventoryItem = GetComponentInChildren<InventoryItem>();
                inventoryItem.itemForData.parent = transform;
            }
        }

        public void OnDrop(PointerEventData eventData)
        {
            if (transform.childCount > 0)
                return;

            InventoryItem inventoryItem = eventData.pointerDrag.GetComponent<InventoryItem>();
            inventoryItem.itemForData.parent = transform;
        }
    }
}

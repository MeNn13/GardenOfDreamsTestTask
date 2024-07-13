using System;
using Code.ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Code.Scripts.InventorySystem
{
    [RequireComponent(typeof(Image))]
    public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
    {
        public static event Action<InventoryItem> OnItemClick;

        [SerializeField] private TextMeshProUGUI countText;

        public ItemForData itemForData = new();
        private Image _image;

        private void Awake()
        {
            _image = GetComponent<Image>();
        }

        public void Init(ItemData item, int count)
        {
            itemForData.itemData = item;
            _image.SetNativeSize();
            _image.sprite = itemForData.itemData.Icon;
            itemForData.count = count;
            RefreshCount();
        }
        
        public void RefreshCount()
        {
            if (itemForData.count == 0)
                Destroy(gameObject);

            countText.text = itemForData.count.ToString();
            bool textActive = itemForData.count > 1;
            countText.gameObject.SetActive(textActive);
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            _image.raycastTarget = false;
            itemForData.parent = transform.parent;
            transform.SetParent(transform.root);
        }

        public void OnDrag(PointerEventData eventData)
        {
            transform.position = Input.mousePosition;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            _image.raycastTarget = true;
            transform.SetParent(itemForData.parent);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            OnItemClick?.Invoke(this);
        }
    }

    [Serializable]
    public class ItemForData
    {
        public int count = 1;
        public ItemData itemData;
        public Transform parent;
    }
}

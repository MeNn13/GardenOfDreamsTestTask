using System.Linq;
using Code.ScriptableObjects;
using TMPro;
using UnityEngine;
using Zenject;

namespace Code.Scripts.InventorySystem
{
    public class InventoryManager : MonoBehaviour
    {
        [SerializeField] private InventorySlot[] slots;
        [SerializeField] private GameObject headSlot;
        [SerializeField] private GameObject torsoSlot;
        [SerializeField] private TextMeshProUGUI headText;
        [SerializeField] private TextMeshProUGUI torsoText;

        private InventoryItem _prefab;
        private ItemData[] _defaultItems;
        private GameInfo _gameInfo;

        [Inject]
        private void Construct(ItemData[] itemData, GameInfo gameInfo, InventoryItem prefab)
        {
            _defaultItems = itemData;
            _gameInfo = gameInfo;
            _prefab = prefab;
        }

        private void Start()
        {
            TrySetDataClothes(_gameInfo.headSlot, headSlot.transform, headText);
            TrySetDataClothes(_gameInfo.torsoSlot, torsoSlot.transform, torsoText);

            if (_gameInfo.items.Count > 0)
            {
                foreach (ItemForData gameInfoItem in _gameInfo.items)
                    TrySpawnDataItem(gameInfoItem);

                return;
            }

            foreach (var item in _defaultItems)
                AddItem(item);
        }

        private void TrySetDataClothes(ClothesData clothesData, Transform to, TextMeshProUGUI text)
        {
            if (clothesData != null)
            {
                InventoryItem item = Instantiate(_prefab, transform);
                item.transform.SetParent(to.transform);
                item.itemForData.parent = to.transform;
                item.Init(clothesData, clothesData.MAXStack);
                text.text = clothesData.Defense.ToString();
            }
        }

        public void AddItem(ItemData newItem)
        {
            foreach (InventorySlot slot in slots)
            {
                InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
                if (itemInSlot == null)
                {
                    SpawnNewItem(newItem, slot);
                    return;
                }
            }
        }

        private void TrySpawnDataItem(ItemForData itemForData)
        {
            InventoryItem inventoryItem = CreateInventoryItem();

            inventoryItem.itemForData = itemForData;
            inventoryItem.transform.SetParent(itemForData.parent);
            inventoryItem.Init(itemForData.itemData, itemForData.count);
        }

        private void SpawnNewItem(ItemData newItem, InventorySlot slot)
        {
            InventoryItem inventoryItem = CreateInventoryItem(slot);
            inventoryItem.itemForData.parent = slot.transform;
            inventoryItem.itemForData.itemData = newItem;

            inventoryItem.Init(newItem, newItem.MAXStack);
            _gameInfo.items.Add(inventoryItem.itemForData);
        }

        private InventoryItem CreateInventoryItem(InventorySlot slot)
        {
            GameObject newItemObj = Instantiate(_prefab.gameObject, slot.transform);
            InventoryItem inventoryItem = newItemObj.GetComponent<InventoryItem>();
            return inventoryItem;
        }
        private InventoryItem CreateInventoryItem()
        {
            GameObject newItemObj = Instantiate(_prefab.gameObject);
            InventoryItem inventoryItem = newItemObj.GetComponent<InventoryItem>();
            return inventoryItem;
        }

        public void TakeAmmoCount(WeaponData weaponData)
        {
            foreach (InventorySlot slot in slots)
            {
                if (slot.transform.childCount > 0)
                {
                    InventoryItem item = slot.GetComponentInChildren<InventoryItem>();
                    if (item.itemForData.itemData is AmmoData ammoData && ammoData.WeaponPatron == weaponData)
                    {
                        item.itemForData.count -= weaponData.CountShoot;
                        item.RefreshCount();
                        return;
                    }
                }
            }
        }

        public void ItemDestroy(InventoryItem inventoryItem)
        {
            ItemForData itemForData = _gameInfo.items.FirstOrDefault(i => i == inventoryItem.itemForData);
            _gameInfo.items.Remove(itemForData);
        }
    }
}

using Code.ScriptableObjects;
using Code.Scripts.InventorySystem;
using Zenject;

namespace Code.Scripts
{
    public class Gift
    {
        private readonly ItemData[] _defaultItems;
        private readonly InventoryManager _inventoryManager;
        
        public Gift(ItemData[] itemData, InventoryManager inventoryManager)
        {
            _defaultItems = itemData;
            _inventoryManager = inventoryManager;
        }

        public void SendGift()
        {
            int index = UnityEngine.Random.Range(0, _defaultItems.Length);

            _inventoryManager.AddItem(_defaultItems[index]);
        }
    }
}

using Code.ScriptableObjects;
using Code.Scripts.InventorySystem;
using TMPro;
using UnityEngine;
using Zenject;

namespace Code.Scripts.PopupSystem.Buttons
{
    public class EquipButton : UseButton
    {
        [SerializeField] private GameObject headSlot;
        [SerializeField] private GameObject torsoSlot;
        [SerializeField] private TextMeshProUGUI headText;
        [SerializeField] private TextMeshProUGUI torsoText;
        
        private GameInfo _gameInfo;

        [Inject]
        private void Construct(GameInfo gameInfo, InventoryItem prefab)
        {
            _gameInfo = gameInfo;
        }

        protected override void Click()
        {
            if (Item.itemForData.itemData is ClothesData clothesData)
            {
                if (clothesData.Type == ClothesType.Head)
                {
                    InventoryItem itemChild = headSlot.GetComponentInChildren<InventoryItem>();
                    if (itemChild != null)
                        itemChild.transform.SetParent(Item.itemForData.parent);
                        
                    Item.transform.SetParent(headSlot.transform);
                    headText.text = clothesData.Defense.ToString();
                    _gameInfo.headSlot = clothesData;
                }
                else
                {
                    InventoryItem item = torsoSlot.GetComponentInChildren<InventoryItem>();
                    if (item != null)
                        item.transform.SetParent(Item.itemForData.parent);
                    
                    Item.transform.SetParent(torsoSlot.transform);
                    torsoText.text = clothesData.Defense.ToString();
                    _gameInfo.torsoSlot = clothesData;
                }
            }

            _gameInfo.items.Remove(Item.itemForData);
            
            base.Click();
        }
    }
}

using System;
using Code.ScriptableObjects;

namespace Code.Scripts.PopupSystem.Buttons
{
    public class HealButton : UseButton
    {
        public static event Action<float> OnHeal; 
        
        protected override void Click()
        {
            if (Item.itemForData.itemData is KitData kitData)
            {
                Item.itemForData.count--;
                Item.RefreshCount();
                OnHeal?.Invoke(kitData.HealPoint);
            }
            
            base.Click();
        }
    }
}

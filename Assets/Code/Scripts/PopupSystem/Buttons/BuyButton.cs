using Code.ScriptableObjects;

namespace Code.Scripts.PopupSystem.Buttons
{
    public class BuyButton : UseButton
    {
        protected override void Click()
        {
            if (Item.itemForData.itemData is AmmoData ammoData)
            {
                Item.itemForData.count = ammoData.MAXStack;
                Item.RefreshCount();
            }
            
            base.Click();
        }
    }
}

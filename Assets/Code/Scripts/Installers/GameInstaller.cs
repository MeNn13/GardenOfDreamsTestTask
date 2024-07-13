using Code.ScriptableObjects;
using Code.Scripts.InventorySystem;
using UnityEngine;
using Zenject;

namespace Code.Scripts.Installers
{
    public class InventoryInstaller : MonoInstaller
    {
        [SerializeField] private ItemData[] defaultItems;
        [SerializeField] private InventoryManager inventoryManager;
        [SerializeField] private InventoryItem itemPrefab;

        public override void InstallBindings()
        {
            Gift gift = new(defaultItems, inventoryManager);
            GameInfo gameInfo = SaveSystem.Load();

            Container.Bind<InventoryItem>().FromInstance(itemPrefab);
            Container.Bind<ItemData[]>().FromInstance(defaultItems);
            Container.Bind<InventoryManager>().FromInstance(inventoryManager);
            Container.Bind<Gift>().FromInstance(gift);
            Container.Bind<GameInfo>().FromInstance(gameInfo);
        }
    }
}

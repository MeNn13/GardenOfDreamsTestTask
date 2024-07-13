using System;
using System.Collections.Generic;
using System.IO;
using Code.ScriptableObjects;
using Code.Scripts.InventorySystem;
using UnityEngine;

namespace Code.Scripts
{
    public static class SaveSystem
    {
        private static readonly string Path = Application.streamingAssetsPath + "/jsonGameInfo.json";

        public static void Save(GameInfo gameInfo)
        {
            File.WriteAllText(
                Path,
                JsonUtility.ToJson(gameInfo));
            
            Debug.Log(JsonUtility.ToJson(gameInfo));
        }
        
        public static GameInfo Load()
        {
            GameInfo gameInfo = JsonUtility.FromJson<GameInfo>(File.ReadAllText(Path));
            
            return gameInfo ?? new GameInfo();
        }
    }

    [Serializable]
    public class GameInfo
    {
        public List<ItemForData> items = new();
        public ClothesData headSlot;
        public ClothesData torsoSlot;
        public float characterHealth = 100;
    }
}

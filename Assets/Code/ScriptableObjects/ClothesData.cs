using UnityEngine;

namespace Code.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Clothes", menuName = "ScriptableObject/Item/Clothes", order = 0)]
    public class ClothesData : ItemData
    {
        [SerializeField] private float defense;
        [SerializeField] private ClothesType type;

        public float Defense => defense;
        public ClothesType Type => type;
    }

    public enum ClothesType
    {
        Head,
        Torso
    }
}

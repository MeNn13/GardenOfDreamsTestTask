using UnityEngine;

namespace Code.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Item Data", menuName = "ScriptableObject/Item", order = 0)]
    public class ItemData : ScriptableObject
    {
        [SerializeField] private Sprite icon;
        [SerializeField] private new string name;
        [SerializeField] private float weight;
        [SerializeField] private int maxStack;
        
        public int MAXStack => maxStack;
        public Sprite Icon => icon;
        public string Name => name;
        public float Weight => weight;
    }
}

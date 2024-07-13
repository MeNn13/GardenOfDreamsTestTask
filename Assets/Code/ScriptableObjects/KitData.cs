using UnityEngine;

namespace Code.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Kit", menuName = "ScriptableObject/Item/Kit", order = 0)]
    public class KitData : ItemData
    {
        [SerializeField] private float healPoint;
        public float HealPoint => healPoint;
    }
}

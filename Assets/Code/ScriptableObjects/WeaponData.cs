using UnityEngine;

namespace Code.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Weapon", menuName = "ScriptableObject/Weapon", order = 0)]
    public class WeaponData : ScriptableObject
    {
        [SerializeField] private float damage;
        [SerializeField] private int countShoot;
        
        public float Damage => damage;
        public int CountShoot => countShoot;
    }
}

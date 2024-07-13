using UnityEngine;

namespace Code.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Ammo", menuName = "ScriptableObject/Item/Ammo", order = 0)]
    public class AmmoData : ItemData
    {
        [SerializeField] private WeaponData weaponPatron;
        public WeaponData WeaponPatron => weaponPatron;
    }
}

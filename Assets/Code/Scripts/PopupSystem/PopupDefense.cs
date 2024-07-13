using TMPro;
using UnityEngine;

namespace Code.Scripts.PopupSystem
{
    public class PopupDefense : Popup
    {
        [SerializeField] private TextMeshProUGUI defenseText;

        public void SetDefense(float defense) => defenseText.text = defense.ToString();
    }
}

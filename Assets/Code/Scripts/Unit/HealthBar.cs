using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Scripts.Unit
{
    [RequireComponent(typeof(Slider))]
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI countHealthText;
        private Slider _healthBar;

        private void Awake()
        {
            _healthBar = GetComponent<Slider>();
        }

        public void UpdateHealthBar(float maxHealth, float health)
        {
            _healthBar.value = health / maxHealth;

            countHealthText.text = health.ToString();
        }
    }
}

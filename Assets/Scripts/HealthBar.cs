using UnityEngine;
using UnityEngine.UI;

namespace Nicolas
{
    public class HealthBar : MonoBehaviour
    {

        [SerializeField] private Slider slider;
        public void SetMaxHealth(int health)
        {
            slider.maxValue = health;
            slider.value = health;
        }

        public void SetHealth(int health)
        {
            slider.value = health;
        }
    }
}

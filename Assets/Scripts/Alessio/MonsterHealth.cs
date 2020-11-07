using UnityEngine;
using UnityEngine.Events;

namespace Alessio
{
    public class MonsterHealth : MonoBehaviour, IDamageable
    {
        [SerializeField] private int currentHealth;
        [SerializeField] private int maxHealth;
        [SerializeField] private UnityEvent onDeath;
        // Start is called before the first frame update
        public void TakeDamage(int damage)
        {
            currentHealth -= damage;
            if (currentHealth <= 0)
                onDeath?.Invoke();
        }
    }
}

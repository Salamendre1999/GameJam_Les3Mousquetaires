using UnityEngine;
using UnityEngine.Events;

namespace Alessio
{
    public class Health : MonoBehaviour
    {
        [SerializeField] protected int currentHealth;
        [SerializeField] protected int maxHealth;
        [SerializeField] protected UnityEvent onDeath;
    }
}

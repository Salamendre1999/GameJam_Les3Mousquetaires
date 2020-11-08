using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Alessio
{
    public abstract class CharacterManagement : MonoBehaviour
    {
        [SerializeField] protected int currentHealth;
        [SerializeField] protected int maxHealth;
        [SerializeField] protected UnityEvent onDeath;
        [SerializeField] protected float knockBackResistance;
        [SerializeField] protected float knockBackDuration;
        [SerializeField] protected int knockBackForce = 100;
        [SerializeField] protected Rigidbody2D rigidbody2D;

        public int CurrentHealth { get; set; }
        public int MaxHealth { get; set; }

        private void Awake()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
        }
        
        public IEnumerator CancelKnockBack()
        {
            yield return new WaitForSeconds(knockBackDuration);
            // A montrer au prof !
            rigidbody2D.velocity = Vector2.zero;
        }
        
    }
}

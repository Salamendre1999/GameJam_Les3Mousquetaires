using UnityEngine;

namespace Alessio
{
    public class MonsterHealth : Health, IDamageable
    {
        [SerializeField] private Animator animator;
        [SerializeField] private BoxCollider2D collider;
        public void TakeDamage(int damage)
        {
            currentHealth -= damage;
            if (currentHealth <= 0)
            {
                collider.enabled=false;
                animator.Play("DeathAnimation");
                Invoke("deathInvoke",.5f);
            }
        }
        
        public void deathInvoke()
        {
            onDeath?.Invoke();
        }
    }
}

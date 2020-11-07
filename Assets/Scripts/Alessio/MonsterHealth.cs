using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Alessio
{
    public class MonsterHealth : MonoBehaviour, IDamageable
    {
        [SerializeField] private int currentHealth;
        [SerializeField] private int maxHealth;
        [SerializeField] private UnityEvent onDeath;
        [SerializeField] private float knockBackResistance;
        [SerializeField] private float knockBackDuration;
        [SerializeField] private int knockBackForce = 100;
        private Rigidbody2D _rigidbody2D;
        
        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }
        
        public void TakeDamage(int damage)
        {
            currentHealth -= damage;
            if (currentHealth <= 0)
                onDeath?.Invoke();
            KnockBack();
        }

        public void KnockBack()
        {
            _rigidbody2D.AddForce(Vector2.right * MonsterController.EnemyLocalScale * (knockBackForce - knockBackResistance));
            StartCoroutine("CancelKnockBack");
        }
        private IEnumerator CancelKnockBack()
        {
            yield return new WaitForSeconds(knockBackDuration);
            // A montrer au prof !
            _rigidbody2D.velocity = Vector2.zero;
        }
    }
}

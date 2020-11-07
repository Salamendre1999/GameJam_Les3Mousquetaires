using System;
using System.Collections;
using System.Collections.Generic;
using Alessio;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Nicolas
{
    public class Health : MonoBehaviour, IDamageable
    {
        [SerializeField] private bool isInvincible = false;
        [SerializeField] private int currentHealth;
        [SerializeField] private int maxHealth;
        [SerializeField] private UnityEvent onDeath;
        [SerializeField] private float knockBackResistance;
        [SerializeField] private SpriteRenderer playerSpriteRenderer;
        [SerializeField] private float invincibilityVisualDelay;
        [SerializeField] private float invincibilityDuration;
        [SerializeField] private float knockBackDuration;
        [SerializeField] private int knockBackForce = 100;
        public camera cameraShake;
        private Rigidbody2D _rigidbody2D;
        [SerializeField] private HealthBar healthBar;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
           healthBar.SetMaxHealth(maxHealth);
         
        }

    
             public void TakeDamage(int damage)
        {
        
            if (!isInvincible)
            {
             
                currentHealth -= damage;
                isInvincible = true;
               
                
                StartCoroutine(InvincibilityVisual());
                StartCoroutine(HandleInvincibilityDelay());
                
                if (currentHealth <= 0)
                    onDeath?.Invoke();
                
                StartCoroutine(cameraShake.Shake(.15f, .4f));
                KnockBack();
                
            }
        }

             void Update()
             {
                 healthBar.SetHealth(currentHealth);
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

        private IEnumerator InvincibilityVisual()
        {
            while (isInvincible)
            {
                var tempColor = playerSpriteRenderer.color;
                tempColor.a = 0;
                playerSpriteRenderer.color = tempColor;
                yield return new WaitForSeconds(invincibilityVisualDelay);
                tempColor.a = 1;
                playerSpriteRenderer.color = tempColor;
                yield return new WaitForSeconds(invincibilityVisualDelay);
            }
        }

        private IEnumerator HandleInvincibilityDelay()
        {
            yield return new WaitForSeconds(invincibilityDuration);
            isInvincible = false;
        }
    }
}

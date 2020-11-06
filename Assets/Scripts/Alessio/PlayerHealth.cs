using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Alessio
{
    public class PlayerHealth : MonoBehaviour, IDamageable
    {
        [SerializeField] private bool isInvincible = false;
        [SerializeField] private int currentHealth;
        [SerializeField] private int maxHealth;
        [SerializeField] private UnityEvent onDeath;
        [SerializeField] private SpriteRenderer playerSpriteRenderer;
        [SerializeField] private float invincibilityVisualDelay;
        [SerializeField] private float invincibilityDuration;

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
            }
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

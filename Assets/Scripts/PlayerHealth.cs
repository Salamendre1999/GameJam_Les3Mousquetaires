using System;
using Nicolas;
using UnityEngine;

namespace Alessio
{
    public delegate void EndInvincibilityDelay();
    public class PlayerHealth : Health, IDamageable
    {
        [SerializeField] private bool isInvincible = false;
        [SerializeField] private SpriteRenderer playerSpriteRenderer;
        [SerializeField] private float invincibilityVisualDelay;
        [SerializeField] private float invincibilityDuration;
        public PlayerInvincibilityFrame playerInvincibilityFrame;
        [SerializeField] private HealthBar healthBar;

        public bool IsInvincible => isInvincible;


        public void Start()
        {
            healthBar.SetMaxHealth(currentHealth);
        }

        private void Update()
        {
            healthBar.SetHealth(currentHealth);
        }

        public void TakeDamage(int damage)
        {
           
            
            if (!isInvincible)
            {
                
                currentHealth -= damage;
                isInvincible = true;
                

                if (currentHealth <= 0)
                {
                    GameManager.Instance.GameOver();
                }

                EndInvincibilityDelay endInvincibilityDelay = ResetInvincibility;
                
                
                StartCoroutine(playerInvincibilityFrame.InvincibilityVisual(isInvincible,
                    playerSpriteRenderer, invincibilityVisualDelay));
                StartCoroutine(playerInvincibilityFrame.HandleInvincibilityDelay(
                    invincibilityDuration, endInvincibilityDelay));
            }
        }

        public void ResetInvincibility()
        {
            isInvincible = false;
        } 
    }
}

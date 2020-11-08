using System;
using System.Collections;
using System.Collections.Generic;
using Nicolas;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

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


        public void TakeDamage(int damage)
        {
           
            
            if (!isInvincible)
            {
                
                currentHealth -= damage;
                healthBar.SetHealth(currentHealth);
                isInvincible = true;
                

                if (currentHealth <= 0)
                {
                    onDeath?.Invoke();
                    return;
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

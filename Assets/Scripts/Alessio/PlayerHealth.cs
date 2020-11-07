using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Alessio
{
    public class PlayerHealth : Health, IDamageable
    {
        [SerializeField] private bool isInvincible = false;
        [SerializeField] private SpriteRenderer playerSpriteRenderer;
        [SerializeField] private float invincibilityVisualDelay;
        [SerializeField] private float invincibilityDuration;
        public CameraShake cameraShake;
        public PlayerInvincibilityFrame playerInvincibilityFrame;
        
        public void TakeDamage(int damage)
        {
            if (!isInvincible)
            {
                currentHealth -= damage;
                isInvincible = true;

                if (currentHealth <= 0)
                {
                    onDeath?.Invoke();
                    return;
                }

                StartCoroutine(playerInvincibilityFrame.InvincibilityVisual(isInvincible,
                    playerSpriteRenderer, invincibilityVisualDelay));
                StartCoroutine(playerInvincibilityFrame.HandleInvincibilityDelay(invincibilityDuration));
                
                StartCoroutine(cameraShake.Shake(.15f, .4f));
                isInvincible = false;

            }
        }
        
        
    }
}

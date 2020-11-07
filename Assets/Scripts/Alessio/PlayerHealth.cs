using System;
using System.Collections;
using System.Collections.Generic;
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

        public bool IsInvincible => isInvincible;

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

                EndInvincibilityDelay endInvincibilityDelay = ResetInvincibility;
                
                
                StartCoroutine(playerInvincibilityFrame.InvincibilityVisual(isInvincible,
                    playerSpriteRenderer, invincibilityVisualDelay));
                StartCoroutine(playerInvincibilityFrame.HandleInvincibilityDelay(
                    invincibilityDuration, endInvincibilityDelay));
            }
        }

        public void ResetInvincibility()
        {
            Debug.Log("Callback : " + isInvincible);
            isInvincible = false;
            Debug.Log("Callback : " + isInvincible);
        } 
    }
}

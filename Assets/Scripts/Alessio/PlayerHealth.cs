using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Alessio
{
    public class PlayerHealth : CharacterManagement, IDamageable
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
                
                StartCoroutine(playerInvincibilityFrame.InvincibilityVisual(isInvincible,
                    playerSpriteRenderer, invincibilityVisualDelay));
                StartCoroutine(playerInvincibilityFrame.HandleInvincibilityDelay(invincibilityDuration));
                
                if (currentHealth <= 0)
                    onDeath?.Invoke();
                
                StartCoroutine(cameraShake.Shake(.15f, .4f));
                KnockBack();
                isInvincible = false;

            }
        }

        public void KnockBack()
        {
            rigidbody2D.AddForce(Vector2.right * MonsterController.EnemyLocalScale * (knockBackForce - knockBackResistance));
            StartCoroutine("CancelKnockBack");
        }
        
    }
}

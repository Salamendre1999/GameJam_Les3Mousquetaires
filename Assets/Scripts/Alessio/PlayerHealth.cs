using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Alessio
{
    public class PlayerHealth : MonoBehaviour, IDamageable
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
        [SerializeField] private PlayerMovement playerMovement;
        public CameraShake cameraShake;
        private Rigidbody2D _rigidbody2D;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
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

        public void KnockBack()
        {
            // TODO: mettre froze à true
            playerMovement.Freeze();
            _rigidbody2D.AddForce(Vector2.right * MonsterController.EnemyLocalScale * (knockBackForce - knockBackResistance));
            StartCoroutine("CancelKnockBack");
            playerMovement.UnFreeze();
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

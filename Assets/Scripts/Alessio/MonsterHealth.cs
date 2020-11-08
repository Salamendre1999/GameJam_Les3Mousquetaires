using System;
using System.Collections;
using System.Collections.Generic;
using Nicolas;
using UnityEngine;
using UnityEngine.Events;

namespace Alessio
{
    public class MonsterHealth : Health, IDamageable
    {
        [SerializeField] private Animator animator;
        public void TakeDamage(int damage)
        {
            currentHealth -= damage;
            if (currentHealth <= 0)
            {
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

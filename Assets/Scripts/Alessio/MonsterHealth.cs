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
        public void TakeDamage(int damage)
        {
            currentHealth -= damage;
            if (currentHealth <= 0)
                onDeath?.Invoke();
        }

    }
}

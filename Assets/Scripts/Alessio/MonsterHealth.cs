using System;
using System.Collections;
using System.Collections.Generic;
using Nicolas;
using UnityEngine;
using UnityEngine.Events;

namespace Alessio
{
    public class MonsterHealth : CharacterManagement, IDamageable
    {
        [SerializeField] private Monster monsterData;

        public void TakeDamage(int damage)
        {
            currentHealth -= damage;
            if (currentHealth <= 0)
                onDeath?.Invoke();
            KnockBack();
        }

        public void KnockBack()
        {
            rigidbody2D.AddForce(Vector2.right * MonsterController.EnemyLocalScale * (knockBackForce - knockBackResistance));
            StartCoroutine("CancelKnockBack");
        }
    }
}

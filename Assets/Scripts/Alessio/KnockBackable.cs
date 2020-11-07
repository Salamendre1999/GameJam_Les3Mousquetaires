﻿using System.Collections;
using UnityEngine;

namespace Alessio
{
    public class KnockBackable : MonoBehaviour, IKnockBackable
    {
        [SerializeField] protected float knockBackResistance;
        [SerializeField] protected float knockBackDuration;
        [SerializeField] protected int knockBackForce = 100;
        [SerializeField] protected Rigidbody2D rigidbody2D;
    
    
        private void Awake()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public void KnockBackHandler()
        {
            if (gameObject.activeSelf)
            {
                rigidbody2D.AddForce(Vector2.right * MonsterController.EnemyLocalScale * (knockBackForce - knockBackResistance));
                StartCoroutine("CancelKnockBack"); 
            }
        }

        public IEnumerator CancelKnockBack()
        {
            yield return new WaitForSeconds(knockBackDuration);
            rigidbody2D.velocity = Vector2.zero;
        }
        
    }
}

using System;
using UnityEngine;

namespace Alessio
{
    public class RangedEnemyController : MonoBehaviour
    {
        [SerializeField] private FireControlller fireControlller;
        [SerializeField] private float fireRate;
        [SerializeField] private float fireBallDelay;
        [SerializeField] private float rangeForAttacking;
        private Transform target;
        private Rigidbody2D _rigidbody2D;
        

        private void Awake()
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }

        private void Update()
        {
            CheckIfTimeToFire();
        }

        private void CheckIfTimeToFire()
        {
            float positionRequiredX = Math.Abs(target.position.x - transform.position.x);
            float positionRequiredY = Math.Abs(target.position.y - transform.position.y);
            if (Time.time > fireBallDelay && (positionRequiredX < rangeForAttacking) && (positionRequiredY < rangeForAttacking))
            {
                fireControlller.Fire(target);
                fireBallDelay = Time.time + fireRate;
            }
        }
    }
}

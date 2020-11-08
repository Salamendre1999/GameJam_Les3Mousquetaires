using UnityEngine;

namespace Alessio
{
    public class RangedEnemyController : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private FireControlller fireControlller;
        [SerializeField] private float fireRate;
        [SerializeField] private float fireBallDelay;
    
    
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
            if (Time.time > fireBallDelay)
            {
                fireControlller.Fire(target);
                fireBallDelay = Time.time + fireRate;
            }
        }
    }
}

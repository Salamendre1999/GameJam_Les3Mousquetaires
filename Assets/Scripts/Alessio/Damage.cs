using System;
using UnityEngine;

namespace Alessio
{
    public class Damage : MonoBehaviour
    {
        [SerializeField] private int value;
        [SerializeField] private LayerMask layersAuthorized;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (layersAuthorized == (layersAuthorized | (1 << other.gameObject.layer)))
            {
                var iDamageable = other.attachedRigidbody.GetComponent<IDamageable>();
                iDamageable?.TakeDamage(value);
            }
        }
    
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (layersAuthorized == (layersAuthorized | (1 << other.gameObject.layer)))
            {
                var iDamageable = other.rigidbody.GetComponent<IDamageable>();
                iDamageable?.TakeDamage(value);
            }
        }

        private void OnCollisionStay2D(Collision2D other)
        {
            OnCollisionEnter2D(other);
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.CompareTag("Weapon"))
            {
                return;
            }
            OnTriggerEnter2D(other);
        }
    }
}

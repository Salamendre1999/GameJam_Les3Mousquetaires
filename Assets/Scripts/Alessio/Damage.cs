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
                try
                {
                    var playerHealth = (PlayerHealth) iDamageable;
                    if (!playerHealth.IsInvincible)
                        other.attachedRigidbody.GetComponent<IKnockBackable>()?.KnockBackHandler();
                }
                catch
                {
                    // ignored
                }

                iDamageable?.TakeDamage(value);
            }
            /*
            other.attachedRigidbody.GetComponent<IDamageable>()?.TakeDamage(value);
            if (other.attachedRigidbody.GetComponent<PlayerHealth>()?.IsInvincible == false)
            {
                other.attachedRigidbody.GetComponent<IKnockBackable>()?.KnockBackHandler();
            }
            */
        }
    
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (layersAuthorized == (layersAuthorized | (1 << other.gameObject.layer)))
            {
                //Debug.Log(other.rigidbody.GetComponent<PlayerHealth>());
                var iDamageable = other.rigidbody.GetComponent<IDamageable>();
                try
                {
                    var playerHealth = (PlayerHealth) iDamageable;
                    if (!playerHealth.IsInvincible)
                        other.rigidbody.GetComponent<IKnockBackable>()?.KnockBackHandler();
                }
                catch
                {
                    // ignored
                }

                iDamageable?.TakeDamage(value);
            }
        }

        private void OnCollisionStay2D(Collision2D other)
        {
            OnCollisionEnter2D(other);
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            OnTriggerEnter2D(other);
        }
    }
}

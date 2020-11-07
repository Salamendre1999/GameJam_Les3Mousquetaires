using UnityEngine;

namespace Alessio
{
    public class Damage : MonoBehaviour
    {
        [SerializeField] private int value;

        private void OnTriggerEnter2D(Collider2D other)
        {
            other.attachedRigidbody.GetComponent<IDamageable>()?.TakeDamage(value);
        }
    
        private void OnCollisionEnter2D(Collision2D other)
        {
            other.rigidbody.GetComponent<IDamageable>()?.TakeDamage(value);
            other.rigidbody.GetComponent<IKnockBackable>()?.KnockBackHandler();
            other.rigidbody.GetComponent<IKnockBackable>()?.CancelKnockBack();
        }

    }
}

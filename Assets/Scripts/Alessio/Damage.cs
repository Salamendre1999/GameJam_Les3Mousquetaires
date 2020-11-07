using UnityEngine;

namespace Alessio
{
    public class Damage : MonoBehaviour
    {
        [SerializeField] private int value;
        [SerializeField] private LayerMask layersAuthorized;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(layersAuthorized==(layersAuthorized|(1<< other.gameObject.layer)))
                
                other.attachedRigidbody.GetComponent<IDamageable>()?.TakeDamage(value);
        }
    
        private void OnCollisionEnter2D(Collision2D other)
        {
            if(layersAuthorized==(layersAuthorized|(1<< other.gameObject.layer)))
                other.rigidbody.GetComponent<IDamageable>()?.TakeDamage(value);
        }

    }
}

using UnityEngine;

namespace Alessio
{
    public class TakePotion : MonoBehaviour
    {
        [SerializeField] private PlayerHealth playerHealth;
        [SerializeField] private int recoverHealthPoints;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponentInParent(typeof(PlayerMovement)))
            {
                if (playerHealth.CurrentHealth + recoverHealthPoints <= playerHealth.MAXHealth)
                {
                    playerHealth.CurrentHealth += recoverHealthPoints;
                }
                else
                {
                    playerHealth.CurrentHealth = playerHealth.MAXHealth;
                }
                Destroy(gameObject); 
            }
        }
    }
}

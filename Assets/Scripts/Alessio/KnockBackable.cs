using System.Collections;
using UnityEngine;

namespace Alessio
{
    public class KnockBackable : MonoBehaviour, IKnockBackable
    {
        [SerializeField] protected float knockBackResistance;
        [SerializeField] protected float knockBackDuration;
        [SerializeField] protected int knockBackForce = 100;
        [SerializeField] protected Rigidbody2D rigidbody2D;
        [SerializeField] private PlayerMovement playerMovement;


        private void Awake()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public void KnockBackHandler(bool isPlayer)
        {
            if (gameObject.activeSelf)
            {
                if(isPlayer)
                playerMovement.enabled=false;
                rigidbody2D.AddForce(Vector2.right * MonsterController.EnemyLocalScale * (knockBackForce - knockBackResistance));
                StartCoroutine("CancelKnockBack",isPlayer); 
            }
        }

        public IEnumerator CancelKnockBack(bool isPlayer)
        {
            yield return new WaitForSeconds(knockBackDuration);
            rigidbody2D.velocity = Vector2.zero;
            if(isPlayer)
                playerMovement.enabled=true;
        }
        
    }
}

using UnityEngine;

namespace Alessio
{
    public class MonsterController : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private float moveSpeed;
        private Rigidbody2D _rigidbody2D;
        private Vector2 _movement;
        public static Vector2 EnemyLocalScale;

        private void Awake()
        {
            EnemyLocalScale = transform.localScale;
            _rigidbody2D = this.GetComponent<Rigidbody2D>();
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }

        private void Update()
        {
            Vector3 direction = target.position - transform.position;
            direction.Normalize();
            _movement = direction;
        }

        private void FixedUpdate()
        {
            MoveEnnemy(_movement);
        }

        void MoveEnnemy(Vector2 direction)
        {
            _rigidbody2D.MovePosition((Vector2)transform.position + (direction * (moveSpeed * Time.deltaTime)));
        }
    }
}

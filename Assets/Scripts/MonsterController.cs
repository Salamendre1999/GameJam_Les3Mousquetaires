using UnityEngine;

namespace Alessio
{
    public class MonsterController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;
        private Transform _target;
        private Rigidbody2D _rigidbody2D;
        private Vector2 _movement;
        public static Vector2 EnemyLocalScale;

        private void Awake()
        {
            EnemyLocalScale = transform.localScale;
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _target = GameObject.FindGameObjectWithTag("Player").transform;
        }

        private void Update()
        {
            Vector3 direction = _target.position - transform.position;
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

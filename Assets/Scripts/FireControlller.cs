using UnityEngine;

namespace Alessio
{
    public class FireControlller : MonoBehaviour
    {
        [SerializeField] private GameObject projectilePrefab;
        [SerializeField] private Transform projectileSpawner;
        [SerializeField] private float projectileSpeed;

        public void Fire(Transform target)
        {
            if (projectilePrefab.TryAcquire(out var projectile) == false)
                return;
            var t = projectile.transform;
            t.position = projectileSpawner.position;
            t.rotation = projectileSpawner.rotation;
            var rb = projectile.GetComponent<Rigidbody2D>();
            if (rb)
            {
                Vector2 direction = (target.position - t.position).normalized * projectileSpeed;
                rb.velocity = new Vector2(direction.x, direction.y);
            }
            projectile.layer = gameObject.layer;
        }
    }
}

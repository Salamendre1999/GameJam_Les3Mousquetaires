using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Alessio
{
    public class FireballDestruction : MonoBehaviour
    {
        [SerializeField] private LayerMask layersAuthorized;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if(layersAuthorized == (layersAuthorized | (1 << other.gameObject.layer)) || other.gameObject.layer == 11)
                gameObject.TryRelease();
        }
    }
}

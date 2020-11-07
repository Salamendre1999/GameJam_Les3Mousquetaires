using UnityEngine;

namespace Alessio
{
    public class Epee : MonoBehaviour
    {
        public GameObject followThisObject;

        void Update()
        {
            transform.position = followThisObject.transform.position;
        }
    }
}

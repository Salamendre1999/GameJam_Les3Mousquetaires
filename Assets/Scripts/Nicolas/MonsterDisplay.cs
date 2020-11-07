using UnityEngine;
using UnityEngine.UI;

namespace Nicolas
{
    public class MonsterDisplay : MonoBehaviour
    {
        [SerializeField] private Monster datas;
        [SerializeField] private SpriteRenderer modele;
     
    
        
        
        // Start is called before the first frame update
        void Start()
        {

            modele.sprite = datas.artwork;

        }


    }
}
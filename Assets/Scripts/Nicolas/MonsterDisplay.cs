using UnityEngine;
using UnityEngine.UI;

namespace Nicolas
{
    public class MonsterDisplay : MonoBehaviour
    {

        [SerializeField] private Monster monster;

        
        
        // Start is called before the first frame update
        void Start()
        {
          
    Debug.Log(monster.monsterName);



        }


    }
}
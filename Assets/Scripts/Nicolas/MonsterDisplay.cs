using UnityEngine;
using UnityEngine.UI;

namespace Nicolas
{
    public class MonsterDisplay : MonoBehaviour
    {

        [SerializeField] private Text nameText;
        [SerializeField] private Image icon;
        [SerializeField] private Text damage;
        [SerializeField] private Text health;
        public static MonsterDisplay Instance;
        [SerializeField] private Monster datas;
        
        
        // Start is called before the first frame update
        void Start()
        {

            Instance = this;
            Instance.nameText.text = datas.name;
            Instance.icon.sprite = datas.artwork;
            Instance.damage.text = datas.damage.ToString();
            Instance.health.text = datas.health.ToString();


        }


    }
}
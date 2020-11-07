using Nicolas;
using UnityEngine;

namespace Alessio
{
    [RequireComponent(typeof(MonsterHealth))]
    public class MonsterTemplate : MonoBehaviour
    {
        [SerializeField] private Monster template;
        private MonsterHealth _monsterHealth;
        //private MonsterDamage _damage;
        

        private Monster _currentTemplate = null;

        private void Awake()
        {
            InitRef();
        }

        private void InitRef()
        {
            if (!_monsterHealth)
                _monsterHealth = GetComponent<MonsterHealth>();
            
        }

        private void OnEnable()
        {
            _monsterHealth.CurrentHealth = template.monsterHealth;
            _monsterHealth.MaxHealth = template.monsterHealth;

        }

        private void OnValidate()
        {
            InitRef();
            if (template != _currentTemplate)
            {
                _monsterHealth.CurrentHealth = template.monsterHealth;
                _currentTemplate = template;
            }
        }
    }
}

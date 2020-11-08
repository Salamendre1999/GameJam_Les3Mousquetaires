using UnityEngine;

namespace Nicolas
{
    [CreateAssetMenu(fileName = "Monster",menuName = "Monsters")]
    public class Monster : ScriptableObject
    {
        public string monsterName;
        public Sprite artwork;
        public int damage;
        public int monsterHealth;

    }
}
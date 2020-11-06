using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Monster",menuName = "Monsters")]
public class Ennemy : ScriptableObject
{
   [SerializeField] private string ennemyName;
   [SerializeField] public Sprite artwork;
   [SerializeField] public int damage;
   [SerializeField] public int health;

}

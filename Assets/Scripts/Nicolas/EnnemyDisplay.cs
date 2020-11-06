using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnnemyDisplay : MonoBehaviour
{

    [SerializeField] private Ennemy ennemy;
    
    
    [SerializeField] private Text ennemyNameText;
    [SerializeField] private Image artworkImage;
    [SerializeField] private Text damagText;
    [SerializeField]private Text healthText;
    // Start is called before the first frame update
    void Start()
    {

        ennemyNameText.text = ennemy.name;
        artworkImage.sprite = ennemy.artwork;
        damagText.text = ennemy.damage.ToString();
        healthText.text = ennemy.health.ToString();
        


    }

  
}

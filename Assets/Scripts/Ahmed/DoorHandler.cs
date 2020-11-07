using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandler : MonoBehaviour
{
    [SerializeField] private GUIStyle style;
    [SerializeField] private Sprite openDoorSprite;
    [SerializeField] private Sprite closedDoorSprite;
    [SerializeField] private int doorNumber;
    [SerializeField] private BoxCollider2D collider;
    private GameObject character;
    private bool isOpen;
    private bool inRange;
    private bool goodKey;
    private bool clicked;


    private void Update()
    {
        if (inRange && goodKey && Input.GetButtonDown("Attack"))
        {
            clicked = true;
        }
    }

    private void FixedUpdate()
    {
        if (clicked && !isOpen)
        {
            Debug.Log("i enter here lets goo");
            character.GetComponent<CharacterInventory>().keyNumber = 0;
            character.GetComponent<CharacterInventory>().hasAKey = false;
            gameObject.GetComponent<SpriteRenderer>().sprite = openDoorSprite;
            collider.enabled = false;
            isOpen = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.parent.gameObject.GetComponent<PlayerMovement>())
        {
            inRange = true;
            character = other.transform.parent.gameObject;
            if (character.GetComponent<CharacterInventory>().keyNumber == doorNumber)
            {
                goodKey = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        
    }

    private void OnGUI()
    {
        if (inRange && goodKey && !isOpen)
        {
            GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 100f, 100f), "PRESS A TO OPEN THE DOOR",style);

        }
    }
}

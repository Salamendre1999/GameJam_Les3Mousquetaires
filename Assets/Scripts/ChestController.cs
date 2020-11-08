using UnityEngine;

public class ChestController : MonoBehaviour
{
    [SerializeField] private GUIStyle style;
    [SerializeField] private Sprite openedChest;
    [SerializeField] private Sprite closedChest;
    
    private GameObject character;
    private bool inRange;
    private bool opened;
    private bool isAuthorized;
    private bool containsKey;
    private bool hasKey;

    private void Update()
    {
        if (inRange && !hasKey && Input.GetButtonDown("Attack"))
        {
            isAuthorized = true;
        }
    }

    private void FixedUpdate()
    {
        if (isAuthorized && !opened)
        {
            character.GetComponent<CharacterInventory>().hasAKey = true;
            hasKey = true;
            gameObject.GetComponent<SpriteRenderer>().sprite = openedChest;
            opened = true;
            isAuthorized = false;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.parent.gameObject.GetComponent<PlayerMovement>())
        {
            inRange = true;
            character = other.transform.parent.gameObject;
            if (!character.GetComponent<CharacterInventory>().hasAKey)
            {
                hasKey = false;
            }
            else
            {
                hasKey = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.parent.gameObject.GetComponent<PlayerMovement>())
        {
            inRange = false;
        }
    }

    private void OnGUI()
    {
        if (inRange && isAuthorized )
        {
            GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 100f, 100f), "PRESS A TO OPEN THE CHEST",style);
        }
    }
}

using UnityEngine;

public class DoorHandler : MonoBehaviour
{
    [SerializeField] private GUIStyle style;
    [SerializeField] private Sprite openDoorSprite;
    [SerializeField] private Sprite closedDoorSprite;
    [SerializeField] private BoxCollider2D collider;
    private GameObject character;
    private bool isOpen;
    private bool inRange;
    private bool clicked;
    private bool hasKey;


    private void Update()
    {
        if (inRange && hasKey && Input.GetButtonDown("Attack"))
        {
            clicked = true;
        }
    }

    private void FixedUpdate()
    {
        if (clicked && hasKey && !isOpen)
        {
            character.GetComponent<CharacterInventory>().hasAKey = false;
            gameObject.GetComponent<SpriteRenderer>().sprite = openDoorSprite;
            collider.enabled = false;
            isOpen = true;
            hasKey = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.parent.gameObject.GetComponent<PlayerMovement>())
        {
            inRange = true;
            character = other.transform.parent.gameObject;
            hasKey = character.GetComponent<CharacterInventory>().hasAKey;
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
        if (inRange && !isOpen && hasKey)
        {
            GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 100f, 100f), "PRESS A TO OPEN THE DOOR",style);

        }
    }
}

using Nicolas;
using UnityEngine;
using UnityEngine.SceneManagement;

public class winCondition : MonoBehaviour
{
    private bool inRange;
    private bool clicked;
    [SerializeField] private GUIStyle style;

    private void Update()
    {
        if (inRange && Input.GetButtonDown("Attack"))
        {
            clicked = true;
        }
        if (inRange && clicked)
        {
            GameManager.Instance.Win();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponentInParent(typeof(PlayerMovement)))
        {
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponentInParent(typeof(PlayerMovement)))
        {
            inRange = false;
        }
    }

    private void OnGUI()
    {
        if (inRange)
        {
            GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 100f, 100f), "PRESS A TO WIN WOOOOW",style);
        }
    }
}

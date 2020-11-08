using UnityEngine;
using UnityEngine.UI;

public class CharacterInventory : MonoBehaviour
{
    [SerializeField] private Image keyImage;
    public bool hasAKey;

    private void Update()
    {
        if (hasAKey)
        {
            var color = keyImage.color;
            color.a = 1f;
            keyImage.color = color;
        }
        else
        {
            var color = keyImage.color;
            color.a = .1f;
            keyImage.color = color;
        }
    }
}

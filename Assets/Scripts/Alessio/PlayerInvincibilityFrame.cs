using System.Collections;
using System.Collections.Generic;
using Alessio;
using UnityEditor;
using UnityEngine;

public class PlayerInvincibilityFrame : MonoBehaviour
{
    private bool _isInvincible;

    public IEnumerator InvincibilityVisual(bool isInvincible, SpriteRenderer playerSpriteRenderer,
        float invincibilityVisualDelay)
    {
        _isInvincible = isInvincible;
        while (_isInvincible)
        {
            var tempColor = playerSpriteRenderer.color;
            tempColor.a = 0;
            playerSpriteRenderer.color = tempColor;
            yield return new WaitForSeconds(invincibilityVisualDelay);
            tempColor.a = 1;
            playerSpriteRenderer.color = tempColor;
            yield return new WaitForSeconds(invincibilityVisualDelay);
        }
    }

    public IEnumerator HandleInvincibilityDelay(float invincibilityDuration,
        EndInvincibilityDelay endInvincibilityDelay)
    {
        Debug.Log(invincibilityDuration + " " + _isInvincible);
        yield return new WaitForSeconds(invincibilityDuration);
        _isInvincible = false;
        endInvincibilityDelay();
    }
}

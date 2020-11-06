using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Rigidbody2D playerRigidBody2D;
    private bool lookAtRight = true;
    [SerializeField] private float speed;
    private void Awake()
    {
        playerRigidBody2D = gameObject.GetComponent<Rigidbody2D>();
    }

    public void Move(float horizontalMove, float verticalMove)
    {
        Vector3 movement = new Vector2(horizontalMove,verticalMove).normalized;
        playerRigidBody2D.velocity = movement * speed;

        if (horizontalMove < 0 && lookAtRight)
        {
            FlipSprite();
        } else if(horizontalMove>0 && !lookAtRight)
        {
            FlipSprite();
        }
    }

    private void FlipSprite()
    {
        lookAtRight = !lookAtRight;
        
        //cant change directly a struct
        Vector3 scaleTemp = transform.localScale;
        scaleTemp.x *= -1;
        transform.localScale = scaleTemp;
    }
}

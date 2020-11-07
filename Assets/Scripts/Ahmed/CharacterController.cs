﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D playerRigidBody2D;
    private Animator weaponAnimator;
    private bool lookAtRight = true;
    private bool lookAtTop = false;
    private bool lookAtBot = false;
    private void Awake()
    {
        playerRigidBody2D = gameObject.GetComponent<Rigidbody2D>();
        //weaponAnimator = transform.Find("Weapon").GetComponent<Animator>();
    }

    public void Move(float horizontalMove, float verticalMove, bool isAttacking)
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

        if (isAttacking)
        {
            if (verticalMove > 0 && verticalMove>Math.Abs(horizontalMove))
            {
                weaponAnimator.Play("TopSwingSword");
            }else if (verticalMove < 0 && Math.Abs(verticalMove)>Math.Abs(horizontalMove))
            {
                weaponAnimator.Play("BotSwingSword");
            }
            else
            {
                weaponAnimator.Play("RightSwingSword");
            }
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

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private float horizontalMove;
    private float verticalMove;
    [SerializeField] private CharacterController characterController;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        verticalMove = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        characterController.Move(horizontalMove,verticalMove);
    }
}

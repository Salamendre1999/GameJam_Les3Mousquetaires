using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private float horizontalMove;
    private float verticalMove;
    [SerializeField] private CharacterController characterController;

    [SerializeField] private float speed;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal") * speed;
        verticalMove = Input.GetAxis("Vertical") * speed;
    }

    private void FixedUpdate()
    {
        characterController.Move(horizontalMove*Time.deltaTime,verticalMove*Time.deltaTime, speed);
    }
}

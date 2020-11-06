using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float moveSpeed;
    private Rigidbody2D _rigidbody2D;
    private Vector2 _movement;

    private void Awake()
    {
        _rigidbody2D = this.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector3 direction = target.position - transform.position;
        direction.Normalize();
        _movement = direction;
    }

    private void FixedUpdate()
    {
        MoveEnnemy(_movement);
    }

    void MoveEnnemy(Vector2 direction)
    {
        _rigidbody2D.MovePosition((Vector2)transform.position + (direction * (moveSpeed * Time.deltaTime)));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MunizCodeKit.Systems;
using MunizCodeKit.Interface;

public class Movement2DPlataformerRigidBody : MonoBehaviour, IMovementUser 
{
    Rigidbody2D rbody;
     [SerializeField]float movementSpeed;
    float speed;

    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        speed = Input.GetAxisRaw("Horizontal");
     }

    private void FixedUpdate()
    {
        rbody.velocity = new Vector2(GetMovementSpeed(), rbody.velocity.y);
    }

    public float GetMovementSpeed()
    {
        return speed * movementSpeed;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5; // Players move speed

    public Rigidbody2D rb; // The rigid body

    Vector2 movement;//vector used for movement

    void Update()
    {
        //GET INPUTS
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

    }

    void FixedUpdate()
    {
        // MOVE PLAYERS
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}

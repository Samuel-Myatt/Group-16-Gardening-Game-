using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Create reference to flower game object.

    public Rigidbody2D rb; // The rigid body
    Vector2 movement;//vector used for movement

    public float moveSpeed = 5; // Players move speed
    bool inFlowerRange; //Flag for flower range

    //Temp spaghetti 
    //Stores Current Flower
    GameObject CurrFlower; 
    

    void Update()
    {
        //GET INPUTS
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown("space") && (inFlowerRange == true))
        {
            Debug.Log("Rejuvinating...");

            CurrFlower.GetComponent<FlowerScript>().Rejuvinate();
            //CurrFlower.Rejuvinate();
            //StartCoroutine(FlowerScript.Rejuvinate());

            //Should use something along the lines of... Flower.getcomponent<script>.Function().
            // run rejuvinate on the flower in contact with 
        }
    }

    void FixedUpdate()
    {
        // MOVE PLAYERS
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }


    //Detects when player enters/exits a flower's range.
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("In Range");

        CurrFlower = collider.gameObject;

        //Displays current flower 
        Debug.Log(CurrFlower);

        inFlowerRange = true;
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        Debug.Log("Left Range");

        inFlowerRange = false;
    }

}

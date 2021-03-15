using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    //Player rigid body
    public Rigidbody2D rb;
    public Slider plantHealth;
    //Player vector used for movement
    Vector2 movement;

    // Players move speed
    public float moveSpeed = 5;

    public string statusEffect;
    //Flag for flower range
    bool inFlowerRange; 

    //Stores Current Flower
    GameObject CurrFlower; 
    

    void Update()
    {
        StartCoroutine("Movement");
    }

    void FixedUpdate()
    {
        // MOVE PLAYERS
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    IEnumerator Movement()
    {
        //GET INPUTS
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown("space") && (inFlowerRange == true))
        {
            //Log to see if input is recognised
            Debug.Log("Rejuvenating...");

            //Targets the collided with flower and runs Rejuvinate 
            CurrFlower.GetComponent<FlowerScript>().Rejuvenate();
        }
        yield return null;
    }



    //Detects when player enters/exits a flower's range.
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("In Range");
        plantHealth.gameObject.SetActive(true);

        //Assigns the collided with flower to the Current Flower var
        CurrFlower = collider.gameObject;

        //Displays current flower 
        Debug.Log(CurrFlower);

        //Checks if the player is in the Flower's range
        inFlowerRange = true;
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        plantHealth.gameObject.SetActive(false);
        Debug.Log("Left Range");

        //Resets the var for when the player leaves the flower's range
        inFlowerRange = false;
    }
}

//To do

//On enter and exit flower 
//Make a Plant's health appear/disappear 
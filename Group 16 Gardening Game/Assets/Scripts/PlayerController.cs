using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    //Player rigid body
    public Rigidbody2D rb;
    public Animator animator;
    
    //Player vector used for movement
    Vector2 movement;
    Vector2 moveDir;
    Vector2 prevDir;
    

    // Players move speed
    public float moveSpeed = 5.0f;

    public string statusEffect;
    //Flag for flower range
    bool inFlowerRange;
    public bool hasCan;
    public bool hasFertilizer;
    GameObject WateringCan;
   

    //Stores Current Flower
    GameObject CurrFlower;

    private void Start()
    {
        WateringCan = GameObject.FindWithTag("WaterCan");
    }
    void Update()
    {
        //StartCoroutine("Movement");
        Movement();
        Animate();
        DropCan();

    }

    void FixedUpdate()
    {
        // MOVE PLAYERS
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        

        
    }

    void Movement()
    {
        //GET INPUTS
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        moveDir = new Vector2(movement.x, movement.y).normalized;

        if ((movement.x == 0 && movement.y == 0) && moveDir.x != 0 || moveDir.y != 0)
        {
            prevDir.x = moveDir.x;
            prevDir.y = moveDir.y;

        }

        if (Input.GetKeyDown("space") && (inFlowerRange == true))
        {
            //Log to see if input is recognised
            Debug.Log("Rejuvenating...");

            //Targets the collided with flower and runs Rejuvinate 
            CurrFlower.GetComponent<FlowerScript>().Rejuvenate();
        }
        
    }
    void DropCan()
    {
        if (WateringCan== true && Input.GetKey(KeyCode.Q))
        {
            hasCan = false;
            WateringCan.SetActive(true);
            WateringCan.transform.parent = null;

        }
    }



    //Detects when player enters/exits a flower's range.
    private void OnTriggerEnter2D(Collider2D collider)
    {
        //Debug.Log("In Range");

        
        //Assigns the collided with flower to the Current Flower var
        CurrFlower = collider.gameObject;

       
        //Displays current flower 
        Debug.Log(CurrFlower);

        //Checks if the player is in the Flower's range
        inFlowerRange = true;
        
    }
    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "WaterCan" && !hasCan)
        {
            if (Input.GetKey(KeyCode.E))
            {
                Debug.Log("Pickup");
                WateringCan.transform.parent = gameObject.transform;
                WateringCan.SetActive(false);
                hasCan = true;

            }

        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
       
        Debug.Log("Left Range");

        //Resets the var for when the player leaves the flower's range
        inFlowerRange = false;
    }
    void Animate()
    {
        animator.SetFloat("AnimMoveX", movement.x);
        animator.SetFloat("AnimMoveY", movement.y);
        animator.SetFloat("AnimMoveForce", movement.magnitude);
        animator.SetFloat("PrevMoveX", prevDir.x);
        animator.SetFloat("PrevMoveY", prevDir.y);
    }
}

//To do

//On enter and exit flower 
//Make a Plant's health appear/disappear 
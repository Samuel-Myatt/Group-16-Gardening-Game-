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


    //Player Game Vars
    public float moveSpeed = 5.0f;
    public string statusEffect;
    public Vector2 playerPos;

    //Flag for flower range
    bool inFlowerRange;
    //Plant healthbar
    public Slider plantHealth;

    public bool hasCan = false;
    public bool hasFertilizer = false;
    GameObject WateringCan;
    GameObject Fertalizer;


    //Stores Current Flower
    GameObject CurrFlower;

    private void Start()
    {
        WateringCan = GameObject.FindWithTag("WaterCan");
        Fertalizer = GameObject.FindWithTag("Fertalizer");
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

        //Updates PlantHealth Position independant of functions
        //(Mostly stops glitchy behaviour)

        plantHealth.transform.position = playerPos;

        if (inFlowerRange == true)
        {
            PlantHealth();
        }
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

            // Detects what kind of flower the player has ran into
            if (CurrFlower.tag == "Flower"&& hasCan)
            {
                CurrFlower.GetComponent<FlowerScript>().Rejuvenate();
            }
            if (CurrFlower.tag == "FertFlower" && hasFertilizer)
            {
                CurrFlower.GetComponent<FlowerScript>().Rejuvenate();
            }
        }

    }
    void DropCan()
    {
        // drops the current item you have equiped
        if (WateringCan== true && Input.GetKey(KeyCode.Q))
        {
            hasCan = false;
            WateringCan.SetActive(true);
            WateringCan.transform.parent = null;

        }
        if (Fertalizer == true && Input.GetKey(KeyCode.Q))
        {
            hasFertilizer = false;
            Fertalizer.SetActive(true);
            Fertalizer.transform.parent = null;

        }
    }

    void PlantHealth()
    {
        //Grabs current flower's hp each frame
        plantHealth.value = CurrFlower.GetComponent<FlowerScript>().FlowerTime;
        playerPos = this.transform.position;
        //Add Y offset if possible
    }


    //Detects when player enters/exits a flower's range.
    private void OnTriggerEnter2D(Collider2D collider)
    {
        //Checks if the player is in the Flower's range
        inFlowerRange = true;
        //Debug.Log("In Range");

        Debug.Log("In Range");
        //Assigns the collided with flower to the Current Flower var
        CurrFlower = collider.gameObject;

        //Displays current flower
        Debug.Log(CurrFlower);

        //Enable Plant Healthbar
        plantHealth.gameObject.SetActive(true);


    }
    private void OnTriggerStay2D(Collider2D collider)
    {
        // player can equip watering can
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
        // player can equip fertalizer
        if (collider.gameObject.tag == "Fertalizer" && !hasFertilizer)
        {
            if (Input.GetKey(KeyCode.E))
            {
                Debug.Log("Pickup");
                Fertalizer.transform.parent = gameObject.transform;
                Fertalizer.SetActive(false);
                hasFertilizer = true;

            }

        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        //Disable health bar
        plantHealth.gameObject.SetActive(false);

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

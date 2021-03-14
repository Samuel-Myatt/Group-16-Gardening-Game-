using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerScript : MonoBehaviour
{

    //Flower's life timer 
    int FlowerTime = 101;

    bool IsDead = false;
    //Stores a Flower instance's Sprite rendere
    //Temporary while we wait for art
    SpriteRenderer m_SpriteRenderer;

    void Start()
    {
        //Grabs a Flower instance's Sprite renderer and assigns to var
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }
   

    // Update is called once per frame
    void Update()
    {

        //Switch case for a Flower's life, tracks the flower's states
        switch (FlowerTime)
        {
            case 100:
                Debug.Log("Normal Flower");
                m_SpriteRenderer.color = Color.green;
                break;

            case 50:
                Debug.Log("Warning Flower");
                m_SpriteRenderer.color = Color.blue;
                break;

            case 30:
                Debug.Log("Critical Flower");
                m_SpriteRenderer.color = Color.yellow;
                break;

            case 0:
                Debug.Log("Dead Flower");
                m_SpriteRenderer.color = Color.black;
                IsDead = true;
                break;
        }
    }

    void FixedUpdate()
    {
        //Ticks down a flower's life if not already dead
        if(FlowerTime > 0)
        {
            FlowerTime -= 1;
        }
    }

    //Function to restore a flower's life 

    //Intended behavior is for the number to tick upwards while the button is held
    public void Rejuvenate()
    {
        if(!IsDead)
        {
            FlowerTime = 100;
        }
        
        //Temporary Behaviour for Rejuvinate during testing
    }
}

//TO DO

//Make Flower Count down in seperate function

//This will stop jitter when rejuvenating
//Overall adds to polish too


//Psuedo Code

//Update Function 


//Switch Case(FlowerTime) 

//If the Flower is below a certain time the state changes

//Normal

//Warning

//Critical

//dead state when 0 

//Unsure if should tick every frame (Doesn't really matter) 






//Fixed Update

//If not 0 
//Count Down FlowerTime
//or Create dead check 


//Code for when the player interacts with the flower 

//Increase flower time by the amount the button is held by player (Flowertime * TimeDelta?? While player holds button) 

//New Function which can be called in Player Script which just ticks up ther flower count 

//Display Flower Time as an UI Element while we wait for art assets 

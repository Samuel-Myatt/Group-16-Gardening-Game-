using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerScript : MonoBehaviour
{

    int FlowerTime = 100;

    // Update is called once per frame
    void Update()
    {
        switch (FlowerTime)
        {
            case 100:
                Debug.Log("Normal Flower");
                break;

            case 50:
                Debug.Log("Warning Flower");
                break;

            case 10:
                Debug.Log("Critical Flower");
                break;

            case 0:
                Debug.Log("Dead Flower");
                break;
        }
    }

    void FixedUpdate()
    {
        FlowerTime -= 1;

    }

}


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


//Display Flower Time as an UI Element while we wait for art assets 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerScript : MonoBehaviour
{

    public int FlowerTime;

    // Update is called once per frame
    void Update()
    {
        switch (FlowerTime)
        {
            case 100:
                break;

            case 50:
                break;

            case 10:
                break;

            case 0:
                break;
        }
    }

    void FixedUpdate()
    {

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
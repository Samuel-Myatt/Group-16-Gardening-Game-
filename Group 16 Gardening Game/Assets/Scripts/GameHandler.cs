using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

//This Script Handles the game loop

public class GameHandler : MonoBehaviour
{

    //Flower Vars
    
    private GameObject[] Flowers; //Created GameObject Array Flowers 
    private int NumberOfFlowers; // Number of flowers in total
    private int NumberDead = 0; // Records number of dead flowers

    //Clock Vars
    public float totalTime; // the timer length
    private float minutes;//as it says
    private float seconds;

    //UI Vars 
    public Text FlowerText;
    public Text ClockText;
    public Text Score;

    void Start()
    {
        FindFlowers();

    }
    // Update is called once per frame
    void Update()
    {
        Clock();
        FlowerCheck();

    }


    void FindFlowers()
    {
        //Finds all flowers
        Flowers = GameObject.FindGameObjectsWithTag("Flower");

        //For each flower in the array
        foreach (GameObject o in Flowers)
        {
            // Add to number of flowers
            NumberOfFlowers++;

            Debug.Log("Flower noticed" + NumberOfFlowers.ToString());  //debug
        }
    }

    void FlowerCheck()
    {
        NumberDead = 0; // resets the variable so we have a live reading at all times
        foreach (var Dead in Flowers)// for every flower in the array
        {
            if (Dead.GetComponent<FlowerScript>().IsDead)// get the IsDead variable from the current flower
            {
                Debug.Log(NumberDead.ToString());// debug
                NumberDead++;//increase number of dead

            }
        }
        FlowerText.text = (NumberOfFlowers - NumberDead).ToString() + "/" + NumberOfFlowers.ToString();
    }

    void Clock()
    {
        totalTime -= Time.deltaTime; // reduce timer

        minutes = (int)(totalTime / 60);
        seconds = (int)(totalTime % 60);

        ClockText.text = minutes.ToString() + " : " + seconds.ToString();
    }

    //TO DO
    /*
     * Format out Number of flowers minus the number of dead out of number of flowers, so (3/6)
     * 
     * Display formated text out to a text object
     * 
     * code cleaning
     * 
     * Array Creates flowers
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     */
}

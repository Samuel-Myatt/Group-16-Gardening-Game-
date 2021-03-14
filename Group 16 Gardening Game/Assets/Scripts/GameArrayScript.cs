using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameArrayScript : MonoBehaviour
{
    public GameObject[] FlowerArray;//creates an array of objects, set in unity. Drag all flowers into here

    private int NumberDead = 0;// Records number of dead flowers

    private int NumberOfFlowers;// Number of flowers in total

    public Text text;//assign the text to number of flowers to

    void Start()
    {
        foreach (GameObject o in FlowerArray) // for each flower in the array
        {
            NumberOfFlowers++;// Add to number of flowers
            Debug.Log("Flower noticed" + NumberOfFlowers.ToString()); // debug
        }

    }
    // Update is called once per frame
    void Update()
    {
        NumberDead = 0; // resets the variable so we have a live reading at all times
        foreach (var Dead in FlowerArray)// for every flower in the array
        {
            if (Dead.GetComponent<FlowerScript>().IsDead)// get the IsDead variable from the current flower
            {
                Debug.Log(NumberDead.ToString());// debug
                NumberDead++;//increase number of dead

            }
        }
        text.text = (NumberOfFlowers - NumberDead).ToString() + "/" + NumberOfFlowers.ToString();
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

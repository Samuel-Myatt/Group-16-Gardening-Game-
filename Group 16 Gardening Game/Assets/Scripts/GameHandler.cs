using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//This Script Handles the game loop

public class GameHandler : MonoBehaviour
{

    //Flower Vars
    private GameObject[] Flowers; //Created GameObject Array Flowers 
    private int NumberOfFlowers; // Number of flowers in total
    private int NumberDead = 0; // Records number of dead flowers
    public int FlowersRequired;

    //Clock Vars
    public float totalTime; // the timer length
    private float minutes;//as it says
    private float seconds;

    //UI Vars 
    public Text FlowerText;
    public Text ClockText;
    public Text StunText;
    public Text Score;

    //Level Loader Vars
    public int CurrentLevel;
    private int NextLevel;
    public static bool GameIsOver;
    public GameObject EndMenuUIWin;
    public GameObject EndMenuUILose;

    void Start()
    {
        FindFlowers();
        DontDestroyOnLoad(gameObject);
        NextLevel = CurrentLevel + 1;

    }
    // Update is called once per frame
    void Update()
    {
        Clock();
        FlowerCheck();
       // ClockCheck();
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
                //Debug.Log(NumberDead.ToString());// debug
                NumberDead++;//increase number of dead

            }
        }
        FlowerText.text = (NumberOfFlowers - NumberDead).ToString() + "/" + NumberOfFlowers.ToString();
    }

    void Clock()
    {
        if (totalTime >= 0)
        {
            totalTime -= Time.deltaTime; // reduce timer
        }
        else
        {
            StartCoroutine(ClockCheck());
        }

        minutes = (int)(totalTime / 60);
        seconds = (int)(totalTime % 60);

        ClockText.text = minutes.ToString() + " : " + seconds.ToString();

    }


    IEnumerator ClockCheck()
    {

        if((NumberOfFlowers - NumberDead) >= FlowersRequired)
        {
            //Win the level
            EndMenuUIWin.SetActive(true);
           // Time.timeScale = 0f;
            //LoadScene();
        }
        else
        {
            //Lose the level
            EndMenuUILose.SetActive(true);
            //Time.timeScale = 0f;
            //LoadScene();
        }  
        yield return null; 
    }

    //ORIGINAL CLOCK CHECK

    /*void ClockCheck()
    {
        if(totalTime <= 0)
        {
            //Timer is up
            if((NumberOfFlowers - NumberDead) >= FlowersRequired)
            {
                //Win the level
                LoadScene();
            }
            else
            {

            }
            //Lose the level   
        }
    }
    */

    public void LoadScene()
    {
        SceneManager.LoadScene(NextLevel);
        CurrentLevel = NextLevel;
        NextLevel++;
    }

    public void ReLoadScene()
    {
        
        SceneManager.LoadScene(CurrentLevel);
    }

    //TO DO
    /*
     * Format out Number of flowers minus the number of dead out of number of flowers, so (3/6)
     * 
     * Dis.y formated text out to a text object
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

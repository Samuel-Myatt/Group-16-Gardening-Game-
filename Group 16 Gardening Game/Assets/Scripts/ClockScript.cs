using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ClockScript : MonoBehaviour
{

    public float totalTime; // the timer length

    public Text text;//assign the text to draw the clock to 

    private float minutes;//as it says
    private float seconds;

    // Update is called once per frame
    void Update()
    {
        totalTime -= Time.deltaTime; // reduce timer

        minutes = (int)(totalTime / 60);
        seconds = (int)(totalTime % 60);

        text.text = minutes.ToString() + " : " + seconds.ToString();
    }
}
 
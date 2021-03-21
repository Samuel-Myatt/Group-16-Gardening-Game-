using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bees : MonoBehaviour
{
    public float speed;
    private float waitTime;
    public float startWaitTime;

    public Transform[] moveSpots;//array of spots bees can move between
    private int randomSpot;

    void Start()
    {
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);

    }

    void Update()
    {   //moves bees position to random spot in the array
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);


        //if the bees are with 0.2 of their target location
        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {

            if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);//new random location
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            StartCoroutine(collider.GetComponent<PlayerController>().stunPlayer(1.0f));
        }
    }
}
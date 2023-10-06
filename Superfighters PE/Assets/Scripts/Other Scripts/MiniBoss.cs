using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBoss : MonoBehaviour
{
    public float speed;

    public Transform[] moveSpots;
    private int randomSpot;

    private float waitTime;
    public float startWaitTime;

    void Start()
    {
        randomSpot = Random.Range(0, moveSpots.Length);
        waitTime = startWaitTime;
    }

    
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.1f); 
        {
            if (waitTime <= 0 )
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
}
 
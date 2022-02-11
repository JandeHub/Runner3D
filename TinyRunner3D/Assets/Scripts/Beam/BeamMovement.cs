using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamMovement : MonoBehaviour
{
    [SerializeField] private float beamSpeed;
    [SerializeField] private float startWaitTime;
    [SerializeField] private Transform[] moveSpots;


    private float waitTime;
    private int i = 0;

    void Start()
    {
        waitTime = startWaitTime;
    }

    void Update()
    {
        //MoveBeam// -----------------------------------------------------
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[i].transform.position, beamSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpots[i].transform.position) < 2.0f)
        {
            if (waitTime <= 0)
            {
                if (moveSpots[i] != moveSpots[moveSpots.Length - 1])
                {
                    i++;
                }
                else
                {
                    i = 0;
                }
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatherFollower : MonoBehaviour
{
    public Transform Robot;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Robot.position / 0.5f ;
    }
}

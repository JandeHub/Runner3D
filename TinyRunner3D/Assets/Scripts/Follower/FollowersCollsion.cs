using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FollowersCollsion : Runner3DCollision
{

    public event Action CreateRobot = delegate { };

    protected override void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Robot"))
        {
            CreateRobot();
            Destroy(gameObject);
            HealthSystem.followers++;
        }
        
    }
}

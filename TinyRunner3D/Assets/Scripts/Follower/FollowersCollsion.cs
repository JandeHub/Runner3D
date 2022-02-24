using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FollowersCollsion : Runner3DCollision
{

    public event Action CreateRobot = delegate { };

    protected override void OnTriggerEnter(Collider collision)
    {
        //var fatherPosition = fatherFollower.transform.position;
        //gameObject.transform.parent = fatherFollower.transform;
        //gameObject.transform.position = new Vector3(fatherPosition.x, fatherPosition.y, -fatherPosition.z * -1.1f);
        CreateRobot();
        //Destroy(gameObject);
        HealthSystem.followers++;
        
    }
}

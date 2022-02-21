using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SceneCollision : Runner3DCollision
{

    protected override void OnCollisionEnter(Collision collision)
    {
        
        HealthSystem.died = true; 
        
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawCollision : Runner3DCollision
{
   protected override void OnTriggerEnter(Collider collision)
    {

        HealthSystem.died = true;

    }
}

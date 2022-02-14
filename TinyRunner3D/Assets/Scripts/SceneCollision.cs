using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneCollision : Runner3DCollision
{
    protected override void OnTriggerEnter(Collider collision)
    {
        HealthSystem.died = true;
    }
}


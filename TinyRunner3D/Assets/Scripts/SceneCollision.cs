using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SceneCollision : Runner3DCollision
{
    private CameraShake _camera;

    private void Awake()
    {
        _camera = GetComponent<CameraShake>();
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        GameObject.Find("Main Camera").GetComponent<CameraShake>().Shake(0.5f, 4f);
        HealthSystem.died = true; 
        
    }
}


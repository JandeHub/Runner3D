using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BombSystem : MonoBehaviour
{
    private float delay = 3f;

    private float countdown;
    private bool exploded = false;

    public CameraShake _cameraShake;

    public event Action Explosion = delegate { };
    private void Start()
    {
        countdown = delay;
        
    }

    private void Update()
    {
        countdown -= Time.deltaTime;
        if(countdown <= 0f && !exploded)
        {
            Explosion();
            exploded = true;
        }
    }
}

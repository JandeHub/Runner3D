using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class FinishLevelCollision : Runner3DCollision
{
    
    public event Action LevelSurpass = delegate { };
    protected override void OnTriggerEnter(Collider collision)
    {
        LevelSurpass();
        
    }
    
}

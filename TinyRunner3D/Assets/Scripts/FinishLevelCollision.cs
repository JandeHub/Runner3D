using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishLevelCollision : Runner3DCollision
{
    [SerializeField] private GameObject FinishLevelCanvas;
    protected override void OnCollisionEnter(Collision collision)
    {
        FinishLevelCanvas.SetActive(true);
    }
    
}

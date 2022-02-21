using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputSystemKeyboard : MonoBehaviour
{
    
    
    public float hor { get; private set; }
    public float ver { get; private set; }

    public event Action AddFollower = delegate { }; 
    public event Action RemoveFollower = delegate { };
    public event Action ConvertMini = delegate { };

  
    void Update()
    {
        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.Space))
            ConvertMini();

        if (Input.GetKeyDown(KeyCode.O))
            AddFollower();

        if (Input.GetKeyDown(KeyCode.P))
            RemoveFollower();

        



    }
}

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
    public event Action OnPause = delegate { };


    void Update()
    {
        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
            ConvertMini();

        if (Input.GetKeyDown(KeyCode.O))
            AddFollower();

        if (Input.GetKeyDown(KeyCode.P))
            RemoveFollower();

        if (Input.GetKeyDown(KeyCode.Escape))
            OnPause();






    }
}

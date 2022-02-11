using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputSystemKeyboard : MonoBehaviour
{
    
    
    public float hor { get; private set; }
    public float ver { get; private set; }

    //Evento creado, se utiliza "delegate" para decir que esa linea de codigo es un evento
    public event Action AddFollower = delegate { }; //OnFire puede ser cualquier nombre
    public event Action RemoveFollower = delegate { };

  
    void Update()
    {
        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.O))
            AddFollower();

        if (Input.GetKeyDown(KeyCode.P))
            RemoveFollower();

    }
}

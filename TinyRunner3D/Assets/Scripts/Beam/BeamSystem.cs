using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BeamSystem : MonoBehaviour
{

    private LineRenderer _line;

    public event Action ReduceFollower = delegate { };

    private void Awake()
    {
        _line = GetComponent<LineRenderer>();
    }
    void Start()
    {


    }


    void Update()
    {
        //BeamDistance// ---------------------------------------------------
        _line.SetPosition(0, transform.position);
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider)
            {
                _line.SetPosition(1, hit.point);

               if (hit.collider.CompareTag("RobotFollowers"))
               {
                        Debug.Log("Hitted");
                        
               }


            }
        }
        else
        {
            _line.SetPosition(1, transform.forward * 100);
        }
        
    }
}

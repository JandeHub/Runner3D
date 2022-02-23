using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class NavMeshRobot : MonoBehaviour
{
    public GameObject myTarget;
    public NavMeshAgent myAgent;

    void Start()
    {
        if (myTarget == null)
        {
            myTarget = GameObject.FindGameObjectWithTag("Robot");
        }
        
    }


    void Update()
    {
        if (myTarget != null)
        {
            myAgent.destination = myTarget.transform.position;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowersSystem : MonoBehaviour
{
    public GameObject myTarget;
    public NavMeshAgent myAgent;
    void OnEnable()
    {
        GetComponent<FollowersCollsion>().FollowRobot += FollowsRobot;
    }
    void OnDisable()
    {
        GetComponent<FollowersCollsion>().FollowRobot -= FollowsRobot;
    }

    void Start()
    {
        
    }
    void Update()
    {
        /*(myTarget != null)
        {
            myAgent.destination = myTarget.transform.position;
        }*/
    }

    void FollowsRobot()
    {
        myAgent.destination = myTarget.transform.position / 2;
    }
}

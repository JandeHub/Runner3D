using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class NavMeshRobot : MonoBehaviour
{
    public GameObject myTarget;
    public NavMeshAgent myAgent;

    //private bool followingPlayer;

    /*void OnEnable()
    {
        GetComponent<FollowersCollsion>().CreateRobot += FollowsRobot;
    }
    void OnDisable()
    {
        GetComponent<FollowersCollsion>().CreateRobot -= FollowsRobot;
    }*/

    void Start()
    {
        //followingPlayer = false;
        if (myTarget == null)
        {
            myTarget = GameObject.FindGameObjectWithTag("Robot");
        }
        
    }

    /*void FollowsRobot()
    {

        followingPlayer = true;
    }*/


    void Update()
    {
        if (CreateFollowers.followingPlayer)
        {
            if (myTarget != null)
            {
                myAgent.destination = myTarget.transform.position;
            }
        }
    }

}

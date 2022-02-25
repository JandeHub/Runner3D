using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class NavMeshRobot : MonoBehaviour
{
    private bool followingPlayer = false;
    [SerializeField]private GameObject myTarget;
    [SerializeField]private NavMeshAgent myAgent;
    [SerializeField]private ParticleSystem dust;

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
        if (myTarget == null)
        {
            myTarget = GameObject.FindGameObjectWithTag("Robot");
        }
        
    }

    void FollowsRobot()
    {

        followingPlayer = true;
        FindObjectOfType<AudioManager>().Play("PickUpButter");
    }


    void Update()
    {
        if (followingPlayer)
        {
            if (myTarget != null)
            {
                myAgent.destination = myTarget.transform.position;
                dust.Play();
            }
        }
    }

}

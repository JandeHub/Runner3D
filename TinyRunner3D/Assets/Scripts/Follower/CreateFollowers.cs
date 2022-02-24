using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class CreateFollowers : MonoBehaviour
{
    public Transform fatherPosition;
    public GameObject myTarget;
    public NavMeshAgent myAgent;

    public bool followingPlayer = false;
    private PooledItems pooling;

    void OnEnable()
    {
        GetComponent<FollowersCollsion>().CreateRobot += FollowsRobot;
    }
    void OnDisable()
    {
        GetComponent<FollowersCollsion>().CreateRobot -= FollowsRobot;
    }

    void FollowsRobot()
    {

        followingPlayer = true;
        /*GameObject butterRobot = PoolingManager.Instance.GetPooledObject("ButterRobot");
        if(butterRobot != null)
        {
            butterRobot.transform.position = fatherPosition.position;
            butterRobot.SetActive(true); 

        }*/

        
    }
    private void Update()
    {
      
            if (myTarget != null)
            {
                
                //Debug.Log("Siguiendo Player");
                myAgent.SetDestination(myTarget.transform.position);
            }
        
    }
}

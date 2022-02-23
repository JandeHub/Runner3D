using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CreateFollowers : MonoBehaviour
{
    public Transform fatherPosition;
    public GameObject myTarget;
    public UnityEngine.AI.NavMeshAgent myAgent;

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
        /*GameObject butterRobot = PoolingManager.Instance.GetPooledObject("ButterRobot");
        if(butterRobot != null)
        {
            butterRobot.transform.position = fatherPosition.position;
            butterRobot.SetActive(true); 

        }*/

        if (myTarget != null)
        {
            myAgent.destination = myTarget.transform.position;
        }


    }
}

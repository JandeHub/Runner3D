using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class CreateFollowers : MonoBehaviour
{
    public static bool followingPlayer = false;
    public Transform fatherPosition;


    private PooledItems pooling;

    void FollowsRobot()
    {
        followingPlayer = true;
        GameObject butterRobot = PoolingManager.Instance.GetPooledObject("ButterRobot");
        if(butterRobot != null)
        {
            butterRobot.transform.position = fatherPosition.position;
            butterRobot.SetActive(true); 

        }

    }
    
}

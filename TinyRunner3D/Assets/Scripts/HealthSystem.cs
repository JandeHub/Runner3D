using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthSystem : MonoBehaviour
{
    //[SerializeField] private int maxHealth;

    public static int followers;
    public static bool died;

    public event Action ReduceUI = delegate { };

    private Animator _anim;

    void OnEnable()
    {
        GetComponent<BeamSystem>().ReduceFollower += ReduceFollowers;
    }
    void OnDisable()
    {
        GetComponent<BeamSystem>().ReduceFollower -= ReduceFollowers;
    }

    void Start()
    {
        _anim = GetComponent<Animator>();
        died = false;

        followers = 0;
    }

    void Update()
    {
        if(followers < 0)
        {
            
            died = true;
        }

        
    }

    void ReduceFollowers()
    {
        followers--;
        Debug.Log(followers);
    }


}

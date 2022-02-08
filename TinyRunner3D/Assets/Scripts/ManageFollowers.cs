using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageFollowers : MonoBehaviour
{
    [SerializeField] private GameObject followers;
    [SerializeField] private Transform spawnFollower;

    private GameObject createdFollower;

    

    private InputSystemKeyboard _input;

    void OnEnable()
    {
        GetComponent<InputSystemKeyboard>().AddFollower += AddFollowers;
        GetComponent<InputSystemKeyboard>().RemoveFollower += RemoveFollowers;
    }
    void OnDisable()
    {
        GetComponent<InputSystemKeyboard>().AddFollower -= AddFollowers;
        GetComponent<InputSystemKeyboard>().RemoveFollower += RemoveFollowers;
    }

    void Start()
    {
        _input = GetComponent<InputSystemKeyboard>();
    }

    
    void AddFollowers()
    {
        
        createdFollower = Instantiate(followers, spawnFollower.position , spawnFollower.rotation);
        followers.transform.SetParent(spawnFollower);
    }

    void RemoveFollowers()
    {
        if(createdFollower == null)
        {
            GameObject.FindGameObjectsWithTag("Followers");
        }
        
        Destroy(createdFollower);
    }
}

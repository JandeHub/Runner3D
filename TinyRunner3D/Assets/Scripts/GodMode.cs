using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodMode : MonoBehaviour
{
    [SerializeField] private GameObject followers;
    [SerializeField] private Transform fatherFollower;

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
        var fatherPosition = fatherFollower.transform.position;
        createdFollower = Instantiate(followers, fatherFollower.position, fatherFollower.rotation);
        createdFollower.transform.parent = fatherFollower.transform;
        createdFollower.transform.position = new Vector3(fatherPosition.x, fatherPosition.y, fatherPosition.z * -2 / 2);
    }

    void RemoveFollowers()
    {
        GameObject.FindGameObjectsWithTag("Followers");
        
        
        Destroy(createdFollower);
    }
}

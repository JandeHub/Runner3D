using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatherFollower : MonoBehaviour
{
    public Transform Robot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Robot.position * Time.deltaTime;
    }
}

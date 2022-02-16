using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    [SerializeField] private Transform target;

    [SerializeField] private float cameraSpeed;
    [SerializeField] private Vector3 cameraOffset;

    
    void Start()
    {
        if (target == null)
        {
            target = GameObject.FindWithTag("Robot").transform;
        }
    }

 
    void LateUpdate()
    {
        transform.position = target.position + cameraOffset;
    }
}

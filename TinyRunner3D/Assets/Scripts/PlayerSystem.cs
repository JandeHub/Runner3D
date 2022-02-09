using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSystem : MonoBehaviour
{
    [SerializeField] private float forwardPlayerSpeed;
    [SerializeField] private float sidePlayerSpeed;
    

    private Vector3 direction;
    

    private Rigidbody _rb;
    private InputSystemKeyboard _input;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _input = GetComponent<InputSystemKeyboard>();
    }

    void Update()
    {
        direction.z = forwardPlayerSpeed;
        direction.x = _input.hor * sidePlayerSpeed;

    
            transform.Translate(direction * Time.deltaTime, Space.World);
     
        
    }


}

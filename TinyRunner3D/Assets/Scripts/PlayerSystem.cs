using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSystem : MonoBehaviour
{
    [SerializeField] private float forwardPlayerSpeed;
    [SerializeField] private float sidePlayerSpeed;

    private Vector3 direction;
    

    private CharacterController _controller;
    private InputSystemKeyboard _input;
    
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _input = GetComponent<InputSystemKeyboard>();
    }

    void Update()
    {
        direction.z = forwardPlayerSpeed;
        direction.x = _input.hor * sidePlayerSpeed;
        
        
    }


    void FixedUpdate()
    {
        _controller.Move(direction * Time.deltaTime);
    }
}

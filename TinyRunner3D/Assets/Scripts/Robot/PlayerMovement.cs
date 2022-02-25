using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement: MonoBehaviour
{
    [SerializeField] private float forwardPlayerSpeed;
    [SerializeField] private float sidePlayerSpeed;

    [SerializeField] private float maxSideX;
    [SerializeField] private float minSideX;

    private float turnSpeed = 60f;
    private Vector3 direction;
    

    private Rigidbody _rb;
    private InputSystemKeyboard _input;
    
    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _input = GetComponent<InputSystemKeyboard>();

    }

    void Update()
    {
        if (!HealthSystem.died)
        {
            //ShipMovment ---------------------------------
            direction.z = forwardPlayerSpeed;
            direction.x = _input.hor * sidePlayerSpeed;

            transform.Translate(direction * Time.deltaTime, Space.World);

            //ShipRotation ---------------------------
            if(_input.hor > 0 && transform.eulerAngles.z > -35)
            {
                transform.Rotate(0, 0, -turnSpeed * Time.deltaTime );
            }
            else if(_input.hor < 0 && transform.eulerAngles.z < 35)
            {
                transform.Rotate(0, 0, turnSpeed * Time.deltaTime );
            }

            //BoundsSide ------------------------------
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minSideX, maxSideX), transform.position.y, transform.position.z);
           
        }

       


    }


}

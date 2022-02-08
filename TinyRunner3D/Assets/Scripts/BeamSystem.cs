using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamSystem : MonoBehaviour
{
    private Transform startPoint;
    private Transform endPoint;

    private LineRenderer _line;
    // Start is called before the first frame update
    void Start()
    {
        _line = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        _line.SetPosition(0, transform.position);
        RaycastHit hit;

        if(Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if(hit.collider)
            {
                _line.SetPosition(1, hit.point);
            }
        }

        else
        {
            _line.SetPosition(1, transform.forward * 200);
        }
    }
}

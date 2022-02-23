using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinitScene : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float segmentLength;

    private Vector3 basePosition;

    float offset;
    void Start()
    {
        basePosition = transform.position;
        offset = 0;
    }

    // Update is called once per frame
    void Update()
    {
        offset += speed * Time.deltaTime;

        if (offset > -segmentLength) { offset -= segmentLength; }

        transform.position = basePosition + offset * Vector3.forward;
    }
}

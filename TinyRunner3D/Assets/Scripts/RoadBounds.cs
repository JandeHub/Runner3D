using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadBounds : MonoBehaviour
{
    public static float leftSide = -20f;
    public static float rightSide = 20f;
    [SerializeField] private float internalLeft;
    [SerializeField] private float internalRight;

    private void Update()
    {
        internalLeft = leftSide;
        internalRight = rightSide;
    }
}

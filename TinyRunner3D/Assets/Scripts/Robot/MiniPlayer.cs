using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniPlayer : MonoBehaviour
{
    private Vector3 originalScale;
    private bool mini;

    void OnEnable()
    {
        GetComponent<InputSystemKeyboard>().ConvertMini += ConvertMinis;
    }
    void OnDisable()
    {
        GetComponent<InputSystemKeyboard>().ConvertMini -= ConvertMinis;
    }

    void Start()
    {
        originalScale = transform.localScale;
    }

    private void Update()
    {
        if (mini)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(originalScale.x * 0.5f, originalScale.y * 0.5f, originalScale.z * 0.5f)
                , Time.deltaTime * 7);
        }
        else
        {
            transform.localScale = Vector3.Lerp(transform.localScale, originalScale, Time.deltaTime * 7);
        }

        mini = false;
    }
    void ConvertMinis()
    {
        mini = true;
        
    }
}

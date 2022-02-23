using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniPlayer : MonoBehaviour
{
    private Vector3 originalScale;
    private bool mini;

    private float miniTimerMax = 2f;
    private float miniTimer;

    private bool canMini = true;

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

        miniTimer = miniTimerMax;
       
    }

    private void Update()
    {
        if (canMini)
        {
            if (mini)
            {
                transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(originalScale.x * 0.5f, originalScale.y * 0.5f, originalScale.z * 0.5f)
                                                    , Time.deltaTime * 20);
                miniTimer -= Time.deltaTime;
            }
            
        }
        if(!canMini)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, originalScale, Time.deltaTime * 500);
            miniTimer = miniTimerMax;
            mini = false;
            canMini = true;
            
        }
        if (miniTimer <= 0)
        {
            canMini = false;
        }

    }
    void ConvertMinis()
    {
        mini = true;
        
    }
}

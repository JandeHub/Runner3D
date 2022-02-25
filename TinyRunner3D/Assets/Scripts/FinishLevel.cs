using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishLevel : MonoBehaviour
{
    [SerializeField] private GameObject FinishLevelCanvas;
    [SerializeField] private GameObject confettiParticle;
    [SerializeField] private GameObject[] confettiSpots;

    void OnEnable()
    {
        GetComponent<FinishLevelCollision>().LevelSurpass += LevelComplete;
    }
    void OnDisable()
    {
        GetComponent<FinishLevelCollision>().LevelSurpass -= LevelComplete;
    }

    void LevelComplete()
    {
        FinishLevelCanvas.SetActive(true);

        for (int i = 0; i < confettiSpots.Length; i++)
        {
            Instantiate(confettiParticle, confettiSpots[i].transform.position, confettiSpots[i].transform.rotation);
        }

        FindObjectOfType<AudioManager>().Play("WinEffect");
    }
}

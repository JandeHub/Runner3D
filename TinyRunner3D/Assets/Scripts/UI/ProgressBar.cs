using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject finish;

    private float maxDistance;

    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
        maxDistance = finish.transform.position.z;
    }
    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Robot");
        }
        if (finish == null)
        {
            finish = GameObject.FindGameObjectWithTag("FinishLevel");
        }
    }
    void Update()
    {
        if(_image.fillAmount < 1)
        {
            _image.fillAmount = player.transform.position.z / maxDistance;
        }
    }
}

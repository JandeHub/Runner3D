using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
	public static CameraShake _instance;
    [SerializeField] private Transform cameraTransform;
	
	public static bool shake;

	private float duration;
	private float amount;
	private float decreaseFactor = 1.0f;
	private Vector3 originalPos;


	void Awake()
	{
		_instance = this;

	}

	void Start()
	{
		originalPos = cameraTransform.position;
	}

	void Update()
	{
		
			if(duration > 0)
			{

				cameraTransform.position = originalPos + Random.insideUnitSphere * amount;
				duration -= Time.deltaTime * decreaseFactor;
			}
            else
            {
				cameraTransform.position = originalPos;
				shake = false;
            }
			
		
	}
	public void Shake(float durationShake, float amountShake)
	{
		shake = true;
		duration = durationShake;
		amount = amountShake;
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{ 
	private Vector3 originalPos;


	public IEnumerator Shake(float durationShake, float amountShake)
    {
		Debug.Log("Shaked");
		originalPos = transform.localPosition;

		float time = 0.0f;

		while(time < durationShake)
        {
			float x = Random.Range(-1, 1f) * amountShake;
			float y = Random.Range(-1, 1f) * amountShake;
			float z = Random.Range(-1, 1f) * amountShake;

			transform.localPosition = new Vector3(x, y, z);

			time += Time.deltaTime;

			yield return null;

        }

		transform.localPosition = originalPos;
    }
	
}

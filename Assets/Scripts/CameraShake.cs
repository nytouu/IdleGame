using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
	public IEnumerator Shake(float duration, float intensity){
		Vector3 originalPosition = transform.position;
		
		float elapsed = 0f;

		while (elapsed < duration){
			float x = Random.Range(-1f, 1f) * intensity;
			float y = Random.Range(-1f, 1f) * intensity;

			transform.localPosition = new Vector3(x, y, originalPosition.z);

			elapsed += Time.deltaTime;

			yield return null;
		}

		transform.localPosition = originalPosition;
	}
}

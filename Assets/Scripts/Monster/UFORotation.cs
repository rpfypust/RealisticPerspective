using UnityEngine;
using System.Collections;

public class UFORotation : MonoBehaviour {
	public float rotationSpeed = 30f;

	void Update()
	{
		transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
	}
}

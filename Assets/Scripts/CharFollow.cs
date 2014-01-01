﻿using UnityEngine;
using System.Collections;

public class CharFollow : MonoBehaviour {

	public Transform target;
	public float distance = 11.0f;
	public float height = 13.0f;
	public float heightDamp = 36.0f;
	public float rotationDamp = 20.0f;
	
	void LateUpdate() {
		// early exit if the target is lost
		if (!target)
			return;
		
		float desiredHeight = target.position.y + height;
		float currentHeight = transform.position.y;
		currentHeight = Mathf.Lerp(currentHeight, desiredHeight, heightDamp * Time.deltaTime);
		
		float x = target.position.x;
		float y = currentHeight;
		float z = target.position.z - distance;
		
		transform.position = new Vector3(x, y, z);
		transform.LookAt(target);
	}
}
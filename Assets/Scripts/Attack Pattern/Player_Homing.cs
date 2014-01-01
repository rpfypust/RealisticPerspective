using UnityEngine;
using System.Collections;

public class Player_Homing : MonoBehaviour
{
	
	public float startTime = Time.time;
	public Vector3 direction;
	public float bulletSpeed = 10.0f;
	public Vector3 oriPos;
	public float lastTime = 0.0f;
	public float deltaTime = 0.0f;
	// Use this for initialization
	void FixedUpdate ()
	{
		Vector3 speed = direction*bulletSpeed;
		float cTime = Time.time - startTime;
		deltaTime = cTime - lastTime;
		rigidbody.MovePosition (rigidbody.position + speed * deltaTime);
		lastTime = cTime;
	}
}

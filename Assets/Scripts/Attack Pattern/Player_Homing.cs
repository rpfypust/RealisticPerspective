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
	private GameObject target;
	private int j = 0;
	// Use this for initialization
	void Awake ()
	{
		j = 0;
		Vector3 speed = direction * bulletSpeed;
	}

	void FixedUpdate ()
	{
		float cTime = Time.time - startTime;
		deltaTime = cTime - lastTime;
		
		if (j % 10 == 0) {
			target = GameObject.FindWithTag ("Tag_Enemy");
		if (target != null) {
			direction = (direction*15+(target.transform.position - transform.position).normalized).normalized;
		}
		}
		Vector3 speed = direction * bulletSpeed;
		
		rigidbody.MovePosition (rigidbody.position + speed * deltaTime);
		
		lastTime = cTime;
	}
}

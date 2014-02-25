using UnityEngine;
using System.Collections;

public class A01_WhileTrue_B1 : MonoBehaviour
{
	public float refTime;
	public float vx = 0.0f;
	public float vz = 0.0f;
	public float startAfter = 10.0f;
	public Vector3 oriPos;
	private float lastTime = 0.0f;
	private float deltaTime = 0.0f;
	
	void FixedUpdate ()
	{
		float cTime = Time.time - refTime;
		//deltaTime = cTime - lastTime;
		
		if(cTime >= startAfter){
			Vector3 speed = new Vector3 (vx, 0, vz);
			rigidbody.velocity = speed;
			rigidbody.useGravity = true;
			gameObject.layer = 15;
			Destroy(gameObject.GetComponent <A01_WhileTrue_B1>());
		}
		
		//lastTime = cTime;
	}
}
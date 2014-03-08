using UnityEngine;
using System.Collections;

public class CS1_0_B1 : MonoBehaviour
{

	public float startTime = Time.time;
	public float vx = 0.0f;
	public float vz = 0.0f;
	public Vector3 oriPos;
	private float lastTime = 0.0f;
	private float deltaTime = 0.0f;
	private int j = 0;

	void FixedUpdate ()
	{
		Vector3 speed = new Vector3 (vx, 0, vz);
		float cTime = Time.time - startTime;
		deltaTime = cTime - lastTime;
		
				
		
		if (cTime < 1f) {
			//rigidbody.MovePosition(oriPos + speed*(cTime - cTime * cTime /2.0));
			rigidbody.MovePosition (rigidbody.position + speed * deltaTime * (1 - cTime) / 1.0f);
		} else if (cTime < 1.5f) {
		} else if (cTime < 2.5f) {
			//var temp = cTime - 1.5f;
			//rigidbody.MovePosition(oriPos + speed*(0.5 + temp * temp /2.0));
			rigidbody.MovePosition (rigidbody.position + speed * deltaTime * (cTime - 1.5f) / 1.0f);
		} else {
			//rigidbody.MovePosition(oriPos + speed*(1 + cTime - 2.5));
			rigidbody.MovePosition (rigidbody.position + speed * deltaTime);
		}
		lastTime = cTime;
		j++;
	}
}
using UnityEngine;
using System.Collections;

public class BossRandomMoveInArea : MonoBehaviour
{
	//bullet information
	public float x1;
	public float z1;
	public float x2;
	public float z2;
	private float cx;
	private float cz;
	public float r;
	public float moveTime = 2.0f;
	public float waitTime = 3.0f;
	public float startTime = Time.time;
	public Vector3 oriPos;
	private float lastTime = 0.0f;
	private float deltaTime = 0.0f;
	public float localStartTime = 0.0f;
	private float finalPositionX = 0.0f;
	private float finalPositionZ = 0.0f;
	private Vector3 speed;
	private int k = 0;//step counter; k=0:wait;k=1:move

	void Awake()
	{
		startTime = Time.time;
		localStartTime = startTime;
		speed = Vector3.zero;
		cx = transform.position.x;
		cz = transform.position.z;
	}

	void FixedUpdate()
	{
		float cTime = Time.time - startTime;
		deltaTime = cTime - lastTime;

		if (k == 0)
		{ //wait
			if (Time.time - localStartTime > waitTime)
			{
				k = 1;
				cx = transform.position.x;
				cz = transform.position.z;
				finalPositionZ = Mathf.Max(cz - r, z1) + Random.value * (Mathf.Min(cz + r, z2) - Mathf.Max(cz - r, z1));
				float temp = Mathf.Sqrt(r * r - (finalPositionZ - cz) * (finalPositionZ - cz));
				finalPositionX = x1 - temp + Random.value * 2.0f * temp;
				localStartTime = Time.time;
				oriPos = transform.position;
			}
		} else
		{ //move
			float ratio = 4.0f / moveTime / moveTime * (moveTime / 2.0f - Mathf.Abs(Time.time - localStartTime - moveTime / 2.0f));
			speed = new Vector3((finalPositionX - oriPos.x) * ratio, 0, (finalPositionZ - oriPos.z) * ratio);
			rigidbody.MovePosition(rigidbody.position + speed * deltaTime);
			if (Time.time - localStartTime > moveTime)
			{
				localStartTime = Time.time;
				k = 0;
			}
		}

        
		lastTime = cTime;
	}
    
}
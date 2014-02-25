using UnityEngine;
using System.Collections;

public class PlayerBullet_Homing : MonoBehaviour
{
	
	public float startTime = Time.time;
	public Vector3 direction;
	public float bulletSpeed = 10.0f;
	public Vector3 oriPos;
	public float lastTime = 0.0f;
	public float deltaTime = 0.0f;
	private GameObject target;
	private Vector3 displacement;
	private Vector3 speed;
	private int j = 0;
	// Use this for initialization
	void Awake()
	{
		j = 0;
		speed = direction * bulletSpeed;
	}

	void FixedUpdate()
	{
		float cTime = Time.time - startTime;
		deltaTime = cTime - lastTime;


		if (j % 2 == 0)
		{
			target = GameObject.FindWithTag("Tag_Enemy");
			if (target != null)
			{
				displacement = target.transform.position - transform.position;
				direction = direction * Mathf.Min(Mathf.Max(3.0f, displacement.sqrMagnitude/2.0f), 7.0f) + displacement.normalized;
				direction.y = displacement.y;
				direction = direction.normalized;
			}
			speed = direction * bulletSpeed;
		}
		j++;
		
		rigidbody.MovePosition(rigidbody.position + speed * deltaTime);
		
		lastTime = cTime;
	}
}

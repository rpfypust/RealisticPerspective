using UnityEngine;
using System.Collections;

public class CS1_P2P_Computer : MonoBehaviour
{
	public GameObject BulletRed; //red\
	public GameObject BulletYellow;
	public Vector3 StageRefPoint;
	public Transform boss;
	public Transform faceTo;
	public int gx;
	public int gz;
	private float startTime = 0.0f;
	private float lastTime = 0.0f;
	private float lastStepTime = 0.0f;
	private float waitUntil = 0.0f;
	public int step = 0; //step counter

	private GameObject BulletX; //bullets are using this to be created
	
	void Awake()
	{
		startTime = Time.time;
		lastTime = 0.0f;
	}
	
	void FixedUpdate()
	{
		float cTime = Time.time - startTime;

		if (step == 0)
		{ 
			if (!gameObject.GetComponent<UniformMotionWithinTime>())
			{
				gameObject.AddComponent("UniformMotionWithinTime");
				gameObject.GetComponent<UniformMotionWithinTime>().x = transform.position.x;
				gameObject.GetComponent<UniformMotionWithinTime>().y = 0.0f;
				gameObject.GetComponent<UniformMotionWithinTime>().z = transform.position.z;
				gameObject.GetComponent<UniformMotionWithinTime>().moveTime = 1.0f;
				gameObject.GetComponent<UniformMotionWithinTime>().oriPos = transform.position;
			} else if (gameObject.GetComponent<UniformMotionWithinTime>().isFinished)
			{
				Destroy(gameObject.GetComponent<UniformMotionWithinTime>());
				step++;
				lastStepTime = cTime;
				waitUntil = Vector3.Magnitude(faceTo.position - transform.position)/9.0f;
			}
		}else if (step == 1){
			if(cTime - lastTime > 0.04f){
				BulletX = (GameObject)Instantiate(BulletRed, transform.position+new Vector3(0f,0.5f,0f), transform.rotation);

				Vector3 temp = faceTo.position - transform.position;
                temp.y = 0;
				BulletX.rigidbody.velocity = 9.0f * Vector3.Normalize(temp);
				Destroy(BulletX.gameObject, waitUntil);
				BulletX.rigidbody.useGravity = false;
				lastTime = cTime;
            }
            if(cTime - lastStepTime > 0.5f){
                step++;
				lastStepTime = cTime;
            }
		}else if (step == 2){
			if(cTime - lastStepTime > waitUntil){
				step++;
				lastStepTime = cTime;
            }
		}else if (step == 3){
			for (int i=0; i<16; i++)
			{
				float angle = (i * 22.5f + step * 0.5f) / 180.0f * Mathf.PI;
				BulletX = (GameObject)Instantiate(BulletYellow, transform.position+new Vector3(0f,0.5f,0f), transform.rotation);
				
				Vector3 temp = new Vector3(8.0f * Mathf.Sin(angle), 0, 8.0f * Mathf.Cos(angle));
				BulletX.rigidbody.velocity = temp;
				Destroy(BulletX.gameObject, 8.0f);
				BulletX.rigidbody.useGravity = false;
			}
			Destroy(gameObject);
			if(boss.GetComponent<CS1_P2P>()){
				boss.GetComponent<CS1_P2P>().g[gx,gz] = 0;
			}
		}
	}
}
using UnityEngine;
using System.Collections;

public class Boss_Test : MonoBehaviour
{
	public GameObject Bullet;
	public float PowerZ = 10.0f;
	private float startTime = 0.0f;
	private float lastTime = 0.0f;
	private float lastTime2 = 0.0f;
	private int j = 0;

	void Awake ()
	{
		startTime = Time.time;
		j = 0;
	}

	void FixedUpdate ()
	{
		//if(_11_Trigger_MagicStage.FireStatus == true)
		//{
	
		GameObject BulletX;
		if ((Time.time - lastTime) > 1 / 25.0f) {
			float temp = Mathf.Sin (Time.frameCount / 50.0f);
			float angle = (temp * 1640.0f + 90.0f) / 180.0f * Mathf.PI;
			float result = PowerZ;
			for (int i=0; i<6; i++) {
				angle = Mathf.PI / 36.0f * (i * 6f + j) + j / 100.0f;
				BulletX = (GameObject)Instantiate(Bullet, transform.position, transform.rotation);
				BulletX.gameObject.AddComponent("A01_B1");
				BulletX.gameObject.GetComponent<A01_B1>().startTime = Time.time;
				BulletX.gameObject.GetComponent<A01_B1>().vx = result * Mathf.Sin (angle);// * Mathf.Sin (angle));
				BulletX.gameObject.GetComponent<A01_B1>().vz = -result * Mathf.Cos (angle);// * Mathf.Cos (angle));
				BulletX.gameObject.GetComponent<A01_B1>().oriPos = transform.position;
				BulletX.rigidbody.useGravity = false;
				j++;
			}
			lastTime = Time.time;
			transform.position=transform.position+new Vector3(0.8f*Mathf.Cos(angle/8f),0,0);
		}
		/*if((Time.time-lastTime)>1/25.0)
		{
			var angle = (temp*1640.0 +90.0)/180.0*Mathf.PI;
			var result = PowerZ;
			for(i=0;i<6;i++){
				angle = Mathf.PI/36.0*(i*6+j) + j/100.0;
				BulletX = Instantiate(Bullet, transform.position, transform.rotation);
				BulletX.gameObject.AddComponent("A01_B1");
				BulletX.gameObject.GetComponent("A01_B1").startTime = Time.time;
				BulletX.gameObject.GetComponent("A01_B1").vx = result * Mathf.Cos(angle);
				BulletX.gameObject.GetComponent("A01_B1").vz = result * Mathf.Sin(angle);
				BulletX.gameObject.GetComponent("A01_B1").oriPos = transform.position;
				BulletX.useGravity = false;
				j++;
			}
			lastTime = Time.time;
    		//AxeA.detectCollisions = false;
    		
			//audio.PlayOneShot(ThrowerSound);
		}
		if((Time.time-lastTime2)>1/2.5)
		{
			var direction = GameObject.Find("CharacterController").transform.position - transform.position;
			direction = direction/direction.magnitude;
			for (k=-4;k<=4;k++){
				BulletX = Instantiate(Bullet, transform.position, transform.rotation);
				BulletX.velocity = Quaternion.AngleAxis(k*15, Vector3.up) * (direction * 4.0);
				BulletX.useGravity = false;
			}
			lastTime2 = Time.time;
		}*/
		//}
	}
		
}
//script RequireComponent(AudioSource)
using UnityEngine;
using System.Collections;

public class PH1_Phoenix_StoneExplode : MonoBehaviour
{
	public float startTime = Time.time;
	public GameObject Bullet;
    public float waitTime;
	private float lastTime = 0.0f;
	private GameObject BulletX; //bullets are using this to be created
    
    void FixedUpdate()
    {
        float cTime = Time.time - startTime;
        if(cTime > waitTime){
			for (int i=0; i<120; i++)
			{
				float angle = (i / 120f) * 2f * Mathf.PI;
				BulletX = (GameObject)Instantiate(Bullet, transform.position + new Vector3(0f,0.5f,0f), transform.rotation);
				
				Vector3 temp = new Vector3(12.0f * Mathf.Sin(angle), 0f, 12.0f * Mathf.Cos(angle));
				BulletX.rigidbody.velocity = temp;
				Destroy(BulletX.gameObject, 8.5f);
				BulletX.rigidbody.useGravity = false;
            }
            Time.timeScale = 1f;
            Destroy(gameObject);
		}
    }
}
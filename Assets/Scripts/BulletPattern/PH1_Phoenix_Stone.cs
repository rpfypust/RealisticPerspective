using UnityEngine;
using System.Collections;

public class PH1_Phoenix_Stone : MonoBehaviour
{
	public float startTime = Time.time;
	public GameObject Bullet;
	public float circleSize;
    public float shootInterval;
	private int j = 0;
	private float lastTime = 0.0f;
    private GameObject BulletX; //bullets are using this to be created
    private SEManager sem;
    
    void Awake()
    {
        sem = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<SEManager>();
    }
    
    void FixedUpdate()
    {
        float cTime = Time.time - startTime;
        if(cTime - lastTime > shootInterval){
            sem.PlaySoundEffect(2);
			for (int i=0; i<circleSize; i++)
			{
				float angle = ((i + j/3f)/ circleSize + j *0.1f) * 2f * Mathf.PI;
				BulletX = (GameObject)Instantiate(Bullet, transform.position + new Vector3(0f,0.5f,0f), transform.rotation);
				
				Vector3 temp = new Vector3(8.0f * Mathf.Sin(angle), 0f, 8.0f * Mathf.Cos(angle));
				BulletX.rigidbody.velocity = temp;
				Destroy(BulletX.gameObject, 8.5f);
				BulletX.rigidbody.useGravity = false;
			}
			j++;
			lastTime = cTime;
		}
    }
}
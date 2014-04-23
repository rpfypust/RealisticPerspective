using UnityEngine;
using System.Collections;

public class PH1_1 : Character
{
    public GameObject BulletRed; //red
    public GameObject BulletWhite; //white
    
    public Vector3 StageRefPoint;
    private float startTime = 0.0f;
    private float lastTime = 0.0f;
    public int j = 0; //angle/bullet counter
    public int step = 0; //step counter
    
	private GameObject BulletX; //bullets are using this to be created
	private SEManager sem;
	
	void Awake(){
		sem = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<SEManager>();
        startTime = Time.time;
		MaxHealthPoint = 1000.0f;
        HealthPoint = 1000.0f;
    }
    
    void OnDestroy()
    {
    }
    
    void FixedUpdate()
    {
        if (step == 0)
        {
            if ((Time.time - lastTime) > 1 / 5.0f)
			{
				sem.PlaySoundEffect(2);
                for (int i=0; i<90; i++)
                {
                    float angle = (i * 4f + j * 1f) / 180.0f * Mathf.PI;
                    BulletX = (GameObject)Instantiate(BulletRed, transform.position, transform.rotation);
                    
                    Vector3 temp = new Vector3(14.0f * Mathf.Sin(angle), 0, 14.0f * Mathf.Cos(angle));
                    BulletX.rigidbody.velocity = temp;
                    Destroy(BulletX.gameObject, 6.0f);
                    BulletX.rigidbody.useGravity = false;
                }
                lastTime = Time.time;
                j++;
            }
            if (j == 1)
            {
                step++;
            }
        } else if (step == 1)
        {
            if ((Time.time - lastTime) > 1.0f)
            {
                lastTime = Time.time;
                step++;
            }
        } else
		{
			sem.PlaySoundEffect(2);
            for (int i=0; i<=1; i++)
            {
                float angle = Random.value * 2.0f * Mathf.PI;
                float speed = Random.value * 10.0f + 8.0f;
                BulletX = (GameObject)Instantiate(BulletWhite, transform.position, transform.rotation);
                BulletX.rigidbody.velocity = new Vector3(speed * Mathf.Sin(angle), 0.0f, speed * Mathf.Cos(angle));
                Destroy(BulletX.gameObject, 6.0f);
                BulletX.rigidbody.useGravity = false;
            }
        }
    }
}
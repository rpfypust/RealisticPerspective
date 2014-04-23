using UnityEngine;
using System.Collections;

public class PH1_8 : Character
{
    public GameObject BulletRed;
    public GameObject BulletWhite;
    public Vector3 StageRefPoint;
    private float startTime = 0.0f;
    private float lastTime = 0.0f;
    public int j = 0; //angle/bullet counter
    public int step = 0; //step counter
	private GameObject BulletX; //bullets are using this to be created
	private SEManager sem;
	
	void Awake()
	{
		sem = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<SEManager>();
		startTime = Time.time;
		MaxHealthPoint = 1900.0f;
        HealthPoint = 1900.0f;
    }
    
    void OnDestroy()
    {
    }
    
    void FixedUpdate()
    {
        if (step == 0)
        {
            if ((Time.time - lastTime) > 1 / 7.0f)
			{
				sem.PlaySoundEffect(2);
                for (int i=0; i<90; i++)
                {
                    float angle = (i * 4f + j * 1f) / 180.0f * Mathf.PI;
                    BulletX = (GameObject)Instantiate(BulletRed, transform.position, transform.rotation);
                    
                    Vector3 temp = new Vector3(10.0f * Mathf.Sin(angle), 0, 10.0f * Mathf.Cos(angle));
                    BulletX.rigidbody.velocity = temp;
                    Destroy(BulletX.gameObject, 6.0f);
                    BulletX.rigidbody.useGravity = false;
                }
                lastTime = Time.time;
                j++;
            }
            if (j == 8)
            {
                step++;
            }
        } else if (step == 1)
        {
            if ((Time.time - lastTime) > 0.2f)
            {
                j = 0;
                step++;
            }
        } else if (step == 2)
        {
            if ((Time.time - lastTime) > 0.5f)
			{
				sem.PlaySoundEffect(2);
                for (int i=0; i<60; i++)
                {
                    float angle = (i * 6f + j * 1f) / 180.0f * Mathf.PI;
                    BulletX = (GameObject)Instantiate(BulletWhite, transform.position + new Vector3(0f,Mathf.Sin((i+j)/4f*Mathf.PI) * 0.5f +0.5f,0f), transform.rotation);
                    
                    Vector3 temp = new Vector3(3.0f * Mathf.Sin(angle), 0, 3.0f * Mathf.Cos(angle));
                    BulletX.rigidbody.velocity = temp;
                    Destroy(BulletX.gameObject, 10.0f);
                    BulletX.rigidbody.useGravity = false;
                }
                lastTime = Time.time;
                j++;
            }
        }
    }
}
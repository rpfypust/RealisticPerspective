using UnityEngine;
using System.Collections;

public class PH1_3 : Character
{
    public GameObject BulletRed;
    public GameObject BulletYellow;
    public Vector3 StageRefPoint;
    private float startTime = 0.0f;
    private float lastTime = 0.0f;
    public int j = 0; //angle/bullet counter
    public float hole = 0;
    public int step = 0; //step counter
    
    private GameObject BulletX; //bullets are using this to be created
    private GameObject LaserX; //bullets are using this to be created
	
	private SEManager sem;
	
	void Awake()
	{
		sem = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<SEManager>();
		startTime = Time.time;
		MaxHealthPoint = 800.0f;
        HealthPoint = 800.0f;
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
                    
                    Vector3 temp = new Vector3(13.0f * Mathf.Sin(angle), 0, 13.0f * Mathf.Cos(angle));
                    BulletX.rigidbody.velocity = temp;
                    Destroy(BulletX.gameObject, 6.0f);
                    BulletX.rigidbody.useGravity = false;
                }
                lastTime = Time.time;
                j++;
            }
            if (j == 3)
            {
                step++;
            }
        } else if (step == 1)
        {
            if ((Time.time - lastTime) > 0.5f)
            {
                hole = 240f;
                j = 0;
                step++;
            }
        } else if (step == 2)
        {
            if ((Time.time - lastTime) > 1.5f)
			{
				sem.PlaySoundEffect(2);
                for (int i=0; i<120; i++)
                {
                    float angle = (i * 3f + Random.value) / 180.0f * Mathf.PI;
                    if ((Mathf.Abs(i * 3f - hole) > 10f) && (Mathf.Abs(i * 2f - hole) < 350f))
                    {
                        BulletX = (GameObject)Instantiate(BulletYellow, transform.position + new Vector3(0f, j, 0f), transform.rotation);
                        BulletX.particleSystem.startSize = 2.0f;
                        Vector3 temp = new Vector3(7.0f * Mathf.Sin(angle), 0, 7.0f * Mathf.Cos(angle));
                        BulletX.rigidbody.velocity = temp;
                        Destroy(BulletX.gameObject, 6.5f);
						BulletX.rigidbody.useGravity = false;
						BulletX.GetComponent<EnemyBullet>().damage = 4.0f;
                    }
                }
                j++;
                if (j == 3)
                {
                    lastTime = Time.time;
                    j = 0;
                    if (Random.value < 0.15f)
                    {
                        hole += 17f - Random.value * 5f;
                    } else if (Random.value < 0.95f)
                    {
                        hole -= 17f - Random.value * 5f;
                    }
					if (hole >360f){
						hole -=360f;
					}else if (hole <0f){
						hole +=360f;
					}
                }
            }
        }
    }
}
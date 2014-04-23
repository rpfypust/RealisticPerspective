using UnityEngine;
using System.Collections;

public class PH1_2 : Character
{
    public GameObject BulletRed;
    public GameObject BulletWhite;
    public GameObject BulletYellow_Big;
    public GameObject LaserPurple;
    public Vector3 StageRefPoint;
    private float startTime = 0.0f;
    private float lastTime = 0.0f;
    public int j = 0; //angle/bullet counter
	public int step = 0; //step counter
    
    private GameObject BulletX; //bullets are using this to be created
	private GameObject LaserX; //bullets are using this to be created
	private SEManager sem;
    
    void Awake()
	{
		sem = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<SEManager>();
		startTime = Time.time;
		MaxHealthPoint = 1500.0f;
        HealthPoint = 1500.0f;
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
            if (j == 2)
            {
                step++;
            }
        } else if (step == 1)
        {
            if ((Time.time - lastTime) > 0.5f)
            {
                j = -1;
                step++;
            }
        } else if (step == 2)
        {
            if ((Time.time - lastTime) > 1.3f)
			{
				sem.PlaySoundEffect(1);
                LaserX = (GameObject)Instantiate(LaserPurple, transform.position, transform.rotation);
                LaserX.AddComponent("PH1_2_Laser");
                LaserX.GetComponent<PH1_2_Laser>().angle = 180.0f * j;
                LaserX.GetComponent<PH1_2_Laser>().maxLength = 100.0f;
                LaserX.GetComponent<PH1_2_Laser>().duration = 1.8f;
                LaserX.transform.Rotate(0.0f, (j + 1) * 90f, 0.0f);
                lastTime = Time.time;
                j += 2;
            }
            if (j == 3)
            {
                step++;
            }
        } else if (step == 3)
        {
            if ((Time.time - lastTime) > 0.5f)
            {
                j = 0;
                step++;
            }
        } else if (step == 4)
        {
            if ((Time.time - lastTime) > 0.15f)
			{
				sem.PlaySoundEffect(2);
                for (int i=0; i<8; i++)
                {
                    float angle = (i * 30f + j * 6.8f) / 180.0f * Mathf.PI;
                    BulletX = (GameObject)Instantiate(BulletRed, transform.position, transform.rotation);
                    
                    Vector3 temp = new Vector3(14.0f * Mathf.Sin(angle), 0, 14.0f * Mathf.Cos(angle));
                    BulletX.rigidbody.velocity = temp;
                    Destroy(BulletX.gameObject, 6.0f);
                    BulletX.rigidbody.useGravity = false;
                }

                for (int i=0; i<8; i++)
                {
                    float angle = (i * 12f - j * 16f + 180f) / 180.0f * Mathf.PI;
                    BulletX = (GameObject)Instantiate(BulletWhite, transform.position, transform.rotation);
                    
                    Vector3 temp = new Vector3(14.0f * Mathf.Sin(angle), 0, 14.0f * Mathf.Cos(angle));
                    BulletX.rigidbody.velocity = temp;
                    Destroy(BulletX.gameObject, 6.0f);
                    BulletX.rigidbody.useGravity = false;

                }
                if (j % 2 == 0)
                {
                    for (int i=0; i<4; i++)
                    {
                        float angle = (i * 90f + j * 10.6f + 180f) / 180.0f * Mathf.PI;
                        BulletX = (GameObject)Instantiate(BulletYellow_Big, transform.position+new Vector3(0f,0.2f,0f), transform.rotation);
                    
                        Vector3 temp = new Vector3(14.0f * Mathf.Sin(angle), 0, 14.0f * Mathf.Cos(angle));
                        BulletX.rigidbody.velocity = temp;
                        Destroy(BulletX.gameObject, 6.0f);
                        BulletX.rigidbody.useGravity = false;
                    }
                }
                lastTime = Time.time;
                j++;
            }
        }
    }
}
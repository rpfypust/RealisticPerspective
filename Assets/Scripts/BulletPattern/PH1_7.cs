using UnityEngine;
using System.Collections;

public class PH1_7 : Character
{
    public GameObject BulletRed;
	public GameObject BulletOrange;
    public Vector3 StageRefPoint;
    private float startTime = 0.0f;
	private float lastTime = 0.0f;
    public int j = 0; //angle/bullet counter
    public int step = 0; //step counter
	private GameObject BulletX; //bullets are using this to be created
	private int[,] pattern = {
		{0,0,0,0,1},
		{1,1,1,1,1},
		{0,1,1,0,0},
		{0,1,1,0,0},
		{1,1,1,0,0}
	};
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
                    
                    Vector3 temp = new Vector3(11.0f * Mathf.Sin(angle), 0, 11.0f * Mathf.Cos(angle));
                    BulletX.rigidbody.velocity = temp;
                    Destroy(BulletX.gameObject, 6.0f);
                    BulletX.rigidbody.useGravity = false;
                }
                lastTime = Time.time;
                j++;
            }
            if (j == 7)
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
            if ((Time.time - lastTime) > 0.05f)
			{
				sem.PlaySoundEffect(2);
                float angle = Random.value * 2.0f * Mathf.PI;
                /*BulletX = new GameObject();
                BulletX.transform.position = transform.position;
                BulletX.AddComponent("PH1_7_HorseSpawn");
                BulletX.GetComponent<PH1_7_HorseSpawn>().angle = angle;
                BulletX.GetComponent<PH1_7_HorseSpawn>().speed = 13.0f;
                BulletX.GetComponent<PH1_7_HorseSpawn>().BulletOrange = BulletOrange;*/
				/*BulletX = (GameObject)Instantiate(BulletSetHorse, transform.position, transform.rotation);
				BulletX.transform.rotation = Quaternion.Euler(new Vector3(Mathf.Sin(angle), 0.0f, Mathf.Cos(angle)));
				BulletX.AddComponent("BulletLinearMove");
				BulletX.GetComponent<BulletLinearMove>().velocity = 13.0f * new Vector3(Mathf.Sin(angle), 0.0f, Mathf.Cos(angle));
				Destroy(BulletX.gameObject, 7.0f);
				BulletX.rigidbody.useGravity = false;*/
				for (int k=0; k<5; k++)
				{
					for (int i=0; i<5; i++)
					{
						if (pattern [k, i] == 1)
						{
							Vector3 spawn = new Vector3(0f, i * 0.5f, 0f) - 0.5f * k * new Vector3(Mathf.Sin(angle), 0.0f, Mathf.Cos(angle));
							BulletX = (GameObject)Instantiate(BulletOrange, transform.position + spawn, transform.rotation);
							BulletX.rigidbody.velocity = 19.0f * new Vector3(Mathf.Sin(angle), 0.0f, Mathf.Cos(angle));
							Destroy(BulletX.gameObject, 5.0f);
							BulletX.rigidbody.useGravity = false;
						}
					}
				}
                lastTime = Time.time;

                if(j%13==0){
                    for (int i=0; i<30; i++)
                    {
                        angle = (i * 20f + j * 0.2f) / 180.0f * Mathf.PI;
                        BulletX = (GameObject)Instantiate(BulletRed, transform.position, transform.rotation);
                        
                        Vector3 temp = new Vector3(4.0f * Mathf.Sin(angle), 0, 4.0f * Mathf.Cos(angle));
                        BulletX.rigidbody.velocity = temp;
                        Destroy(BulletX.gameObject, 12.0f);
                        BulletX.rigidbody.useGravity = false;
                    }
                }

                j++;
            }
        }
    }
}
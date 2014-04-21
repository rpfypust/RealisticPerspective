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
    
    void Awake()
    {
		startTime = Time.time;
		MaxHealthPoint = 1900.0f;
        HealthPoint = 1900.0f;
    }

    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Tag_PlayerBullet")
        {
            //get damage
            float damage = collision.gameObject.GetComponent<BulletInfo>().Damage;
            HealthPoint -= damage;
                
            if (HealthPoint <= 0)
            {
                HealthPoint = 0;
            }
            Destroy(collision.gameObject);
        }
        
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
                float angle = Random.value * 2.0f * Mathf.PI;
                BulletX = new GameObject();
                BulletX.transform.position = transform.position;
                BulletX.AddComponent("PH1_7_HorseSpawn");
                BulletX.GetComponent<PH1_7_HorseSpawn>().angle = angle;
                BulletX.GetComponent<PH1_7_HorseSpawn>().speed = 12.0f;
                BulletX.GetComponent<PH1_7_HorseSpawn>().BulletOrange = BulletOrange;
                lastTime = Time.time;

                if(j%20==0){
                    for (int i=0; i<90; i++)
                    {
                        angle = (i * 4f + j * 0.05f) / 180.0f * Mathf.PI;
                        BulletX = (GameObject)Instantiate(BulletRed, transform.position, transform.rotation);
                        
                        Vector3 temp = new Vector3(14.0f * Mathf.Sin(angle), 0, 14.0f * Mathf.Cos(angle));
                        BulletX.rigidbody.velocity = temp;
                        Destroy(BulletX.gameObject, 6.0f);
                        BulletX.rigidbody.useGravity = false;
                    }
                }

                j++;
            }
        }
    }
}
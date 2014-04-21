using UnityEngine;
using System.Collections;

public class PH1_12 : Character
{
    public GameObject BulletRed;
    public GameObject BulletGreen;
    public GameObject BulletBlue;
    public GameObject BulletYellow;
    public GameObject BulletWhite;
    public GameObject BulletOrange;
    public Vector3 StageRefPoint;
    private Vector3 spawnPos;
    private float startTime = 0.0f;
    private float lastTime = 0.0f;
    private float deltaTime = 0.0f;
    public int j = 0; //angle/bullet counter
    public int step = 0; //step counter
    private GameObject BulletX; //bullets are using this to be created
    
    void Awake()
    {
		startTime = Time.time;
		MaxHealthPoint = 2500.0f;
        HealthPoint = 2500.0f;
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
            if ((Time.time - startTime) > 5.0f)
            {
                j = 0;
                step++;
            }
        }else if (step == 1)
        {
            if ((Time.time - lastTime) > 1 / 9.0f)
            {
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
            if (j == 12)
            {
                step++;
            }
        } else if (step == 2)
        {
            if ((Time.time - lastTime) > 0.2f)
            {
                j = 0;
                step++;
            }
        } else if (step == 3)
        {
            if ((Time.time - lastTime) > 0.02f)
            {
                for (int i=0; i<=1; i++)
                {
                    float angle = Random.value * 2.0f * Mathf.PI;
                    float speed = Random.value * 8.0f + 5.0f;
                    float random = Random.value;
                    spawnPos = transform.position + 7f * new Vector3(speed * Mathf.Sin(angle), 0.0f, speed * Mathf.Cos(angle));
                    if (random < 1/6f){
                        BulletX = (GameObject)Instantiate(BulletRed, spawnPos, transform.rotation);
                    }else if (random < 2/6f){
                        BulletX = (GameObject)Instantiate(BulletGreen, spawnPos, transform.rotation);
                    }else if (random < 3/6f){
                        BulletX = (GameObject)Instantiate(BulletBlue, spawnPos, transform.rotation);
                    }else if (random < 4/6f){
                        BulletX = (GameObject)Instantiate(BulletYellow, spawnPos, transform.rotation);
                    }else if (random < 5/6f){
                        BulletX = (GameObject)Instantiate(BulletWhite, spawnPos, transform.rotation);
                    }else{
                        BulletX = (GameObject)Instantiate(BulletOrange, spawnPos, transform.rotation);
                    }
                    BulletX.rigidbody.velocity = -new Vector3(speed * Mathf.Sin(angle), 0.0f, speed * Mathf.Cos(angle));
                    Destroy(BulletX.gameObject, 7.0f);
                    BulletX.rigidbody.useGravity = false;
                }
                lastTime = Time.time;
                transform.localScale+= 0.5f * 0.02f * Vector3.one;
            }
        }
        if(Time.time - startTime >45f){
            HealthPoint = 0f;
        }
    }
}
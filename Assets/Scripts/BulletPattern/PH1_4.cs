using UnityEngine;
using System.Collections;

public class PH1_4 : Character
{
    public GameObject BulletRed;
    public GameObject BulletWhite; //white
    public GameObject BulletPink_Big;
    public Vector3 StageRefPoint;
    private float startTime = 0.0f;
    private float lastTime = 0.0f;
    public int j = 0; //angle/bullet counter
    public int step = 0; //step counter
    private float speed;
    private float angle;
    
    private GameObject BulletX; //bullets are using this to be created
    private GameObject LaserX; //bullets are using this to be created
    
    void Awake()
    {
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
                for (int i=0; i<90; i++)
                {
                    float angle = (i * 4f + j * 1f) / 180.0f * Mathf.PI;
                    BulletX = (GameObject)Instantiate(BulletRed, transform.position, transform.rotation);
                    
                    Vector3 temp = new Vector3(9.0f * Mathf.Sin(angle), 0, 9.0f * Mathf.Cos(angle));
                    BulletX.rigidbody.velocity = temp;
                    Destroy(BulletX.gameObject, 6.0f);
                    BulletX.rigidbody.useGravity = false;
                }
                lastTime = Time.time;
                j++;
            }
            if (j == 4)
            {
                step++;
            }
        } else if (step == 1)
        {
            if ((Time.time - lastTime) > 0.5f)
            {
                j = 0;
                step++;
            }
        } else if (step == 2)
        {
            if ((Time.time - lastTime) > 0.05f)
            {
                
                for (int i=0; i<=1; i++)
                {
                angle = Random.value * 2.0f * Mathf.PI;
                speed = Random.value * 8.0f + 6.0f;
                BulletX = (GameObject)Instantiate(BulletWhite, transform.position, transform.rotation);
                BulletX.rigidbody.velocity = new Vector3(speed * Mathf.Sin(angle), 0.0f, speed * Mathf.Cos(angle));
                Destroy(BulletX.gameObject, 6.0f);
                BulletX.rigidbody.useGravity = false;
                }
                if (j % 4 == 0)
                {
                    angle = (Random.value * 360f) / 180.0f * Mathf.PI;
                    speed = Random.value * 10f + 4.0f;
                    BulletX = (GameObject)Instantiate(BulletPink_Big, transform.position + new Vector3(0f, 3f, 0f), transform.rotation);
                    BulletX.particleSystem.startSize = 2.0f;
                    Vector3 temp = new Vector3(speed * Mathf.Sin(angle), 4.0f, speed * Mathf.Cos(angle));
                    BulletX.rigidbody.velocity = temp;
                    Destroy(BulletX.gameObject, 8f);
                    BulletX.rigidbody.useGravity = true;
                    BulletX.layer = 15;
                }
                lastTime = Time.time;
                j++;
            }
        }
    }
}
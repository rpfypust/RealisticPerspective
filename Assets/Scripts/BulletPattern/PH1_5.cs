using UnityEngine;
using System.Collections;

public class PH1_5 : Character
{
    public GameObject BulletRed;
    public GameObject BulletBlue; //blue
    public GameObject BulletYellow;
    public GameObject BulletWhite; //white
    public Vector3 StageRefPoint;
    private float startTime = 0.0f;
    private float lastTime = 0.0f;
    public int j = 0; //angle/bullet counter
    public int step = 0; //step counter
    private float angleS;
    private float angleD;
    private float radius = 5f;
    private Vector3 spawnPosition;
    private Vector3 destPosition;
    private GameObject BulletX; //bullets are using this to be created
    
    void Awake()
    {
		startTime = Time.time;
		MaxHealthPoint = 2000.0f;
        HealthPoint = 2000.0f;
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
            if ((Time.time - lastTime) > 1 / 6.0f)
            {
                for (int i=0; i<90; i++)
                {
                    float angle = (i * 4f + j * 1f) / 180.0f * Mathf.PI;
                    BulletX = (GameObject)Instantiate(BulletRed, transform.position, transform.rotation);
                    
                    Vector3 temp = new Vector3(12.0f * Mathf.Sin(angle), 0, 12.0f * Mathf.Cos(angle));
                    BulletX.rigidbody.velocity = temp;
                    Destroy(BulletX.gameObject, 6.0f);
                    BulletX.rigidbody.useGravity = false;
                }
                lastTime = Time.time;
                j++;
            }
            if (j == 5)
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
            if ((Time.time - lastTime) > 1f)
            {
                if (j == 0)
                {
                    angleS = (Random.value * 360f) / 180f * Mathf.PI;
                    angleD = (Random.value * 360f) / 180f * Mathf.PI;
                    spawnPosition = transform.position + new Vector3(radius * Mathf.Sin(angleS), 0f, radius * Mathf.Cos(angleS));
                    destPosition = transform.position + new Vector3(radius * Mathf.Sin(angleD), 0f, radius * Mathf.Cos(angleD));
                    ;
                    for (int i=0; i<36; i++)
                    {
                        float angle = (i * 10f) / 180.0f * Mathf.PI;
                        BulletX = (GameObject)Instantiate(BulletWhite, spawnPosition, transform.rotation);
                        
                        Vector3 temp = new Vector3(10.0f * Mathf.Sin(angle), 0, 8.0f * Mathf.Cos(angle));
                        BulletX.rigidbody.velocity = temp;
                        Destroy(BulletX.gameObject, 7.0f);
                        BulletX.rigidbody.useGravity = false;
                    }
                }
                BulletX = (GameObject)Instantiate(BulletYellow, spawnPosition, transform.rotation);
                BulletX.AddComponent("PH1_5_Dragon");
                BulletX.GetComponent<PH1_5_Dragon>().startTime = Time.time;
                BulletX.GetComponent<PH1_5_Dragon>().dest = destPosition;
                BulletX.GetComponent<PH1_5_Dragon>().oriPos = spawnPosition;
                BulletX.GetComponent<PH1_5_Dragon>().radius = (destPosition - spawnPosition).magnitude / 2.0f;
                BulletX.GetComponent<PH1_5_Dragon>().moveTime = 2.0f;
                BulletX.GetComponent<PH1_5_Dragon>().BulletBlue = BulletBlue;
                BulletX.rigidbody.useGravity = false;
                j++;
                if (j == 40)
                {
                    lastTime = Time.time;
                    j = 0;
                }
            }
        }
    }
}
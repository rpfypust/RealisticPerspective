using UnityEngine;
using System.Collections;

public class PH1_9 : Character
{
    public GameObject BulletRed;
    public GameObject BulletGreen;
    public GameObject BulletOrange;
    public GameObject BulletCoconut;
    public Vector3 StageRefPoint;

    private float angleS;
    private float radius = 5f;
    private Vector3 spawnPosition;

    private float startTime = 0.0f;
    private float lastTime = 0.0f;
    public int j = 0; //angle/bullet counter
    public int step = 0; //step counter
    private GameObject BulletX; //bullets are using this to be created
    
    void Awake()
    {
		startTime = Time.time;
		MaxHealthPoint = 1600.0f;
        HealthPoint = 1600.0f;
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
            if ((Time.time - lastTime) > 1 / 8.0f)
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
            if (j == 9)
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
            if ((Time.time - lastTime) > 1f)
            {
                angleS = (Random.value * 360f) / 180f * Mathf.PI;
                spawnPosition = transform.position + new Vector3(radius * Mathf.Sin(angleS), 0f, radius * Mathf.Cos(angleS));
                BulletX = new GameObject();
                BulletX.transform.position = spawnPosition;
                BulletX.AddComponent("PH1_9_Tree");
                BulletX.GetComponent<PH1_9_Tree>().BulletOrange = BulletOrange;
                BulletX.GetComponent<PH1_9_Tree>().BulletGreen = BulletGreen;
                BulletX.GetComponent<PH1_9_Tree>().BulletCoconut = BulletCoconut;
                lastTime = Time.time;
            }
        }
    }
}
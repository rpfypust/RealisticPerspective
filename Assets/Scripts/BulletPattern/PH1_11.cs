using UnityEngine;
using System.Collections;

public class PH1_11 : MonoBehaviour
{
    public GameObject BulletRed;
    public GameObject BulletDisk;
    public GameObject BulletBlue;
    public GameObject BulletWhite;
    public Vector3 StageRefPoint;
    public float HealthPoint;
    private float startTime = 0.0f;
    private float lastTime = 0.0f;
    public int j = 0; //angle/bullet counter
    public int step = 0; //step counter
    private GameObject BulletX; //bullets are using this to be created
    
    void Awake()
    {
        startTime = Time.time;
        HealthPoint = 1999.0f;
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
            if ((Time.time - lastTime) > 1 / 9.0f)
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
            if (j == 11)
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
            if ((Time.time - lastTime) > 0.3f)
            {
                float angle = Random.value * 2.0f * Mathf.PI;
                float speed = Random.value * 10.0f + 6.0f;
                BulletX = (GameObject)Instantiate(BulletDisk, transform.position + new Vector3(0f, 1f, 0f), transform.rotation);
                BulletX.rigidbody.velocity = new Vector3(speed * Mathf.Sin(angle), 5.0f, speed * Mathf.Cos(angle));
                BulletX.rigidbody.useGravity = true;
                BulletX.AddComponent("PH1_11_Disk");
                if (Random.value > 0.5)
                {
                    BulletX.GetComponent<PH1_11_Disk>().Bullet = BulletBlue;
                } else
                {
                    BulletX.GetComponent<PH1_11_Disk>().Bullet = BulletWhite;
                }
                lastTime = Time.time;
            }
        }
    }
}
using UnityEngine;
using System.Collections;

public class PH1_6 : Character
{
    public GameObject BulletRed;
    public GameObject BulletGreen;
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
		MaxHealthPoint = 1800.0f;
        HealthPoint = 1800.0f;
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
                    
                    Vector3 temp = new Vector3(9.0f * Mathf.Sin(angle), 0, 9.0f * Mathf.Cos(angle));
                    BulletX.rigidbody.velocity = temp;
                    Destroy(BulletX.gameObject, 6.0f);
                    BulletX.rigidbody.useGravity = false;
                }
                lastTime = Time.time;
                j++;
            }
            if (j == 6)
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
            if ((Time.time - lastTime) > 0.08f)
            {
                float angle = Random.value * 2.0f * Mathf.PI;
                BulletX = new GameObject();
                BulletX.transform.position = transform.position;
                BulletX.AddComponent("PH1_6_SnakeSpawn");
                BulletX.GetComponent<PH1_6_SnakeSpawn>().angle = angle;
                BulletX.GetComponent<PH1_6_SnakeSpawn>().speed = 7.0f;
                BulletX.GetComponent<PH1_6_SnakeSpawn>().BulletGreen = BulletGreen;
                BulletX.GetComponent<PH1_6_SnakeSpawn>().phase = Random.value * 2f * Mathf.PI;
                lastTime = Time.time;
            }
        }
    }
}
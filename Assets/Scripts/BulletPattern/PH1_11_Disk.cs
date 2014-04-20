using UnityEngine;
using System.Collections;

public class PH1_11_Disk : MonoBehaviour
{
    public GameObject Bullet;
    public float startTime = Time.time;
    public int j = 0;
    private float lastTime = 0.0f;
    private float deltaTime = 0.0f;
    private GameObject BulletX; //bullets are using this to be created

    void FixedUpdate()
    {
        float cTime = Time.time - startTime;
        deltaTime = cTime - lastTime;
        
        if (transform.position.y < 0.55f)
        {
            rigidbody.velocity = new Vector3(0f, rigidbody.velocity.y, 0f);
            if ((cTime - lastTime) > 0.15f)
            {
                for (int i=0; i<8; i++)
                {
                    float angle = (i * 45f + j * 10f) / 180.0f * Mathf.PI;
                    Vector3 spawnPos = transform.position;
                    spawnPos.y = 0.5f;
                    BulletX = (GameObject)Instantiate(Bullet, spawnPos, transform.rotation);
                
                    Vector3 temp = new Vector3(7.0f * Mathf.Sin(angle), 0, 7.0f * Mathf.Cos(angle));
                    BulletX.rigidbody.velocity = temp;
                    Destroy(BulletX.gameObject, 6.0f);
                    BulletX.rigidbody.useGravity = false;
                }
                lastTime = cTime;
                j++;
                if (j == 3)
                {
                    GameObject.Destroy(gameObject);
                }
            }
        }
    }
}
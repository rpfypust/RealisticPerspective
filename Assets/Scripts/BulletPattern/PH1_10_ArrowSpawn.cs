using UnityEngine;
using System.Collections;

public class PH1_10_ArrowSpawn : MonoBehaviour
{
    public GameObject BulletOrange;
    public float startTime = Time.time;
    public float angle;
    public float speed;
    private int j = 0;
    private float lastTime = 0.0f;
    private float deltaTime = 0.0f;
    private GameObject BulletX; //bullets are using this to be created

    void FixedUpdate()
    {
        float cTime = Time.time - startTime;
        deltaTime = cTime - lastTime;
        
        if ((cTime - lastTime) > 0.031f)
        {
            for (int i=-1; i<3; i+=2)
            {
                Vector3 displace = new Vector3(-Mathf.Cos(angle), 0.0f, Mathf.Sin(angle)) * j / 3f * i;
                BulletX = (GameObject)Instantiate(BulletOrange, transform.position + displace, transform.rotation);
                BulletX.rigidbody.velocity = speed * new Vector3(Mathf.Sin(angle), 0.0f, Mathf.Cos(angle));
                Destroy(BulletX.gameObject, 7.0f);
                BulletX.rigidbody.useGravity = false;
            }
            lastTime = cTime;
            j++;
            if (j == 4)
            {
                GameObject.Destroy(gameObject);
            }
        }
    }
}
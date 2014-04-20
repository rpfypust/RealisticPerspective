using UnityEngine;
using System.Collections;

public class PH1_9_Tree : MonoBehaviour
{
    public GameObject BulletOrange;
    public GameObject BulletGreen;
    public GameObject BulletCoconut;
    public float startTime = Time.time;
    private int j = 0;
    private int step = 0;
    private float lastTime = 0.0f;
    private float deltaTime = 0.0f;
    private GameObject BulletX; //bullets are using this to be created
    private GameObject target;
    private Vector3 speed;

    void FixedUpdate()
    {
        float cTime = Time.time - startTime;
        deltaTime = cTime - lastTime;

        if (step == 0)
        {
            if ((cTime - lastTime) > 0.1f)
            {
                for (int m=0; m<2; m++)
                {
                    for (int n=0; n<2; n++)
                    {
                        BulletX = (GameObject)Instantiate(BulletOrange, transform.position + new Vector3(m * 0.4f, j * 0.5f, n * 0.4f), transform.rotation);
                        Destroy(BulletX.gameObject, 8.0f);
                        BulletX.rigidbody.useGravity = false;
                    }
                }
                j++;
                lastTime = cTime;
                if (j == 6)
                {
                    step++;
                    j = 0;
                }
            }
        } else if (step == 1)
        {
            if ((cTime - lastTime) > 0.1f)
            {
                for (int i=0; i<8; i++)
                {
                    float angle = i / 4f *Mathf.PI;
                    BulletX = (GameObject)Instantiate(BulletGreen, transform.position + new Vector3(j * 0.4f *Mathf.Sin(angle), 3f - j*j /20f, j * 0.4f *Mathf.Cos(angle)), transform.rotation);
                    Destroy(BulletX.gameObject, 8.0f);
                    BulletX.rigidbody.useGravity = false;
                }
                j++;
                lastTime = cTime;
                if (j == 6)
                {
                    step++;
                }
            }
        } else if (step == 2)
        {
            if ((cTime - lastTime) > 0.1f)
            {
                target = GameObject.FindWithTag("Player");
                speed = (target.transform.position - transform.position).normalized * (Random.value * 5f + 5f);
                speed.y = 0f;
                BulletX = (GameObject)Instantiate(BulletCoconut, transform.position + new Vector3(0f, 3f, 0f), transform.rotation);
                Destroy(BulletX.gameObject, 8.0f);
                BulletX.rigidbody.velocity = speed;
                BulletX.rigidbody.useGravity = true;
                BulletX.layer = 15;
                lastTime = cTime;
                j++;
                if (j == 30)
                {
                    step++;
                }
            }
        } if (step == 3)
        {
            GameObject.Destroy(gameObject);
        }

    }
}
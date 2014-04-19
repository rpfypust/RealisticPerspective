using UnityEngine;
using System.Collections;

public class PH1_6_SnakeSpawn : MonoBehaviour
{
    public GameObject BulletGreen;
    public float startTime = Time.time;
    public float angle;
    public float speed;
    public float phase;
    private int j = 0;
    private float lastTime = 0.0f;
    private float deltaTime = 0.0f;
    private GameObject BulletX; //bullets are using this to be created

    void FixedUpdate()
    {
        float cTime = Time.time - startTime;
        deltaTime = cTime - lastTime;
        
        if ((Time.time - lastTime) > 0.1f)
        {
            if (j % 4 == 0)
            {
                //float angle = Random.value * 2.0f * Mathf.PI;
                //float speed = Random.value * 10.0f + 8.0f;
                BulletX = (GameObject)Instantiate(BulletGreen, transform.position, transform.rotation);
                BulletX.AddComponent("PH1_6_Snake");
                BulletX.GetComponent<PH1_6_Snake>().velo = speed * new Vector3(Mathf.Sin(angle), 0.0f, Mathf.Cos(angle));
                BulletX.GetComponent<PH1_6_Snake>().oscili = new Vector3(-Mathf.Cos(angle), 0.0f, Mathf.Sin(angle));
                BulletX.GetComponent<PH1_6_Snake>().oriPos = transform.position;
                BulletX.GetComponent<PH1_6_Snake>().period = 1f;
                BulletX.GetComponent<PH1_6_Snake>().phase = phase;
                Destroy(BulletX.gameObject, 8.0f);
                BulletX.rigidbody.useGravity = false;
                lastTime = cTime;
            }
            j++;
            if (j == 40)
            {
                GameObject.Destroy(gameObject);
            }
        }
    }
}
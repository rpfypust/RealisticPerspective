using UnityEngine;
using System.Collections;

public class CS1_0 : MonoBehaviour
{
    public GameObject BulletRed; //red
    public GameObject BulletGreen; //green
    public GameObject BulletBlue; //blue
    
    public Vector3 StageRefPoint;
    public Boss status;
    public Transform boss;

    private float startTime = 0.0f;
    private float lastTime = 0.0f;

    public int j = 0; //angle/bullet counter
    public int step = 0; //step counter

	private GameObject BulletX; //bullets are using this to be created
	private SEManager sem;
	
	void Awake()
	{
		sem = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<SEManager>();
        startTime = Time.time;
        j = 0;
    }

    void OnDestroy()
    {
        Util.removeAllBulletsbyTag("Tag_Bullet");
    }

    void FixedUpdate()
    {
        if (step >= 130)
        { //Reset to step A
            step = 0;
        }
        if (step <= 23)
        { //first red bullet
            if ((Time.time - lastTime) > 1 / 25.0f)
			{
				sem.PlaySoundEffect(2);
                float temp = Mathf.Sin(Time.frameCount / 50.0f);
                float angle = (temp * 1640.0f + 90.0f) / 180.0f * Mathf.PI;
                for (int i=0; i<6; i++)
                {
                    angle = Mathf.PI / 36.0f * (i * 6f + j) + j / 100.0f;
                    BulletX = (GameObject)Instantiate(BulletRed, transform.position, transform.rotation);
                    
                    BulletX.AddComponent("CS1_0_B1");
                    BulletX.GetComponent<CS1_0_B1>().startTime = Time.time;
                    BulletX.GetComponent<CS1_0_B1>().vx = 10.0f * Mathf.Sin(angle);
                    BulletX.GetComponent<CS1_0_B1>().vz = -10.0f * Mathf.Cos(angle);
                    BulletX.GetComponent<CS1_0_B1>().oriPos = transform.position;
                    Destroy(BulletX.gameObject, 8.0f);
                    BulletX.rigidbody.useGravity = false;
                    j++;
                }
                lastTime = Time.time;
                //move boss
                boss.position = boss.position + new Vector3(0.2f * Mathf.Cos(angle / 8f), 0, 0.2f * Mathf.Sin(angle / 8f));
                step++;
            }
        } else if (step <= 38)
        { //player-homing green laser
            if ((Time.time - lastTime) > 1 / 60.0f)
			{
				sem.PlaySoundEffect(2);
                for (int i=-3; i<=3; i++)
                {
                    float angle = (i * 20.0f) / 180.0f * Mathf.PI;
                    BulletX = (GameObject)Instantiate(BulletGreen, transform.position, transform.rotation);
                    BulletX.layer = 15;
                    BulletX.AddComponent("CS1_0_B2");
                    BulletX.GetComponent<CS1_0_B2>().startTime = Time.time;
                    BulletX.GetComponent<CS1_0_B2>().vx = 8.0f * Mathf.Sin(angle);
                    BulletX.GetComponent<CS1_0_B2>().vz = 8.0f * Mathf.Cos(angle);
                    BulletX.GetComponent<CS1_0_B2>().oriPos = transform.position;
					BulletX.rigidbody.useGravity = false;
                }
                lastTime = Time.time;
                step++;
            }
        } else if (step <= 73)
        { //waiting
            step++;
        } else if (step <= 76)
        { //all-direction red bullet
            if ((Time.time - lastTime) > 1 / 5.0f)
			{
				sem.PlaySoundEffect(2);
                for (int i=0; i<90; i++)
                {
                    float angle = (i * 4f + step * 1f) / 180.0f * Mathf.PI;
                    BulletX = (GameObject)Instantiate(BulletRed, transform.position, transform.rotation);
                    
                    Vector3 temp = new Vector3(8.0f * Mathf.Sin(angle), 0, 8.0f * Mathf.Cos(angle));
                    BulletX.rigidbody.velocity = temp;
                    Destroy(BulletX.gameObject, 8.0f);
					BulletX.rigidbody.useGravity = false;
                }
                lastTime = Time.time;
                step++;
            }
        } else if (step <= 77)
        { //all-direction red bullet
            if ((Time.time - lastTime) > 1 / 2.0f)
            {
                lastTime = Time.time;
                step++;
            }
        } else if (step <= 80)
        { //all-direction red bullet
            if ((Time.time - lastTime) > 1 / 5.0f)
			{
				sem.PlaySoundEffect(2);
                for (int i=0; i<90; i++)
                {
                    float angle = (i * 4f + step * 1f) / 180.0f * Mathf.PI;
                    BulletX = (GameObject)Instantiate(BulletRed, transform.position, transform.rotation);
                    
                    Vector3 temp = new Vector3(8.0f * Mathf.Sin(angle), 0, 8.0f * Mathf.Cos(angle));
                    BulletX.rigidbody.velocity = temp;
                    Destroy(BulletX.gameObject, 8.0f);
					BulletX.rigidbody.useGravity = false;
                }
                lastTime = Time.time;
                step++;
            }
        } else
        { //wait
            step++;
        }
    }
}
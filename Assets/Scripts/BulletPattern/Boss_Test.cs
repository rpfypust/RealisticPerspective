using UnityEngine;
using System.Collections;

public class Boss_Test : MonoBehaviour
{
    public GameObject BulletA;
    public GameObject BulletB;
    public GameObject BulletC;
    public GameObject BulletD;
    public float speed = 10.0f;
    private float startTime = 0.0f;
    private float lastTime = 0.0f;
    private float lastTime2 = 0.0f;
    int j = 0; //angle counter
    int k = 0; //stage counter

    void Awake()
    {
        startTime = Time.time;
        j = 0;
    }

    void FixedUpdate()
    {
        //if(_11_Trigger_MagicStage.FireStatus == true)
        //{
    
        //First Skill
        if (transform.gameObject.GetComponent<BossStatus>().BulletPatternState == 0)
        {   
            //Check HP and jump to next skill
            if (transform.gameObject.GetComponent<BossStatus>().HealthPoint <= 0.0f)
            {
                transform.gameObject.GetComponent<BossStatus>().BulletPatternState = 1;
                transform.gameObject.GetComponent<BossStatus>().isInvicible = true;
            } else //Start this sill
            {
                GameObject BulletX;
                
                if (k > 120) //Reset to Stage A
                {
                    k = 0;
                }
                //Stage A
                if (k <= 17)
                {
                    if ((Time.time - lastTime) > 1 / 25.0f)
                    {
                        float temp = Mathf.Sin(Time.frameCount / 50.0f);
                        float angle = (temp * 1640.0f + 90.0f) / 180.0f * Mathf.PI;
                        for (int i=0; i<6; i++)
                        {
                            angle = Mathf.PI / 36.0f * (i * 6f + j) + j / 100.0f;
                            BulletX = (GameObject)Instantiate(BulletA, transform.position, transform.rotation);
                            BulletX.gameObject.AddComponent("A01_B1");
                            BulletX.gameObject.GetComponent<A01_B1>().startTime = Time.time;
                            BulletX.gameObject.GetComponent<A01_B1>().vx = speed * Mathf.Sin(angle);// * Mathf.Sin (angle));
                            BulletX.gameObject.GetComponent<A01_B1>().vz = -speed * Mathf.Cos(angle);// * Mathf.Cos (angle));
                            BulletX.gameObject.GetComponent<A01_B1>().oriPos = transform.position;
                            BulletX.rigidbody.useGravity = false;
                            j++;
                        }
                        lastTime = Time.time;
                        //move boss
                        transform.position = transform.position + new Vector3(0.2f * Mathf.Cos(angle / 8f), 0, 0.2f * Mathf.Sin(angle / 8f));
                        k++;
                    }
                } else if (k <= 32)
                {
                    if ((Time.time - lastTime) > 1 / 60.0f)
                    {
                        for (int i=-3; i<=3; i++)
                        {
                            float angle = (i*20.0f) / 180.0f * Mathf.PI;
                            BulletX = (GameObject)Instantiate(BulletB, transform.position, transform.rotation);
                            BulletX.gameObject.AddComponent("A01_B2");
                            BulletX.gameObject.GetComponent<A01_B2>().startTime = Time.time;
                            BulletX.gameObject.GetComponent<A01_B2>().vx = speed*0.8f * Mathf.Sin(angle);// * Mathf.Sin (angle));
                            BulletX.gameObject.GetComponent<A01_B2>().vz = speed*0.8f * Mathf.Cos(angle);// * Mathf.Cos (angle));
                            BulletX.gameObject.GetComponent<A01_B2>().oriPos = transform.position;
                            BulletX.rigidbody.useGravity = false;
                        }
                        lastTime = Time.time;
                        k++;
                    }
                } else if (k <= 65) {
                    k++;
                } else if (k <= 66) {
                    for (int i=0; i<120; i++)
                    {
                        float angle = (i*3f) / 180.0f * Mathf.PI;
                        BulletX = (GameObject)Instantiate(BulletA, transform.position, transform.rotation);
                        Vector3 temp = new Vector3(speed*0.8f * Mathf.Sin(angle),0,speed*0.8f * Mathf.Cos(angle));
                        BulletX.rigidbody.velocity=temp;
                        BulletX.rigidbody.useGravity = false;
                    }
                    k++;
                } else {
                    k++;
                }
            }
        }//End of first skill







        /*if((Time.time-lastTime)>1/25.0)
        {
            var angle = (temp*1640.0 +90.0)/180.0*Mathf.PI;
            var result = PowerZ;
            for(i=0;i<6;i++){
                angle = Mathf.PI/36.0*(i*6+j) + j/100.0;
                BulletX = Instantiate(Bullet, transform.position, transform.rotation);
                BulletX.gameObject.AddComponent("A01_B1");
                BulletX.gameObject.GetComponent("A01_B1").startTime = Time.time;
                BulletX.gameObject.GetComponent("A01_B1").vx = result * Mathf.Cos(angle);
                BulletX.gameObject.GetComponent("A01_B1").vz = result * Mathf.Sin(angle);
                BulletX.gameObject.GetComponent("A01_B1").oriPos = transform.position;
                BulletX.useGravity = false;
                j++;
            }
            lastTime = Time.time;
            //AxeA.detectCollisions = false;
            
            //audio.PlayOneShot(ThrowerSound);
        }
        if((Time.time-lastTime2)>1/2.5)
        {
            var direction = GameObject.Find("CharacterController").transform.position - transform.position;
            direction = direction/direction.magnitude;
            for (k=-4;k<=4;k++){
                BulletX = Instantiate(Bullet, transform.position, transform.rotation);
                BulletX.velocity = Quaternion.AngleAxis(k*15, Vector3.up) * (direction * 4.0);
                BulletX.useGravity = false;
            }
            lastTime2 = Time.time;
        }*/
        //}
    }
        
}
//script RequireComponent(AudioSource)
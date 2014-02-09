using UnityEngine;
using System.Collections;

public class Boss_Test : MonoBehaviour
{
    public GameObject BulletA; //red
    public GameObject BulletB; //green
    public GameObject BulletC; //blue
    public GameObject BulletD;
    private float startTime = 0.0f;
    private float lastTime = 0.0f;
    private float localStartTime = 0.0f;
    private int j = 0; //angle counter
    public int k = 0; //step counter
    private GameObject BulletX; //bullets are using this to be created
    private GameObject BulletSet_Error; //trigger area for the 2nd skill

    void Awake()
    {
        startTime = Time.time;
        j = 0;
    }

    void FixedUpdate()
    {
    
        //First Skill
        if (transform.gameObject.GetComponent<BossStatus>().BulletPatternState == 0)
        {   
            //Check HP and jump to next skill
            if (transform.gameObject.GetComponent<BossStatus>().HealthPoint <= 4800.0f)
            {
                transform.gameObject.GetComponent<BossStatus>().BulletPatternState = 1;
                transform.gameObject.GetComponent<BossStatus>().isInvicible = true;
                Util.removeAllBulletsbyTag("Tag_Bullet");
            } else //Start this sill
            {                
                if (k >= 120) //Reset to step A
                {
                    k = 0;
                }
                if (k <= 17) //first red bullet
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
                            BulletX.gameObject.GetComponent<A01_B1>().vx = 10.0f * Mathf.Sin(angle);
                            BulletX.gameObject.GetComponent<A01_B1>().vz = -10.0f * Mathf.Cos(angle);
                            BulletX.gameObject.GetComponent<A01_B1>().oriPos = transform.position;
                            Destroy(BulletX.gameObject,8.0f);
                            BulletX.rigidbody.useGravity = false;
                            j++;
                        }
                        lastTime = Time.time;
                        //move boss
                        transform.position = transform.position + new Vector3(0.2f * Mathf.Cos(angle / 8f), 0, 0.2f * Mathf.Sin(angle / 8f));
                        k++;
                    }
                } else if (k <= 32) //player-homing green laser
                {
                    if ((Time.time - lastTime) > 1 / 60.0f)
                    {
                        for (int i=-3; i<=3; i++)
                        {
                            float angle = (i * 20.0f) / 180.0f * Mathf.PI;
                            BulletX = (GameObject)Instantiate(BulletB, transform.position, transform.rotation);

                            BulletX.gameObject.AddComponent("A01_B2");
                            BulletX.gameObject.GetComponent<A01_B2>().startTime = Time.time;
                            BulletX.gameObject.GetComponent<A01_B2>().vx = 8.0f * Mathf.Sin(angle);
                            BulletX.gameObject.GetComponent<A01_B2>().vz = 8.0f * Mathf.Cos(angle);
                            BulletX.gameObject.GetComponent<A01_B2>().oriPos = transform.position;
                            BulletX.rigidbody.useGravity = false;
                        }
                        lastTime = Time.time;
                        k++;
                    }
                } else if (k <= 65) //waiting
                {
                    k++;
                } else if (k <= 66) //all-direction red bullet
                {
                    for (int i=0; i<120; i++)
                    {
                        float angle = (i * 3f) / 180.0f * Mathf.PI;
                        BulletX = (GameObject)Instantiate(BulletA, transform.position, transform.rotation);

                        Vector3 temp = new Vector3(8.0f * Mathf.Sin(angle), 0, 8.0f * Mathf.Cos(angle));
                        BulletX.rigidbody.velocity = temp;
                        Destroy(BulletX.gameObject,8.0f);
                        BulletX.rigidbody.useGravity = false;
                    }
                    k++;
                } else //wait
                {
                    k++;
                }
            }
        } else if (transform.gameObject.GetComponent<BossStatus>().BulletPatternState == 1) //Second Skill
        {   
            //Check is just starting this skill
            if (transform.gameObject.GetComponent<BossStatus>().isInvicible)
            {
                transform.gameObject.GetComponent<BossStatus>().isInvicible = false;
                k = 0;
            } else
            //Check HP and jump to next skill
            if (transform.gameObject.GetComponent<BossStatus>().HealthPoint <= 3500.0f)
            {
                transform.gameObject.GetComponent<BossStatus>().BulletPatternState = 1;
                transform.gameObject.GetComponent<BossStatus>().isInvicible = true;
                Util.removeAllBulletsbyTag("Tag_Bullet");
            } else //Start this sill
            {
                if (k >= 95) //Reset to Stage A
                {
                    k = 0;
                }
                if (k < 1) //set up trigger area
                {
                    localStartTime = Time.time;

                    BulletSet_Error = new GameObject("BulletSet_ErrorTemp");
                    BulletSet_Error.tag = "Tag_BulletSet";
                    BulletSet_Error.transform.position = transform.position;
                    BulletSet_Error.layer = 0;
                    BulletSet_Error.AddComponent("A01_BS_Error");
                    BulletSet_Error.GetComponent<A01_BS_Error>().velocity = 4.0f;
                    BulletSet_Error.GetComponent<A01_BS_Error>().boss = gameObject;

                    CapsuleCollider BulletSetTriggerArea = new CapsuleCollider();
                    BulletSetTriggerArea = BulletSet_Error.AddComponent("CapsuleCollider") as CapsuleCollider;
                    BulletSetTriggerArea.isTrigger = true;
                    BulletSetTriggerArea.height = 20;
                    BulletSetTriggerArea.radius = 5;

                    Rigidbody BulletSetRigidbody = new Rigidbody();
                    BulletSetRigidbody = BulletSet_Error.AddComponent("Rigidbody") as Rigidbody;
                    BulletSetRigidbody.isKinematic = true;
                    BulletSetRigidbody.useGravity = false;

                    j = 0;
                    k++;

                } else if (k < 2) //Drawing the circle
                {
                    float angle = (j * -10.0f) / 180.0f * Mathf.PI;
                    BulletX = (GameObject)Instantiate(BulletC, transform.position, transform.rotation);
                    BulletX.transform.parent = BulletSet_Error.transform;

                    BulletX.gameObject.AddComponent("A01_Error_B1");
                    BulletX.gameObject.GetComponent<A01_Error_B1>().startTime = Time.time;
                    BulletX.gameObject.GetComponent<A01_Error_B1>().finalPositionX = 5.0f * Mathf.Sin(angle);
                    BulletX.gameObject.GetComponent<A01_Error_B1>().finalPositionZ = 5.0f * Mathf.Cos(angle);
                    BulletX.gameObject.GetComponent<A01_Error_B1>().lastFor = 1.5f;
                    BulletX.gameObject.GetComponent<A01_Error_B1>().oriPos = transform.position;
                    BulletX.rigidbody.useGravity = false;
                    j++;
                    if (j >= 36)
                    {
                        k++;
                        j = 0;
                    }
                } else if (k < 3) // drawing the X
                {
                    float distance = Mathf.Sqrt(6.125f) - 2 * Mathf.Sqrt(6.125f) * j / 16.0f;

                    BulletX = (GameObject)Instantiate(BulletA, transform.position, transform.rotation);
                    BulletX.transform.parent = BulletSet_Error.transform;
                    
                    BulletX.gameObject.AddComponent("A01_Error_B1");
                    BulletX.gameObject.GetComponent<A01_Error_B1>().startTime = Time.time;
                    BulletX.gameObject.GetComponent<A01_Error_B1>().finalPositionX = distance;
                    BulletX.gameObject.GetComponent<A01_Error_B1>().finalPositionZ = distance;
                    BulletX.gameObject.GetComponent<A01_Error_B1>().lastFor = 1.5f;
                    BulletX.gameObject.GetComponent<A01_Error_B1>().oriPos = transform.position;
                    BulletX.rigidbody.useGravity = false;

                    BulletX = (GameObject)Instantiate(BulletA, transform.position, transform.rotation);
                    BulletX.transform.parent = BulletSet_Error.transform;
                    
                    BulletX.gameObject.AddComponent("A01_Error_B1");
                    BulletX.gameObject.GetComponent<A01_Error_B1>().startTime = Time.time;
                    BulletX.gameObject.GetComponent<A01_Error_B1>().finalPositionX = -distance;
                    BulletX.gameObject.GetComponent<A01_Error_B1>().finalPositionZ = distance;
                    BulletX.gameObject.GetComponent<A01_Error_B1>().lastFor = 1.5f;
                    BulletX.gameObject.GetComponent<A01_Error_B1>().oriPos = transform.position;
                    BulletX.rigidbody.useGravity = false;

                    j++;
                    if (j >= 17)
                    {
                        k++;
                        j = 0;
                    }
                } else if (k < 93) //wait for the bullet is setted up
                {

                    k++;

                } else if (k < 94) //move the bullet, wait for the bullet leave boss
                {
                    BulletSet_Error.name = "BulletSet_Error";
                    BulletSet_Error.GetComponent<A01_BS_Error>().canStartMoving = true;

                } else if (k < 95) // start random bullet
                {
                    for (int i=0; i<=1; i++)
                    {
                        float angle = Random.value * 2.0f * Mathf.PI;
                        float speed = Random.value * 6.0f + 8.0f;
                        BulletX = (GameObject)Instantiate(BulletB, transform.position, transform.rotation);
                        BulletX.layer = 14;
                        BulletX.gameObject.AddComponent("A01_Error_B2");
                        BulletX.gameObject.GetComponent<A01_Error_B2>().startTime = Time.time;
                        BulletX.gameObject.GetComponent<A01_Error_B2>().vx = speed * Mathf.Sin(angle);
                        BulletX.gameObject.GetComponent<A01_Error_B2>().vz = speed * Mathf.Cos(angle);
                        BulletX.gameObject.GetComponent<A01_Error_B2>().oriPos = transform.position;
                        Destroy(BulletX.gameObject,6.0f);
                        BulletX.rigidbody.useGravity = false;
                    }
                }
            }
        }
    }
        
}
//script RequireComponent(AudioSource)
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
    private int j = 0; //angle/bullet counter
    public int k = 0; //step counter
    private GameObject BulletX; //bullets are using this to be created
    private GameObject BulletSet_Error; //trigger area for the 2nd skill
    private bool bossSettedUp = true;
    private Vector3 StageRefPoint;
    private BossStatus status;
    private Transform boss;

    void Awake()
    {
        startTime = Time.time;
        j = 0;
        status = transform.parent.gameObject.GetComponent<BossStatus>();
        boss = transform.parent;
        StageRefPoint = GameObject.FindGameObjectWithTag("StageRefPoint").transform.position;
    }

    void FixedUpdate()
    {
    
        //First Skill
        if (status.BulletPatternState == 0)
        {   
            //Check HP and jump to next skill
            if (status.HealthPoint <= 4900.0f)
            {
                status.BulletPatternState = 1;
                status.isInvicible = true;
                Util.removeAllBulletsbyTag("Tag_Bullet");
                bossSettedUp = false;
            } else
            { //Start this sill                
                if (k >= 130)
                { //Reset to step A
                    k = 0;
                }
                if (k <= 23)
                { //first red bullet
                    if ((Time.time - lastTime) > 1 / 25.0f)
                    {
                        float temp = Mathf.Sin(Time.frameCount / 50.0f);
                        float angle = (temp * 1640.0f + 90.0f) / 180.0f * Mathf.PI;
                        for (int i=0; i<6; i++)
                        {
                            angle = Mathf.PI / 36.0f * (i * 6f + j) + j / 100.0f;
                            BulletX = (GameObject)Instantiate(BulletA, transform.position, transform.rotation);

                            BulletX.AddComponent("A01_B1");
                            BulletX.GetComponent<A01_B1>().startTime = Time.time;
                            BulletX.GetComponent<A01_B1>().vx = 10.0f * Mathf.Sin(angle);
                            BulletX.GetComponent<A01_B1>().vz = -10.0f * Mathf.Cos(angle);
                            BulletX.GetComponent<A01_B1>().oriPos = transform.position;
                            Destroy(BulletX.gameObject, 8.0f);
                            BulletX.rigidbody.useGravity = false;
                            j++;
                        }
                        lastTime = Time.time;
                        //move boss
                        boss.position = boss.position + new Vector3(0.2f * Mathf.Cos(angle / 8f), 0, 0.2f * Mathf.Sin(angle / 8f));
                        k++;
                    }
                } else if (k <= 38)
                { //player-homing green laser
                    if ((Time.time - lastTime) > 1 / 60.0f)
                    {
                        for (int i=-3; i<=3; i++)
                        {
                            float angle = (i * 20.0f) / 180.0f * Mathf.PI;
                            BulletX = (GameObject)Instantiate(BulletB, transform.position, transform.rotation);
                            BulletX.layer = 15;
                            BulletX.AddComponent("A01_B2");
                            BulletX.GetComponent<A01_B2>().startTime = Time.time;
                            BulletX.GetComponent<A01_B2>().vx = 8.0f * Mathf.Sin(angle);
                            BulletX.GetComponent<A01_B2>().vz = 8.0f * Mathf.Cos(angle);
                            BulletX.GetComponent<A01_B2>().oriPos = transform.position;
                            BulletX.rigidbody.useGravity = false;
                        }
                        lastTime = Time.time;
                        k++;
                    }
                } else if (k <= 73)
                { //waiting
                    k++;
                } else if (k <= 76)
                { //all-direction red bullet
                    if ((Time.time - lastTime) > 1 / 5.0f)
                    {
                        for (int i=0; i<120; i++)
                        {
                            float angle = (i * 3f + k * 0.5f) / 180.0f * Mathf.PI;
                            BulletX = (GameObject)Instantiate(BulletA, transform.position, transform.rotation);

                            Vector3 temp = new Vector3(8.0f * Mathf.Sin(angle), 0, 8.0f * Mathf.Cos(angle));
                            BulletX.rigidbody.velocity = temp;
                            Destroy(BulletX.gameObject, 8.0f);
                            BulletX.rigidbody.useGravity = false;
                        }
                        lastTime = Time.time;
                        k++;
                    }
                } else if (k <= 77)
                { //all-direction red bullet
                    if ((Time.time - lastTime) > 1 / 2.0f)
                    {
                        lastTime = Time.time;
                        k++;
                    }
                } else if (k <= 80)
                { //all-direction red bullet
                    if ((Time.time - lastTime) > 1 / 5.0f)
                    {
                        for (int i=0; i<120; i++)
                        {
                            float angle = (i * 3f + k * 0.5f) / 180.0f * Mathf.PI;
                            BulletX = (GameObject)Instantiate(BulletA, transform.position, transform.rotation);
                        
                            Vector3 temp = new Vector3(8.0f * Mathf.Sin(angle), 0, 8.0f * Mathf.Cos(angle));
                            BulletX.rigidbody.velocity = temp;
                            Destroy(BulletX.gameObject, 8.0f);
                            BulletX.rigidbody.useGravity = false;
                        }
                        lastTime = Time.time;
                        k++;
                    }
                } else
                { //wait
                    k++;
                }
            }
        } else if (status.BulletPatternState == 1)
        { //Second Skill   
            //Check is just starting this skill
            if (!bossSettedUp)
            {
                status.isInvicible = false;
                bossSettedUp = true;
                k = 0;
            } else
            //Check HP and jump to next skill
            if (status.HealthPoint <= 4800.0f)
            {
                status.BulletPatternState = 2;
                status.isInvicible = true;
                Util.removeAllBulletsbyTag("Tag_Bullet");
                Util.removeAllBulletsbyTag("Tag_BulletSet");
                bossSettedUp = false;
                if (boss.gameObject.GetComponent <BossRandomMoveInArea>())
                {
                    Destroy(boss.gameObject.GetComponent <BossRandomMoveInArea>());
                }
            } else
            { //Start this sill
                if (k >= 95)
                { //Reset to Stage A
                    k = 0;
                    if (boss.gameObject.GetComponent <BossRandomMoveInArea>())
                    {
                        Destroy(boss.gameObject.GetComponent <BossRandomMoveInArea>());
                    }
                }
                if (k < 1)
                { //set up trigger area
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

                } else if (k < 2)
                { //Drawing the circle
                    float angle = (j * -10.0f) / 180.0f * Mathf.PI;
                    BulletX = (GameObject)Instantiate(BulletC, transform.position, transform.rotation);
                    BulletX.transform.parent = BulletSet_Error.transform;

                    BulletX.AddComponent("A01_Error_B1");
                    BulletX.GetComponent<A01_Error_B1>().startTime = Time.time;
                    BulletX.GetComponent<A01_Error_B1>().finalPositionX = 5.0f * Mathf.Sin(angle);
                    BulletX.GetComponent<A01_Error_B1>().finalPositionZ = 5.0f * Mathf.Cos(angle);
                    BulletX.GetComponent<A01_Error_B1>().lastFor = 1.5f;
                    BulletX.GetComponent<A01_Error_B1>().oriPos = transform.position;
                    BulletX.rigidbody.useGravity = false;
                    j++;
                    if (j >= 36)
                    {
                        k++;
                        j = 0;
                    }
                } else if (k < 3)
                { // drawing the X
                    float distance = Mathf.Sqrt(6.125f) - 2 * Mathf.Sqrt(6.125f) * j / 16.0f;

                    BulletX = (GameObject)Instantiate(BulletA, transform.position, transform.rotation);
                    BulletX.transform.parent = BulletSet_Error.transform;
                    
                    BulletX.AddComponent("A01_Error_B1");
                    BulletX.GetComponent<A01_Error_B1>().startTime = Time.time;
                    BulletX.GetComponent<A01_Error_B1>().finalPositionX = distance;
                    BulletX.GetComponent<A01_Error_B1>().finalPositionZ = distance;
                    BulletX.GetComponent<A01_Error_B1>().lastFor = 1.5f;
                    BulletX.GetComponent<A01_Error_B1>().oriPos = transform.position;
                    BulletX.rigidbody.useGravity = false;

                    BulletX = (GameObject)Instantiate(BulletA, transform.position, transform.rotation);
                    BulletX.transform.parent = BulletSet_Error.transform;
                    
                    BulletX.AddComponent("A01_Error_B1");
                    BulletX.GetComponent<A01_Error_B1>().startTime = Time.time;
                    BulletX.GetComponent<A01_Error_B1>().finalPositionX = -distance;
                    BulletX.GetComponent<A01_Error_B1>().finalPositionZ = distance;
                    BulletX.GetComponent<A01_Error_B1>().lastFor = 1.5f;
                    BulletX.GetComponent<A01_Error_B1>().oriPos = transform.position;
                    BulletX.rigidbody.useGravity = false;

                    j++;
                    if (j >= 17)
                    {
                        k++;
                        j = 0;
                    }
                } else if (k < 93)
                { //wait for the bullet is setted up

                    k++;

                } else if (k < 94)
                { //move the bullet, wait for the bullet leave boss
                    BulletSet_Error.name = "BulletSet_Error";
                    BulletSet_Error.GetComponent<A01_BS_Error>().canStartMoving = true;
                    if (!boss.gameObject.GetComponent<BossRandomMoveInArea>())
                    {
                        boss.gameObject.AddComponent("BossRandomMoveInArea");
                        boss.gameObject.GetComponent<BossRandomMoveInArea>().startTime = Time.time;
                        boss.gameObject.GetComponent<BossRandomMoveInArea>().localStartTime = Time.time;
                        boss.gameObject.GetComponent<BossRandomMoveInArea>().x1 = StageRefPoint.x + 12.0f;
                        boss.gameObject.GetComponent<BossRandomMoveInArea>().z1 = StageRefPoint.z + 28.0f;
                        boss.gameObject.GetComponent<BossRandomMoveInArea>().x2 = StageRefPoint.x + 24.0f;
                        boss.gameObject.GetComponent<BossRandomMoveInArea>().z2 = StageRefPoint.z + 36.0f;
                        boss.gameObject.GetComponent<BossRandomMoveInArea>().r = 4.0f;
                        boss.gameObject.GetComponent<BossRandomMoveInArea>().oriPos = transform.position;
                    }
                    
                } else if (k < 95)
                { // start random bullet
                    for (int i=0; i<=2; i++)
                    {
                        float angle = Random.value * 2.0f * Mathf.PI;
                        float speed = Random.value * 8.0f + 6.0f;
                        BulletX = (GameObject)Instantiate(BulletB, transform.position, transform.rotation);
                        BulletX.AddComponent("A01_Error_B2");
                        BulletX.GetComponent<A01_Error_B2>().startTime = Time.time;
                        BulletX.GetComponent<A01_Error_B2>().vx = speed * Mathf.Sin(angle);
                        BulletX.GetComponent<A01_Error_B2>().vz = speed * Mathf.Cos(angle);
                        BulletX.GetComponent<A01_Error_B2>().oriPos = transform.position;
                        Destroy(BulletX.gameObject, 6.0f);
                        BulletX.rigidbody.useGravity = false;
                    }
                }
            }
        } else if (status.BulletPatternState == 2)
        { //Second Skill   
            //Check is just starting this skill
            if (!bossSettedUp)
            {
                if (!boss.gameObject.GetComponent<BossMoveToSpecPos>())
                {
                    boss.gameObject.AddComponent("BossMoveToSpecPos");
                    boss.gameObject.GetComponent<BossMoveToSpecPos>().x = StageRefPoint.x + 18.0f;
                    boss.gameObject.GetComponent<BossMoveToSpecPos>().z = StageRefPoint.z + 38.5f;
                    boss.gameObject.GetComponent<BossMoveToSpecPos>().moveTime = 4.0f;
                    boss.gameObject.GetComponent<BossMoveToSpecPos>().oriPos = transform.position;
                } else if (boss.gameObject.GetComponent<BossMoveToSpecPos>().isFinished)
                {
                    Destroy(boss.gameObject.GetComponent<BossMoveToSpecPos>());
                    status.isInvicible = false;
                    k = 0;
                    bossSettedUp = true;
                }
            } else
                //Check HP and jump to next skill
                if (status.HealthPoint <= 3500.0f)
            {
                status.BulletPatternState = 3;
                status.isInvicible = true;
                Util.removeAllBulletsbyTag("Tag_Bullet");
                bossSettedUp = false;
            } else
            { //Start this sill
                if (k >= 95)
                { //Reset to Stage A
                    k = 0;
                }
                if (k < 1)
                { //move boss
                    if (!boss.gameObject.GetComponent<A01_WhileTrue_Boss>())
                    {
                        boss.gameObject.AddComponent("A01_WhileTrue_Boss");
                        boss.gameObject.GetComponent<A01_WhileTrue_Boss>().center = StageRefPoint + new Vector3(18.0f, 0.0f, 22.5f);
                        boss.gameObject.GetComponent<A01_WhileTrue_Boss>().center.y = transform.position.y;
                        boss.gameObject.GetComponent<A01_WhileTrue_Boss>().moveTime = 4.0f;
                        boss.gameObject.GetComponent<A01_WhileTrue_Boss>().fadeTime = 1.0f;
                        boss.gameObject.GetComponent<A01_WhileTrue_Boss>().r = 16.0f;
                        boss.gameObject.GetComponent<A01_WhileTrue_Boss>().round = 8.0f;
                        boss.gameObject.GetComponent<A01_WhileTrue_Boss>().oriPos = transform.position;
                        j=0;
                    } else
                    {
                        //setting the bullet
                        while(j*2.0f * Mathf.PI/120.0f<=boss.gameObject.GetComponent<A01_WhileTrue_Boss>().currentAngular){
                            Vector3 bulletPos = new Vector3(16.0f*Mathf.Sin (j*2.0f * Mathf.PI/120.0f),0,16.0f*Mathf.Cos (j*2.0f * Mathf.PI/120.0f));
                            bulletPos = boss.gameObject.GetComponent<A01_WhileTrue_Boss>().center+bulletPos;
                            if (j*2.0f * Mathf.PI/120.0f < 2.0f * Mathf.PI)
                            {
                                BulletX = (GameObject)Instantiate(BulletA, bulletPos, transform.rotation);
                                
                                /*BulletX.AddComponent("A01_Error_B1");
                            BulletX.GetComponent<A01_Error_B1>().startTime = Time.time;
                            BulletX.GetComponent<A01_Error_B1>().finalPositionX = distance;
                            BulletX.GetComponent<A01_Error_B1>().finalPositionZ = distance;
                            BulletX.GetComponent<A01_Error_B1>().lastFor = 1.5f;
                            BulletX.GetComponent<A01_Error_B1>().oriPos = transform.position;*/
                                
                                BulletX.rigidbody.useGravity = false;
                            } else
                            {
                                BulletX = (GameObject)Instantiate(BulletB, bulletPos, transform.rotation);
                                
                                /*BulletX.AddComponent("A01_Error_B1");
                            BulletX.GetComponent<A01_Error_B1>().startTime = Time.time;
                            BulletX.GetComponent<A01_Error_B1>().finalPositionX = distance;
                            BulletX.GetComponent<A01_Error_B1>().finalPositionZ = distance;
                            BulletX.GetComponent<A01_Error_B1>().lastFor = 1.5f;
                            BulletX.GetComponent<A01_Error_B1>().oriPos = transform.position;*/
                                
                                BulletX.rigidbody.useGravity = false;
                            }
                            j++;
                        }
                        if (boss.gameObject.GetComponent<A01_WhileTrue_Boss>().isFinished)
                        {
                            Destroy(boss.gameObject.GetComponent<A01_WhileTrue_Boss>());
                            k ++;
                        }
                    }
                }
                
            }
        }
    }
}
//script RequireComponent(AudioSource)
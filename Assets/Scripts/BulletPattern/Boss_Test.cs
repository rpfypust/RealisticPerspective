using UnityEngine;
using System.Collections;

public class Boss_Test : MonoBehaviour
{
    public GameObject BulletRed; //red
    public GameObject BulletGreen; //green
    public GameObject BulletBlue; //blue
    public GameObject BulletD;
    private float startTime = 0.0f;
    private float lastTime = 0.0f;
    private float localStartTime = 0.0f;
    public int j = 0; //angle/bullet counter
    public int l = 0; //destroyed bullet counter
    public int step = 0; //step counter
    private GameObject BulletX; //bullets are using this to be created
    private GameObject BulletSet_Error; //trigger area for the 2nd skill
    private Vector3 normRadius; // temp value for the 3rd skill
    private float temp0; // temp value for the 3rd skill
    private float theta; // temp value for the 3rd skill
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
                if (step >= 130)
                { //Reset to step A
                    step = 0;
                }
                if (step <= 23)
                { //first red bullet
                    if ((Time.time - lastTime) > 1 / 25.0f)
                    {
                        float temp = Mathf.Sin(Time.frameCount / 50.0f);
                        float angle = (temp * 1640.0f + 90.0f) / 180.0f * Mathf.PI;
                        for (int i=0; i<6; i++)
                        {
                            angle = Mathf.PI / 36.0f * (i * 6f + j) + j / 100.0f;
                            BulletX = (GameObject)Instantiate(BulletRed, transform.position, transform.rotation);

                            BulletX.AddComponent("A01_B1");
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
                        for (int i=-3; i<=3; i++)
                        {
                            float angle = (i * 20.0f) / 180.0f * Mathf.PI;
                            BulletX = (GameObject)Instantiate(BulletGreen, transform.position, transform.rotation);
                            BulletX.layer = 15;
                            BulletX.AddComponent("A01_B2");
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
                        for (int i=0; i<120; i++)
                        {
                            float angle = (i * 3f + step * 0.5f) / 180.0f * Mathf.PI;
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
                        for (int i=0; i<120; i++)
                        {
                            float angle = (i * 3f + step * 0.5f) / 180.0f * Mathf.PI;
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
        } else if (status.BulletPatternState == 1)
        { //Second Skill   
            //Check is just starting this skill
            if (!bossSettedUp)
            {
                status.isInvicible = false;
                bossSettedUp = true;
                step = 0;
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
                if (step >= 95)
                { //Reset to Stage A
                    step = 0;
                    if (boss.gameObject.GetComponent <BossRandomMoveInArea>())
                    {
                        Destroy(boss.gameObject.GetComponent <BossRandomMoveInArea>());
                    }
                }
                if (step < 1)
                { //set up trigger area
                    BulletSet_Error = new GameObject("BulletSet_ErrorTemp");
                    BulletSet_Error.tag = "Tag_BulletSet";
                    BulletSet_Error.transform.position = transform.position;
                    BulletSet_Error.layer = 0;
                    BulletSet_Error.AddComponent("A01_BS_Error");
                    BulletSet_Error.GetComponent<CS1_Error_BulletSet>().velocity = 4.0f;
                    BulletSet_Error.GetComponent<CS1_Error_BulletSet>().boss = gameObject;

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
                    step++;

                } else if (step < 2)
                { //Drawing the circle
                    float angle = (j * -10.0f) / 180.0f * Mathf.PI;
                    BulletX = (GameObject)Instantiate(BulletBlue, transform.position, transform.rotation);
                    BulletX.transform.parent = BulletSet_Error.transform;

                    BulletX.AddComponent("A01_Error_B1");
                    BulletX.GetComponent<CS1_Error_B1>().startTime = Time.time;
                    BulletX.GetComponent<CS1_Error_B1>().finalPositionX = 5.0f * Mathf.Sin(angle);
                    BulletX.GetComponent<CS1_Error_B1>().finalPositionZ = 5.0f * Mathf.Cos(angle);
                    BulletX.GetComponent<CS1_Error_B1>().lastFor = 1.5f;
                    BulletX.GetComponent<CS1_Error_B1>().oriPos = transform.position;
                    BulletX.rigidbody.useGravity = false;
                    j++;
                    if (j >= 36)
                    {
                        step++;
                        j = 0;
                    }
                } else if (step < 3)
                { // drawing the X
                    float distance = Mathf.Sqrt(6.125f) - 2 * Mathf.Sqrt(6.125f) * j / 16.0f;

                    BulletX = (GameObject)Instantiate(BulletRed, transform.position, transform.rotation);
                    BulletX.transform.parent = BulletSet_Error.transform;
                    
                    BulletX.AddComponent("A01_Error_B1");
                    BulletX.GetComponent<CS1_Error_B1>().startTime = Time.time;
                    BulletX.GetComponent<CS1_Error_B1>().finalPositionX = distance;
                    BulletX.GetComponent<CS1_Error_B1>().finalPositionZ = distance;
                    BulletX.GetComponent<CS1_Error_B1>().lastFor = 1.5f;
                    BulletX.GetComponent<CS1_Error_B1>().oriPos = transform.position;
                    BulletX.rigidbody.useGravity = false;

                    BulletX = (GameObject)Instantiate(BulletRed, transform.position, transform.rotation);
                    BulletX.transform.parent = BulletSet_Error.transform;
                    
                    BulletX.AddComponent("A01_Error_B1");
                    BulletX.GetComponent<CS1_Error_B1>().startTime = Time.time;
                    BulletX.GetComponent<CS1_Error_B1>().finalPositionX = -distance;
                    BulletX.GetComponent<CS1_Error_B1>().finalPositionZ = distance;
                    BulletX.GetComponent<CS1_Error_B1>().lastFor = 1.5f;
                    BulletX.GetComponent<CS1_Error_B1>().oriPos = transform.position;
                    BulletX.rigidbody.useGravity = false;

                    j++;
                    if (j >= 17)
                    {
                        step++;
                        j = 0;
                    }
                } else if (step < 93)
                { //wait for the bullet is setted up

                    step++;

                } else if (step < 94)
                { //move the bullet, wait for the bullet leave boss
                    BulletSet_Error.name = "BulletSet_Error";
                    BulletSet_Error.GetComponent<CS1_Error_BulletSet>().canStartMoving = true;
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
                    
                } else if (step < 95)
                { // start random bullet
                    for (int i=0; i<=2; i++)
                    {
                        float angle = Random.value * 2.0f * Mathf.PI;
                        float speed = Random.value * 8.0f + 6.0f;
                        BulletX = (GameObject)Instantiate(BulletGreen, transform.position, transform.rotation);
                        BulletX.AddComponent("A01_Error_B2");
                        BulletX.GetComponent<CS1_Error_B2>().startTime = Time.time;
                        BulletX.GetComponent<CS1_Error_B2>().vx = speed * Mathf.Sin(angle);
                        BulletX.GetComponent<CS1_Error_B2>().vz = speed * Mathf.Cos(angle);
                        BulletX.GetComponent<CS1_Error_B2>().oriPos = transform.position;
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
                    step = 0;
                    l = 960;
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
                if (boss.gameObject.GetComponent <BossRandomMoveInArea>())
                {
                    Destroy(boss.gameObject.GetComponent <BossRandomMoveInArea>());
                }
                if (boss.gameObject.GetComponent <BossMoveToSpecPos>())
                {
                    Destroy(boss.gameObject.GetComponent <BossMoveToSpecPos>());
                }
                if (boss.gameObject.GetComponent <CS1_WhileTrue_Boss>())
                {
                    Destroy(boss.gameObject.GetComponent <CS1_WhileTrue_Boss>());
                }
            } else
            { //Start this sill
                if (step >= 3)
                { //Reset to Stage A
                    step = 0;
                }
                if (step < 1)
                { //move boss
                    if (!boss.gameObject.GetComponent<CS1_WhileTrue_Boss>())
                    {
                        boss.gameObject.AddComponent("A01_WhileTrue_Boss");
                        boss.gameObject.GetComponent<CS1_WhileTrue_Boss>().center = StageRefPoint + new Vector3(18.0f, 0.0f, 22.5f);
                        boss.gameObject.GetComponent<CS1_WhileTrue_Boss>().center.y = transform.position.y;
                        boss.gameObject.GetComponent<CS1_WhileTrue_Boss>().moveTime = 4.0f;
                        boss.gameObject.GetComponent<CS1_WhileTrue_Boss>().fadeTime = 1.0f;
                        boss.gameObject.GetComponent<CS1_WhileTrue_Boss>().r = 16.0f;
                        boss.gameObject.GetComponent<CS1_WhileTrue_Boss>().round = 8.0f;
                        boss.gameObject.GetComponent<CS1_WhileTrue_Boss>().oriPos = transform.position;
                        j = 0;
                        temp0 = Time.time;
                    } else
                    {
                        //setting the bullet
                        while (j*2.0f * Mathf.PI/120.0f<=boss.gameObject.GetComponent<CS1_WhileTrue_Boss>().currentAngular)
                        {
                            Vector3 bulletPos = new Vector3(16.0f * Mathf.Sin(j * 2.0f * Mathf.PI / 120.0f), 0, 16.0f * Mathf.Cos(j * 2.0f * Mathf.PI / 120.0f));
                            bulletPos = boss.gameObject.GetComponent<CS1_WhileTrue_Boss>().center + bulletPos;
                            float temp = j * 2.0f * Mathf.PI / 120.0f / (2.0f * Mathf.PI);
                            if (temp < 1.0f)
                            {
                                BulletX = (GameObject)Instantiate(BulletRed, bulletPos + new Vector3(0, 3.5f - Mathf.Floor(temp) * 0.5f, 0), transform.rotation);
                                
                                BulletX.AddComponent("A01_WhileTrue_B1");
                                BulletX.GetComponent<CS1_WhileTrue_B1>().refTime = temp0;

                                normRadius = boss.gameObject.GetComponent<CS1_WhileTrue_Boss>().center - bulletPos;
                                theta = Mathf.Asin(2.0f / normRadius.magnitude);
                                Debug.Log(j);
                                normRadius = Vector3.Normalize(normRadius);

                                BulletX.GetComponent<CS1_WhileTrue_B1>().vx = 4.0f * (normRadius.x * Mathf.Cos(theta) + normRadius.z * Mathf.Sin(theta));
                                BulletX.GetComponent<CS1_WhileTrue_B1>().vz = 4.0f * (-normRadius.x * Mathf.Sin(theta) + normRadius.z * Mathf.Cos(theta));
                                BulletX.GetComponent<CS1_WhileTrue_B1>().startAfter = 5.0f;
                                
                                BulletX.rigidbody.useGravity = false;

                                BulletX.AddComponent("A01_WhileTrue_BSelfDes");
                                BulletX.GetComponent<CS1_WhileTrue_BulletSelfDestroy>().destroyColTime=2;
                                BulletX.GetComponent<CS1_WhileTrue_BulletSelfDestroy>().boss = gameObject;
                            } else
                            {
                                BulletX = (GameObject)Instantiate(BulletGreen, bulletPos + new Vector3(0, 3.5f - Mathf.Floor(temp) * 0.5f, 0), transform.rotation);
                                
                                BulletX.AddComponent("A01_WhileTrue_B1");
                                BulletX.GetComponent<CS1_WhileTrue_B1>().refTime = temp0;
                                
                                normRadius = Vector3.Normalize(bulletPos - boss.gameObject.GetComponent<CS1_WhileTrue_Boss>().center);
                                
                                BulletX.GetComponent<CS1_WhileTrue_B1>().vx = normRadius.x * 4.0f;
                                BulletX.GetComponent<CS1_WhileTrue_B1>().vz = normRadius.z * 4.0f;
                                BulletX.GetComponent<CS1_WhileTrue_B1>().startAfter = 5.0f;
                                
                                BulletX.rigidbody.useGravity = false;
                                
                                BulletX.AddComponent("A01_WhileTrue_BSelfDes");
                                BulletX.GetComponent<CS1_WhileTrue_BulletSelfDestroy>().destroyColTime=3;
                                BulletX.GetComponent<CS1_WhileTrue_BulletSelfDestroy>().boss = gameObject;
                            }
                            j++;
                        }
                        //setting up finished
                        if (boss.gameObject.GetComponent<CS1_WhileTrue_Boss>().isFinished)
                        {
                            Destroy(boss.gameObject.GetComponent<CS1_WhileTrue_Boss>());
                            step ++;
                            l = l - 960; // destroyed bullet counter
                        }
                    }
                }else if (step<2){
                    //boss random moving
                    if (!boss.gameObject.GetComponent<BossRandomMoveInArea>())
                    {
                        boss.gameObject.AddComponent("BossRandomMoveInArea");
                        boss.gameObject.GetComponent<BossRandomMoveInArea>().startTime = Time.time;
                        boss.gameObject.GetComponent<BossRandomMoveInArea>().localStartTime = Time.time;
                        boss.gameObject.GetComponent<BossRandomMoveInArea>().x1 = StageRefPoint.x + 12.0f;
                        boss.gameObject.GetComponent<BossRandomMoveInArea>().z1 = StageRefPoint.z + 30.0f;
                        boss.gameObject.GetComponent<BossRandomMoveInArea>().x2 = StageRefPoint.x + 24.0f;
                        boss.gameObject.GetComponent<BossRandomMoveInArea>().z2 = StageRefPoint.z + 40.0f;
                        boss.gameObject.GetComponent<BossRandomMoveInArea>().r = 4.0f;
                        boss.gameObject.GetComponent<BossRandomMoveInArea>().oriPos = transform.position;
                    }
                    if(l>550){
                        step++;
                    }
                }else if(step<3){
                    //destroy it
                    if (boss.gameObject.GetComponent <BossRandomMoveInArea>())
                    {
                        Destroy(boss.gameObject.GetComponent <BossRandomMoveInArea>());
                    }
                    //boss move to round position
                    if (!boss.gameObject.GetComponent<BossMoveToSpecPos>())
                    {
                        boss.gameObject.AddComponent("BossMoveToSpecPos");
                        boss.gameObject.GetComponent<BossMoveToSpecPos>().x = StageRefPoint.x + 18.0f;
                        boss.gameObject.GetComponent<BossMoveToSpecPos>().z = StageRefPoint.z + 38.5f;
                        boss.gameObject.GetComponent<BossMoveToSpecPos>().moveTime = 2.0f;
                        boss.gameObject.GetComponent<BossMoveToSpecPos>().oriPos = transform.position;
                    } else if (boss.gameObject.GetComponent<BossMoveToSpecPos>().isFinished)
                    {
                        Destroy(boss.gameObject.GetComponent<BossMoveToSpecPos>());
                        step ++;
                    }
                }
                
            }
        }
    }
}
//script RequireComponent(AudioSource)
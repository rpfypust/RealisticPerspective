using UnityEngine;
using System.Collections;

public class Boss_CS : MonoBehaviour
{
    public GameObject BulletRed; //red
    public GameObject BulletGreen; //green
    public GameObject BulletBlue; //blue
    public GameObject BulletD;

    private float startTime = 0.0f;
    private float lastTime = 0.0f;
    private float localStartTime = 0.0f;

    public int j = 0; //angle/bullet counter //use only in skill
    public int l = 0; //destroyed bullet counter //use only in skill
    public int step = 0; //step counter //use only in skill
    private GameObject BulletX; //bullets are using this to be created
    private GameObject BulletSet_Error; //trigger area for the 2nd skill
    private Vector3 normRadius; // temp value for the 3rd skill
    private float temp0; // temp value for the 3rd skill
    private float theta; // temp value for the 3rd skill

    private Vector3 StageRefPoint;
    private BossStatus status;
    private Transform boss;
    private int bossState;
    
    void Awake()
    {
        startTime = Time.time;
        bossState = 0;
        status = transform.parent.gameObject.GetComponent<BossStatus>();
        boss = transform.parent;
        StageRefPoint = GameObject.FindGameObjectWithTag("StageRefPoint").transform.position;

        status.isInvicible = true;
    }
    
    void FixedUpdate()
    {
        switch (bossState)
        {
            case 0:
                if (!boss.gameObject.GetComponent<BossMoveToSpecPos>())
                {
                    boss.gameObject.AddComponent("BossMoveToSpecPos");
                    boss.gameObject.GetComponent<BossMoveToSpecPos>().x = StageRefPoint.x + 16.0f;
                    boss.gameObject.GetComponent<BossMoveToSpecPos>().z = StageRefPoint.z + 30.0f;
                    boss.gameObject.GetComponent<BossMoveToSpecPos>().moveTime = 3.0f;
                    boss.gameObject.GetComponent<BossMoveToSpecPos>().oriPos = transform.position;
                } else if (boss.gameObject.GetComponent<BossMoveToSpecPos>().isFinished)
                {
                    Destroy(boss.gameObject.GetComponent<BossMoveToSpecPos>());

                    //Add CS1_0.cs
                    gameObject.AddComponent("CS1_0");
                    gameObject.GetComponent<CS1_0>().BulletRed = BulletRed;
                    gameObject.GetComponent<CS1_0>().BulletGreen = BulletGreen;
                    gameObject.GetComponent<CS1_0>().BulletBlue = BulletBlue;
                    gameObject.GetComponent<CS1_0>().BulletD = BulletD;
                    
                    gameObject.GetComponent<CS1_0>().StageRefPoint = StageRefPoint;
                    gameObject.GetComponent<CS1_0>().status = status;
                    gameObject.GetComponent<CS1_0>().boss = boss;
                            
                    status.isInvicible = false;
                    bossState = 1;
                }
                break;
            case 1:
                if (status.HealthPoint <= 4900.0f)
                {
                    if (gameObject.GetComponent<CS1_0>())
                    {
                        Destroy(gameObject.GetComponent<CS1_0>());
                    }

                    status.isInvicible = true;
                    bossState = -1;
                }
                break;
            case -1:
                if (!boss.gameObject.GetComponent<BossMoveToSpecPos>())
                {
                    boss.gameObject.AddComponent("BossMoveToSpecPos");
                    boss.gameObject.GetComponent<BossMoveToSpecPos>().x = StageRefPoint.x + 16.0f;
                    boss.gameObject.GetComponent<BossMoveToSpecPos>().z = StageRefPoint.z + 30.0f;
                    boss.gameObject.GetComponent<BossMoveToSpecPos>().moveTime = 2.0f;
                    boss.gameObject.GetComponent<BossMoveToSpecPos>().oriPos = transform.position;
                } else if (boss.gameObject.GetComponent<BossMoveToSpecPos>().isFinished)
                {
                    Destroy(boss.gameObject.GetComponent<BossMoveToSpecPos>());
                    
                    //Add CS1_Error.cs
                    gameObject.AddComponent("CS1_Error");
                    gameObject.GetComponent<CS1_Error>().BulletRed = BulletRed;
                    gameObject.GetComponent<CS1_Error>().BulletGreen = BulletGreen;
                    gameObject.GetComponent<CS1_Error>().BulletBlue = BulletBlue;
                    gameObject.GetComponent<CS1_Error>().BulletD = BulletD;
                    
                    gameObject.GetComponent<CS1_Error>().StageRefPoint = StageRefPoint;
                    gameObject.GetComponent<CS1_Error>().status = status;
                    gameObject.GetComponent<CS1_Error>().boss = boss;
                    
                    status.isInvicible = false;
                    bossState = 2;
                }
                break;
            case 2:
                if (status.HealthPoint <= 4800.0f)
                {
                    if (gameObject.GetComponent<CS1_Error>())
                    {
                        Destroy(gameObject.GetComponent<CS1_Error>());
                    }
                    
                    status.isInvicible = true;
                    bossState = -2;
                }
                break;
            case -2:
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

                    //Add CS1_WhileTrue.cs
                    gameObject.AddComponent("CS1_WhileTrue");
                    gameObject.GetComponent<CS1_WhileTrue>().BulletRed = BulletRed;
                    gameObject.GetComponent<CS1_WhileTrue>().BulletGreen = BulletGreen;
                    gameObject.GetComponent<CS1_WhileTrue>().BulletBlue = BulletBlue;
                    gameObject.GetComponent<CS1_WhileTrue>().BulletD = BulletD;
                    
                    gameObject.GetComponent<CS1_WhileTrue>().StageRefPoint = StageRefPoint;
                    gameObject.GetComponent<CS1_WhileTrue>().status = status;
                    gameObject.GetComponent<CS1_WhileTrue>().boss = boss;

                    status.isInvicible = false;
                    bossState = 3;
                }
                break;
            case 3:
                    if (status.HealthPoint <= 3500.0f)
                {
                    if (gameObject.GetComponent<CS1_WhileTrue>())
                    {
                        Destroy(gameObject.GetComponent<CS1_WhileTrue>());
                    }
                    
                    status.isInvicible = true;
                    bossState = -3;
                }
                break;
        }
    }
}
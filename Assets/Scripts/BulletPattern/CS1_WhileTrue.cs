using UnityEngine;
using System.Collections;

public class CS1_WhileTrue : MonoBehaviour
{
    public GameObject BulletRed; //red
    public GameObject BulletGreen; //green
    public GameObject BulletBlue; //blue
    public GameObject BulletD;
    
    public Vector3 StageRefPoint;
    public BossStatus status;
    public Transform boss;
    
    private float startTime = 0.0f;
    
    public int j = 0; //angle/bullet counter
    public int l = 0; //destroyed bullet counter
    public int step = 0; //step counter

    private Vector3 normRadius; // temp value for the 3rd skill
    private float temp0; // temp value for the 3rd skill
    private float theta; // temp value for the 3rd skill
    
    private GameObject BulletX; //bullets are using this to be created
    
    void Awake()
    {
        startTime = Time.time;
        j = 0;
        l = 960;
    }
    
    void OnDestroy()
    {
        Util.removeAllBulletsbyTag("Tag_Bullet");
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
    }
    
    void FixedUpdate()
    {
        if (step >= 3)
        { //Reset to Stage A
            step = 0;
        }
        if (step < 1)
        { //move boss
            if (!boss.gameObject.GetComponent<CS1_WhileTrue_Boss>())
            {
                boss.gameObject.AddComponent("CS1_WhileTrue_Boss");
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
                        
                        BulletX.AddComponent("CS1_WhileTrue_B1");
                        BulletX.GetComponent<CS1_WhileTrue_B1>().refTime = temp0;
                        
                        normRadius = boss.gameObject.GetComponent<CS1_WhileTrue_Boss>().center - bulletPos;
                        theta = Mathf.Asin(2.0f / normRadius.magnitude);
                        normRadius = Vector3.Normalize(normRadius);
                        
                        BulletX.GetComponent<CS1_WhileTrue_B1>().vx = 4.0f * (normRadius.x * Mathf.Cos(theta) + normRadius.z * Mathf.Sin(theta));
                        BulletX.GetComponent<CS1_WhileTrue_B1>().vz = 4.0f * (-normRadius.x * Mathf.Sin(theta) + normRadius.z * Mathf.Cos(theta));
                        BulletX.GetComponent<CS1_WhileTrue_B1>().startAfter = 5.0f;
                        
                        BulletX.rigidbody.useGravity = false;
                        
                        BulletX.AddComponent("CS1_WhileTrue_BulletSelfDestroy");
                        BulletX.GetComponent<CS1_WhileTrue_BulletSelfDestroy>().destroyColTime=2;
                        BulletX.GetComponent<CS1_WhileTrue_BulletSelfDestroy>().boss = gameObject;
                    } else
                    {
                        BulletX = (GameObject)Instantiate(BulletGreen, bulletPos + new Vector3(0, 3.5f - Mathf.Floor(temp) * 0.5f, 0), transform.rotation);
                        
                        BulletX.AddComponent("CS1_WhileTrue_B1");
                        BulletX.GetComponent<CS1_WhileTrue_B1>().refTime = temp0;
                        
                        normRadius = Vector3.Normalize(bulletPos - boss.gameObject.GetComponent<CS1_WhileTrue_Boss>().center);
                        
                        BulletX.GetComponent<CS1_WhileTrue_B1>().vx = normRadius.x * 4.0f;
                        BulletX.GetComponent<CS1_WhileTrue_B1>().vz = normRadius.z * 4.0f;
                        BulletX.GetComponent<CS1_WhileTrue_B1>().startAfter = 5.0f;
                        
                        BulletX.rigidbody.useGravity = false;
                        
                        BulletX.AddComponent("CS1_WhileTrue_BulletSelfDestroy");
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
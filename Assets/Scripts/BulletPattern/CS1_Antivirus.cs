using UnityEngine;
using System.Collections;

public class CS1_Antivirus : MonoBehaviour
{
    public GameObject BulletRed; //red
    public GameObject BulletGreen; //green
    public GameObject BulletBlue; //blue
    public GameObject BulletD;
    public GameObject BossObject_Tower;
    
    public Vector3 StageRefPoint;
    public BossStatus status;
    public Transform boss;
    
    private float startTime = 0.0f;
    private float lastTime = 0.0f;
    private float deltaTime = 0.0f;
    
    public float j = 0.0f; //angle direction
    public float angleAccel = 0.0f; //angle accel
    public int l = 0;
    public int step = 0; //step counter
    
    private Vector3 TowerPosition;
    private Vector3 SpawnPosition;
    
    private GameObject BulletX; //bullets are using this to be created
    private GameObject BossObject_TowerX;
    
    void Awake()
    {
        startTime = Time.time;
        j = 0;
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
        float cTime = Time.time - startTime;
        deltaTime = cTime - lastTime;

        if (step >= 88)
        { //Reset to Stage A
            step = 1;
        }
        if (step < 1)
        { 
            TowerPosition = StageRefPoint + new Vector3(18.0f,-2.0f,22.5f);
            BossObject_TowerX = (GameObject)Instantiate(BossObject_Tower, TowerPosition, new Quaternion(0,0,0,0));
            step++;
        }else if (step < 2)
        { 
            if (!BossObject_TowerX.GetComponent<UniformMotionWithinTime>())
            {
                BossObject_TowerX.AddComponent("UniformMotionWithinTime");
                BossObject_TowerX.GetComponent<UniformMotionWithinTime>().x = TowerPosition.x;
                BossObject_TowerX.GetComponent<UniformMotionWithinTime>().y = TowerPosition.y + 4.0f;
                BossObject_TowerX.GetComponent<UniformMotionWithinTime>().z = TowerPosition.z;
                BossObject_TowerX.GetComponent<UniformMotionWithinTime>().moveTime = 4.0f;
                BossObject_TowerX.GetComponent<UniformMotionWithinTime>().oriPos = TowerPosition;
            } else if (BossObject_TowerX.GetComponent<UniformMotionWithinTime>().isFinished)
            {
                Destroy(BossObject_TowerX.GetComponent<UniformMotionWithinTime>());
                step++;
            }
        }else if (step < 4)
        {

        }

        lastTime = cTime;
    }
}
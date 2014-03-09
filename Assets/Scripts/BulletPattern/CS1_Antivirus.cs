using UnityEngine;
using System.Collections;

public class CS1_Antivirus : MonoBehaviour
{
    public GameObject BulletRed; //red
    public GameObject BulletGreen; //green
    public GameObject BulletBlue; //blue
    public GameObject BulletD;
    public GameObject BossObject_Tower;
    public GameObject BossObject_Platform;
    public Vector3 StageRefPoint;
    public BossStatus status;
    public Transform boss;
    private GameObject target;
    private float startTime = 0.0f;
    private float lastTime = 0.0f;
    public float j = 0.0f; //angle direction
    public float angleSpeed = 0.0f; //angle speed
    public float angleAccel = 0.0f; //angle accel
    public int l = 0;
    public int step = 0; //step counter
    public int round = 0; //round counter
    
    private Vector3 TowerPosition;
    private Vector3 SpawnPosition;
    private GameObject BulletX; //bullets are using this to be created
    private GameObject BossObject_TowerX;
    private GameObject BossObject_PlatformX;
    
    void Awake()
    {
        startTime = Time.time;
        lastTime = 0.0f;
        target = GameObject.FindWithTag("Player");
        j = 0;
    }
    
    void OnDestroy()
    {
        Util.removeAllBulletsbyTag("Tag_Bullet");
        if (boss.gameObject.GetComponent <BossMoveToSpecPos>())
        {
            Destroy(boss.gameObject.GetComponent <BossMoveToSpecPos>());
        }
    }
    
    void FixedUpdate()
    {
        float cTime = Time.time - startTime;

        if (step >= 10)
        { //Reset to Stage A
            step = 2;
        }
        if (step < 1)
        { 
            TowerPosition = StageRefPoint + new Vector3(18.0f, -2.0f, 22.5f);
            BossObject_TowerX = (GameObject)Instantiate(BossObject_Tower, TowerPosition, new Quaternion(0, 0, 0, 0));
            step++;
            BossObject_PlatformX = (GameObject)Instantiate(BossObject_Platform, StageRefPoint + new Vector3(18.0f, -0.5f, 22.5f), new Quaternion(0, 0, 0, 0));
        } else if (step < 2)
        { 
            if (!BossObject_TowerX.GetComponent<UniformMotionWithinTime>())
            {
                BossObject_TowerX.AddComponent("UniformMotionWithinTime");
                BossObject_TowerX.GetComponent<UniformMotionWithinTime>().x = TowerPosition.x;
                BossObject_TowerX.GetComponent<UniformMotionWithinTime>().y = TowerPosition.y + 4.0f;
                BossObject_TowerX.GetComponent<UniformMotionWithinTime>().z = TowerPosition.z;
                BossObject_TowerX.GetComponent<UniformMotionWithinTime>().moveTime = 2.0f;
                BossObject_TowerX.GetComponent<UniformMotionWithinTime>().oriPos = TowerPosition;
            } else if (BossObject_TowerX.GetComponent<UniformMotionWithinTime>().isFinished)
            {
                Destroy(BossObject_TowerX.GetComponent<UniformMotionWithinTime>());
                TowerPosition = StageRefPoint + new Vector3(18.0f, 0.5f, 22.5f);
                step++;
            }
        } else if (step < 10)
        {
            for (int i=0; i<=2; i++)
            {
                float angle = (j + i / 3.0f) * 2.0f * Mathf.PI;
                float speed = 7.0f;
                BulletX = (GameObject)Instantiate(BulletBlue, TowerPosition, transform.rotation);
                BulletX.AddComponent("CS1_Error_B2");
                BulletX.GetComponent<CS1_Error_B2>().startTime = Time.time;
                BulletX.GetComponent<CS1_Error_B2>().vx = speed * Mathf.Sin(angle);
                BulletX.GetComponent<CS1_Error_B2>().vz = speed * Mathf.Cos(angle);
                BulletX.GetComponent<CS1_Error_B2>().oriPos = TowerPosition;
                Destroy(BulletX.gameObject, 5.0f);
                BulletX.rigidbody.useGravity = false;
            }
            j = j + angleSpeed * ((round % 2) - 0.5f) * 2.0f;
            j -= Mathf.Floor(j);
        }
        if (step == 2)
        {
            SpawnPosition = StageRefPoint;
            SpawnPosition += new Vector3(Random.value * 20.0f + 8.0f, -1.0f, Random.value * 25.0f + 10.0f);
            BossObject_PlatformX.transform.position = SpawnPosition;
            step++;
            l = 0;
        } else if (step == 3)
        {
            if (!BossObject_PlatformX.GetComponent<UniformMotionWithinTime>())
            {
                BossObject_PlatformX.AddComponent("UniformMotionWithinTime");
                BossObject_PlatformX.GetComponent<UniformMotionWithinTime>().x = SpawnPosition.x;
                BossObject_PlatformX.GetComponent<UniformMotionWithinTime>().y = SpawnPosition.y + 1.5f;
                BossObject_PlatformX.GetComponent<UniformMotionWithinTime>().z = SpawnPosition.z;
                BossObject_PlatformX.GetComponent<UniformMotionWithinTime>().moveTime = 3.0f;
                BossObject_PlatformX.GetComponent<UniformMotionWithinTime>().oriPos = SpawnPosition;
            } else if (BossObject_PlatformX.GetComponent<UniformMotionWithinTime>().isFinished)
            {
                Destroy(BossObject_PlatformX.GetComponent<UniformMotionWithinTime>());
                lastTime = cTime;
                step++;
            }
            angleSpeed += 0.00005f;
        } else if (step == 4)
        {
            if ((cTime - lastTime) > 1.5f * 4.0f / (4.0f + round))
            {
                for (int i=0; i<32; i++)
                {
                    float angle = i / 32.0f * 2.0f * Mathf.PI;
                    float speed = 5.0f * (4.0f + round) / 4.0f;
                    BulletX = (GameObject)Instantiate(BulletRed, new Vector3(TowerPosition.x, target.transform.position.y, TowerPosition.z), transform.rotation);
                    BulletX.AddComponent("CS1_Antivirus_B2");
                    BulletX.GetComponent<CS1_Antivirus_B2>().startTime = Time.time;
                    BulletX.GetComponent<CS1_Antivirus_B2>().vx = speed * Mathf.Sin(angle);
                    BulletX.GetComponent<CS1_Antivirus_B2>().vz = speed * Mathf.Cos(angle);
                    BulletX.GetComponent<CS1_Antivirus_B2>().changeTime = 0.5f * 4.0f / (4.0f + round);
                    BulletX.GetComponent<CS1_Antivirus_B2>().oriPos = TowerPosition;
                    Destroy(BulletX.gameObject, 6.0f);
                    BulletX.rigidbody.useGravity = false;
                }
                lastTime = cTime;
                l++;
                if (l >= 3 + round)
                {
                    step++;
                }
            }
            angleSpeed += 0.00005f;
        } else if (step == 5)
        {
            if ((cTime - lastTime) > 2.5f)
            {
                step++;
            }
            angleSpeed -= angleSpeed * 0.008f;
        } else if (step == 6)
        {
            if (!BossObject_PlatformX.GetComponent<UniformMotionWithinTime>())
            {
                BossObject_PlatformX.AddComponent("UniformMotionWithinTime");
                BossObject_PlatformX.GetComponent<UniformMotionWithinTime>().x = SpawnPosition.x;
                BossObject_PlatformX.GetComponent<UniformMotionWithinTime>().y = SpawnPosition.y;
                BossObject_PlatformX.GetComponent<UniformMotionWithinTime>().z = SpawnPosition.z;
                BossObject_PlatformX.GetComponent<UniformMotionWithinTime>().moveTime = 3.0f;
                BossObject_PlatformX.GetComponent<UniformMotionWithinTime>().oriPos = BossObject_PlatformX.transform.position;
            }
            step++;
            angleSpeed -= angleSpeed * 0.008f;
        } else if (step == 7)
        {
            if (BossObject_PlatformX.GetComponent<UniformMotionWithinTime>())
            {
                if (BossObject_PlatformX.GetComponent<UniformMotionWithinTime>().isFinished)
                {
                    Destroy(BossObject_PlatformX.GetComponent<UniformMotionWithinTime>());
                    lastTime = cTime;
                    step++;
                }
            }
            angleSpeed -= angleSpeed * 0.008f;
        } else if (step == 8)
        {
            angleSpeed -= 0.0001f;
            if (angleSpeed < 0.0f)
            {
                angleSpeed = 0.0f;
                step++;
            }
        } else if (step == 9)
        {
            step++;
            round++;
        }
    }
}
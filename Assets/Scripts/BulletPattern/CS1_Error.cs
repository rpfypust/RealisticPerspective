using UnityEngine;
using System.Collections;

public class CS1_Error : MonoBehaviour
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
    public int step = 0; //step counter
    
    private GameObject BulletX; //bullets are using this to be created

    private GameObject BulletSet_Error; //trigger area
    
    void Awake()
    {
        startTime = Time.time;
        j = 0;
    }
    
    void OnDestroy()
    {
        Util.removeAllBulletsbyTag("Tag_Bullet");
        Util.removeAllBulletsbyTag("Tag_BulletSet");
        if (boss.gameObject.GetComponent <BossRandomMoveInArea>())
        {
            Destroy(boss.gameObject.GetComponent <BossRandomMoveInArea>());
        }
    }
    
    void FixedUpdate()
    {
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
            BulletSet_Error.AddComponent("CS1_Error_BulletSet");
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
            
            BulletX.AddComponent("CS1_Error_B1");
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
            
            BulletX.AddComponent("CS1_Error_B1");
            BulletX.GetComponent<CS1_Error_B1>().startTime = Time.time;
            BulletX.GetComponent<CS1_Error_B1>().finalPositionX = distance;
            BulletX.GetComponent<CS1_Error_B1>().finalPositionZ = distance;
            BulletX.GetComponent<CS1_Error_B1>().lastFor = 1.5f;
            BulletX.GetComponent<CS1_Error_B1>().oriPos = transform.position;
            BulletX.rigidbody.useGravity = false;
            
            BulletX = (GameObject)Instantiate(BulletRed, transform.position, transform.rotation);
            BulletX.transform.parent = BulletSet_Error.transform;
            
            BulletX.AddComponent("CS1_Error_B1");
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
                BulletX.AddComponent("CS1_Error_B2");
                BulletX.GetComponent<CS1_Error_B2>().startTime = Time.time;
                BulletX.GetComponent<CS1_Error_B2>().vx = speed * Mathf.Sin(angle);
                BulletX.GetComponent<CS1_Error_B2>().vz = speed * Mathf.Cos(angle);
                BulletX.GetComponent<CS1_Error_B2>().oriPos = transform.position;
                Destroy(BulletX.gameObject, 6.0f);
                BulletX.rigidbody.useGravity = false;
            }
        }
    }
}
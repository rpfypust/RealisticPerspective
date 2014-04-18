using UnityEngine;
using System.Collections;

public class Boss_Phoenix : MonoBehaviour
{
    public GameObject BulletRed; //red
    public GameObject BulletGreen; //green
    public GameObject BulletBlue; //blue
    public GameObject BulletYellow;
    public GameObject BulletWhite;
    public GameObject BossObject_Phoenix_1;
    public GameObject BossObject_Phoenix_2;
    public GameObject BossObject_Phoenix_3;
    public GameObject BossObject_Phoenix_4;
    public GameObject BossObject_Phoenix_5;
    public GameObject BossObject_Phoenix_6;
    public GameObject BossObject_Phoenix_7;
    public GameObject BossObject_Phoenix_8;
    public GameObject BossObject_Phoenix_9;
    public GameObject BossObject_Phoenix_10;
    public GameObject BossObject_Phoenix_11;
    public GameObject BossObject_Phoenix_12;
    private float startTime = 0.0f;
    private float lastTime = 0.0f;
    private float localStartTime = 0.0f;
    private float countdownUntil = 0.0f;
    private Vector3 StageRefPoint;
    //private BossStatus status;
    //private Transform boss;
    private int bossState;

    private GameObject[] BossObject_Phoenix_X = new GameObject[13];
    
    void Awake()
    {
        startTime = Time.time;
        bossState = 0;
        //status = transform.parent.gameObject.GetComponent<BossStatus>();
        //boss = transform.parent;
        StageRefPoint = GameObject.FindGameObjectWithTag("StageRefPoint").transform.position;
        
        //status.isInvicible = true;
    }
    
    void FixedUpdate()
    {
        switch (bossState)
        {
            case 0:
                int angle = 0;
                Quaternion face = Quaternion.identity;
                face.eulerAngles = new Vector3(0, 90, 0);
                Vector3 tempV = StageRefPoint+new Vector3(30.0f*Mathf.Sin(angle*Mathf.Deg2Rad),3.5f,30.0f*Mathf.Cos(angle*Mathf.Deg2Rad));
                BossObject_Phoenix_X[1] = 
                    (GameObject)Instantiate(BossObject_Phoenix_1, tempV, face);

                angle += 30;
                tempV = StageRefPoint+new Vector3(30.0f*Mathf.Sin(angle*Mathf.Deg2Rad),3.5f,30.0f*Mathf.Cos(angle*Mathf.Deg2Rad));
                BossObject_Phoenix_X[2] = 
                    (GameObject)Instantiate(BossObject_Phoenix_2, tempV, face);
                
                angle += 30;
                tempV = StageRefPoint+new Vector3(30.0f*Mathf.Sin(angle*Mathf.Deg2Rad),3.5f,30.0f*Mathf.Cos(angle*Mathf.Deg2Rad));
                BossObject_Phoenix_X[3] = 
                    (GameObject)Instantiate(BossObject_Phoenix_3, tempV, face);
                
                angle += 30;
                tempV = StageRefPoint+new Vector3(30.0f*Mathf.Sin(angle*Mathf.Deg2Rad),3.5f,30.0f*Mathf.Cos(angle*Mathf.Deg2Rad));
                BossObject_Phoenix_X[4] = 
                    (GameObject)Instantiate(BossObject_Phoenix_4, tempV, face);
                
                angle += 30;
                tempV = StageRefPoint+new Vector3(30.0f*Mathf.Sin(angle*Mathf.Deg2Rad),3.5f,30.0f*Mathf.Cos(angle*Mathf.Deg2Rad));
                BossObject_Phoenix_X[5] = 
                    (GameObject)Instantiate(BossObject_Phoenix_5, tempV, face);
                
                angle += 30;
                tempV = StageRefPoint+new Vector3(30.0f*Mathf.Sin(angle*Mathf.Deg2Rad),3.5f,30.0f*Mathf.Cos(angle*Mathf.Deg2Rad));
                BossObject_Phoenix_X[6] = 
                    (GameObject)Instantiate(BossObject_Phoenix_6, tempV, face);
                
                angle += 30;
                tempV = StageRefPoint+new Vector3(30.0f*Mathf.Sin(angle*Mathf.Deg2Rad),3.5f,30.0f*Mathf.Cos(angle*Mathf.Deg2Rad));
                BossObject_Phoenix_X[7] = 
                    (GameObject)Instantiate(BossObject_Phoenix_7, tempV, face);
                
                angle += 30;
                tempV = StageRefPoint+new Vector3(30.0f*Mathf.Sin(angle*Mathf.Deg2Rad),3.5f,30.0f*Mathf.Cos(angle*Mathf.Deg2Rad));
                BossObject_Phoenix_X[8] = 
                    (GameObject)Instantiate(BossObject_Phoenix_8, tempV, face);
                
                angle += 30;
                tempV = StageRefPoint+new Vector3(30.0f*Mathf.Sin(angle*Mathf.Deg2Rad),3.5f,30.0f*Mathf.Cos(angle*Mathf.Deg2Rad));
                BossObject_Phoenix_X[9] = 
                    (GameObject)Instantiate(BossObject_Phoenix_9, tempV, face);
                
                angle += 30;
                tempV = StageRefPoint+new Vector3(30.0f*Mathf.Sin(angle*Mathf.Deg2Rad),3.5f,30.0f*Mathf.Cos(angle*Mathf.Deg2Rad));
                BossObject_Phoenix_X[10] = 
                    (GameObject)Instantiate(BossObject_Phoenix_10, tempV, face);
                
                angle += 30;
                tempV = StageRefPoint+new Vector3(30.0f*Mathf.Sin(angle*Mathf.Deg2Rad),3.5f,30.0f*Mathf.Cos(angle*Mathf.Deg2Rad));
                BossObject_Phoenix_X[11] = 
                    (GameObject)Instantiate(BossObject_Phoenix_11, tempV, face);
                
                angle += 30;
                tempV = StageRefPoint+new Vector3(30.0f*Mathf.Sin(angle*Mathf.Deg2Rad),3.5f,30.0f*Mathf.Cos(angle*Mathf.Deg2Rad));
                BossObject_Phoenix_X[12] = 
                    (GameObject)Instantiate(BossObject_Phoenix_12, tempV, face);
                bossState++;
            
                bossState = -1;
                break;
            case -1:
                if (!BossObject_Phoenix_X[1].GetComponent<BossMoveToSpecPosY>())
                {
                    BossObject_Phoenix_X[1].AddComponent("BossMoveToSpecPosY");
                    BossObject_Phoenix_X[1].GetComponent<BossMoveToSpecPosY>().y = BossObject_Phoenix_X[1].transform.position.y - 6.5f;
                    BossObject_Phoenix_X[1].GetComponent<BossMoveToSpecPosY>().moveTime = 3.0f;
                    BossObject_Phoenix_X[1].GetComponent<BossMoveToSpecPosY>().oriPos = transform.position;
                } else if (BossObject_Phoenix_X[1].GetComponent<BossMoveToSpecPosY>().isFinished)
                {
                    Destroy(BossObject_Phoenix_X[1].GetComponent<BossMoveToSpecPosY>());
                    BossObject_Phoenix_X[1].AddComponent("PH1_1");
                    BossObject_Phoenix_X[1].GetComponent<PH1_1>().StageRefPoint = StageRefPoint;
                    BossObject_Phoenix_X[1].GetComponent<PH1_1>().BulletRed = BulletRed;
                    BossObject_Phoenix_X[1].GetComponent<PH1_1>().BulletWhite = BulletWhite;
                    BossObject_Phoenix_X[1].tag = "Tag_Enemy";
                    BossObject_Phoenix_X[1].layer = 10;
                    bossState = 1;
                }
                break;
            case 1:
                if (BossObject_Phoenix_X[1].GetComponent<PH1_1>().HealthPoint <= 0.0f)
                {
                    if (BossObject_Phoenix_X[1].GetComponent<PH1_1>())
                    {
                        Destroy(BossObject_Phoenix_X[1].GetComponent<PH1_1>());
                        BossObject_Phoenix_X[1].tag = "Tag_LostFocusEnemy";
                        BossObject_Phoenix_X[1].layer = 9;
                    }
                    bossState = -2;
                }
                break;
        }
    }
}
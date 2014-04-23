using UnityEngine;
using System.Collections;

public class Boss_Phoenix_12balls : MonoBehaviour
{
    public GameObject BulletRed; //red
    public GameObject BulletGreen; //green
    public GameObject BulletBlue; //blue
    public GameObject BulletYellow;
    public GameObject BulletWhite;
    public GameObject BulletOrange;
    public GameObject BulletYellow_Big;
    public GameObject BulletPink_Big;
    public GameObject BulletCoconut;
    public GameObject BulletDisk;
    public GameObject LaserPurple;
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
    public GameObject Boss_Phoenix;
    private float startTime = 0.0f;
    private float lastTime = 0.0f;
    private float localStartTime = 0.0f;
    private float countdownUntil = 0.0f;
    private Vector3 StageRefPoint;
    private GameObject MainCamera;
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
        MainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        
        //status.isInvicible = true;
    }
    
    void FixedUpdate()
    {
        switch (bossState)
        {
            case 0:
                int angle = 0;
                Quaternion face = Quaternion.identity;
                face.eulerAngles = new Vector3(0, 115, 0);
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
                    BossObject_Phoenix_X[1].GetComponent<BossMoveToSpecPosY>().moveTime = 5.5f;
                    BossObject_Phoenix_X[1].GetComponent<BossMoveToSpecPosY>().oriPos = transform.position;
                } else if (BossObject_Phoenix_X[1].GetComponent<BossMoveToSpecPosY>().isFinished)
                {
                    Destroy(BossObject_Phoenix_X[1].GetComponent<BossMoveToSpecPosY>());
                    BossObject_Phoenix_X[1].AddComponent("PH1_1");
                    BossObject_Phoenix_X[1].GetComponent<PH1_1>().StageRefPoint = StageRefPoint;
                    BossObject_Phoenix_X[1].GetComponent<PH1_1>().BulletRed = BulletRed;
                    BossObject_Phoenix_X[1].GetComponent<PH1_1>().BulletWhite = BulletWhite;
                    BossObject_Phoenix_X[1].tag = "Tag_Enemy";
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
						BossObject_Phoenix_X[1].layer = 8;
                    }
                    bossState = -2;
                }
            break;
            case -2:
                if (!BossObject_Phoenix_X[2].GetComponent<BossMoveToSpecPosY>())
                {
                    BossObject_Phoenix_X[2].AddComponent("BossMoveToSpecPosY");
                    BossObject_Phoenix_X[2].GetComponent<BossMoveToSpecPosY>().y = BossObject_Phoenix_X[2].transform.position.y - 6.5f;
                    BossObject_Phoenix_X[2].GetComponent<BossMoveToSpecPosY>().moveTime = 5.5f;
                    BossObject_Phoenix_X[2].GetComponent<BossMoveToSpecPosY>().oriPos = transform.position;
                } else if (BossObject_Phoenix_X[2].GetComponent<BossMoveToSpecPosY>().isFinished)
                {
                    Destroy(BossObject_Phoenix_X[2].GetComponent<BossMoveToSpecPosY>());
                    BossObject_Phoenix_X[2].AddComponent("PH1_2");
                    BossObject_Phoenix_X[2].GetComponent<PH1_2>().StageRefPoint = StageRefPoint;
                    BossObject_Phoenix_X[2].GetComponent<PH1_2>().BulletRed = BulletRed;
                    BossObject_Phoenix_X[2].GetComponent<PH1_2>().BulletWhite = BulletWhite;
                    BossObject_Phoenix_X[2].GetComponent<PH1_2>().BulletYellow_Big = BulletYellow_Big;
                    BossObject_Phoenix_X[2].GetComponent<PH1_2>().LaserPurple = LaserPurple;
					BossObject_Phoenix_X[2].tag = "Tag_Enemy";
                    bossState = 2;
                }
                break;
            case 2:
                if (BossObject_Phoenix_X[2].GetComponent<PH1_2>().HealthPoint <= 0.0f)
                {
                    if (BossObject_Phoenix_X[2].GetComponent<PH1_2>())
                    {
                        Destroy(BossObject_Phoenix_X[2].GetComponent<PH1_2>());
						BossObject_Phoenix_X[2].tag = "Tag_LostFocusEnemy";
						BossObject_Phoenix_X[2].layer = 8;
                    }
                    bossState = -3;
                }
                break;
            case -3:
                if (!BossObject_Phoenix_X[3].GetComponent<BossMoveToSpecPosY>())
                {
                    BossObject_Phoenix_X[3].AddComponent("BossMoveToSpecPosY");
                    BossObject_Phoenix_X[3].GetComponent<BossMoveToSpecPosY>().y = BossObject_Phoenix_X[3].transform.position.y - 6.5f;
					BossObject_Phoenix_X[3].GetComponent<BossMoveToSpecPosY>().moveTime = 5.5f;
                    BossObject_Phoenix_X[3].GetComponent<BossMoveToSpecPosY>().oriPos = transform.position;
                } else if (BossObject_Phoenix_X[3].GetComponent<BossMoveToSpecPosY>().isFinished)
                {
                    Destroy(BossObject_Phoenix_X[3].GetComponent<BossMoveToSpecPosY>());
                    BossObject_Phoenix_X[3].AddComponent("PH1_3");
                    BossObject_Phoenix_X[3].GetComponent<PH1_3>().StageRefPoint = StageRefPoint;
                    BossObject_Phoenix_X[3].GetComponent<PH1_3>().BulletRed = BulletRed;
                    BossObject_Phoenix_X[3].GetComponent<PH1_3>().BulletYellow = BulletYellow;
					BossObject_Phoenix_X[3].tag = "Tag_Enemy";
                    bossState = 3;
                }
                break;
            case 3:
                if (BossObject_Phoenix_X[3].GetComponent<PH1_3>().HealthPoint <= 0.0f)
                {
                    if (BossObject_Phoenix_X[3].GetComponent<PH1_3>())
                    {
                        Destroy(BossObject_Phoenix_X[3].GetComponent<PH1_3>());
						BossObject_Phoenix_X[3].tag = "Tag_LostFocusEnemy";
						BossObject_Phoenix_X[3].layer = 8;
                    }
                    bossState = -4;
                }
            break;
            case -4:
                if (!BossObject_Phoenix_X[4].GetComponent<BossMoveToSpecPosY>())
                {
                    BossObject_Phoenix_X[4].AddComponent("BossMoveToSpecPosY");
                    BossObject_Phoenix_X[4].GetComponent<BossMoveToSpecPosY>().y = BossObject_Phoenix_X[4].transform.position.y - 6.5f;
					BossObject_Phoenix_X[4].GetComponent<BossMoveToSpecPosY>().moveTime = 6.0f;
                    BossObject_Phoenix_X[4].GetComponent<BossMoveToSpecPosY>().oriPos = transform.position;
                } else if (BossObject_Phoenix_X[4].GetComponent<BossMoveToSpecPosY>().isFinished)
                {
                    Destroy(BossObject_Phoenix_X[4].GetComponent<BossMoveToSpecPosY>());
                    BossObject_Phoenix_X[4].AddComponent("PH1_4");
                    BossObject_Phoenix_X[4].GetComponent<PH1_4>().StageRefPoint = StageRefPoint;
                    BossObject_Phoenix_X[4].GetComponent<PH1_4>().BulletRed = BulletRed;
                    BossObject_Phoenix_X[4].GetComponent<PH1_4>().BulletWhite = BulletWhite;
                    BossObject_Phoenix_X[4].GetComponent<PH1_4>().BulletPink_Big = BulletPink_Big;
					BossObject_Phoenix_X[4].tag = "Tag_Enemy";
                    bossState = 4;
                }
                break;
            case 4:
                if (BossObject_Phoenix_X[4].GetComponent<PH1_4>().HealthPoint <= 0.0f)
                {
                    if (BossObject_Phoenix_X[4].GetComponent<PH1_4>())
                    {
                        Destroy(BossObject_Phoenix_X[4].GetComponent<PH1_4>());
						BossObject_Phoenix_X[4].tag = "Tag_LostFocusEnemy";
						BossObject_Phoenix_X[4].layer = 8;
                    }
                    bossState = -5;
                }
                break;
            case -5:
                if (!BossObject_Phoenix_X[5].GetComponent<BossMoveToSpecPosY>())
                {
                    BossObject_Phoenix_X[5].AddComponent("BossMoveToSpecPosY");
                    BossObject_Phoenix_X[5].GetComponent<BossMoveToSpecPosY>().y = BossObject_Phoenix_X[5].transform.position.y - 6.5f;
					BossObject_Phoenix_X[5].GetComponent<BossMoveToSpecPosY>().moveTime = 5.5f;
                    BossObject_Phoenix_X[5].GetComponent<BossMoveToSpecPosY>().oriPos = transform.position;
                } else if (BossObject_Phoenix_X[5].GetComponent<BossMoveToSpecPosY>().isFinished)
                {
                    Destroy(BossObject_Phoenix_X[5].GetComponent<BossMoveToSpecPosY>());
                    BossObject_Phoenix_X[5].AddComponent("PH1_5");
                    BossObject_Phoenix_X[5].GetComponent<PH1_5>().StageRefPoint = StageRefPoint;
                    BossObject_Phoenix_X[5].GetComponent<PH1_5>().BulletRed = BulletRed;
                    BossObject_Phoenix_X[5].GetComponent<PH1_5>().BulletBlue = BulletBlue;
                    BossObject_Phoenix_X[5].GetComponent<PH1_5>().BulletYellow = BulletYellow;
                    BossObject_Phoenix_X[5].GetComponent<PH1_5>().BulletWhite = BulletWhite;
					BossObject_Phoenix_X[5].tag = "Tag_Enemy";
                    bossState = 5;
                }
                break;
            case 5:
                if (BossObject_Phoenix_X[5].GetComponent<PH1_5>().HealthPoint <= 0.0f)
                {
                    if (BossObject_Phoenix_X[5].GetComponent<PH1_5>())
                    {
                        Destroy(BossObject_Phoenix_X[5].GetComponent<PH1_5>());
						BossObject_Phoenix_X[5].tag = "Tag_LostFocusEnemy";
						BossObject_Phoenix_X[5].layer = 8;
                    }
                    bossState = -6;
                }
            break;
            case -6:
                if (!BossObject_Phoenix_X[6].GetComponent<BossMoveToSpecPosY>())
                {
                    BossObject_Phoenix_X[6].AddComponent("BossMoveToSpecPosY");
                    BossObject_Phoenix_X[6].GetComponent<BossMoveToSpecPosY>().y = BossObject_Phoenix_X[6].transform.position.y - 6.5f;
					BossObject_Phoenix_X[6].GetComponent<BossMoveToSpecPosY>().moveTime = 6.5f;
                    BossObject_Phoenix_X[6].GetComponent<BossMoveToSpecPosY>().oriPos = transform.position;
                } else if (BossObject_Phoenix_X[6].GetComponent<BossMoveToSpecPosY>().isFinished)
                {
                    Destroy(BossObject_Phoenix_X[6].GetComponent<BossMoveToSpecPosY>());
                    BossObject_Phoenix_X[6].AddComponent("PH1_6");
                    BossObject_Phoenix_X[6].GetComponent<PH1_6>().StageRefPoint = StageRefPoint;
                    BossObject_Phoenix_X[6].GetComponent<PH1_6>().BulletRed = BulletRed;
                    BossObject_Phoenix_X[6].GetComponent<PH1_6>().BulletGreen = BulletGreen;
					BossObject_Phoenix_X[6].tag = "Tag_Enemy";
                    bossState = 6;
                }
                break;
            case 6:
                if (BossObject_Phoenix_X[6].GetComponent<PH1_6>().HealthPoint <= 0.0f)
                {
                    if (BossObject_Phoenix_X[6].GetComponent<PH1_6>())
                    {
                        Destroy(BossObject_Phoenix_X[6].GetComponent<PH1_6>());
						BossObject_Phoenix_X[6].tag = "Tag_LostFocusEnemy";
						BossObject_Phoenix_X[6].layer = 8;
                    }
                    bossState = -7;
                }
                break;
            case -7:
                if (!BossObject_Phoenix_X[7].GetComponent<BossMoveToSpecPosY>())
                {
                    BossObject_Phoenix_X[7].AddComponent("BossMoveToSpecPosY");
                    BossObject_Phoenix_X[7].GetComponent<BossMoveToSpecPosY>().y = BossObject_Phoenix_X[7].transform.position.y - 6.5f;
					BossObject_Phoenix_X[7].GetComponent<BossMoveToSpecPosY>().moveTime = 5.5f;
                    BossObject_Phoenix_X[7].GetComponent<BossMoveToSpecPosY>().oriPos = transform.position;
                } else if (BossObject_Phoenix_X[7].GetComponent<BossMoveToSpecPosY>().isFinished)
                {
                    Destroy(BossObject_Phoenix_X[7].GetComponent<BossMoveToSpecPosY>());
                    BossObject_Phoenix_X[7].AddComponent("PH1_7");
                    BossObject_Phoenix_X[7].GetComponent<PH1_7>().StageRefPoint = StageRefPoint;
                    BossObject_Phoenix_X[7].GetComponent<PH1_7>().BulletRed = BulletRed;
					BossObject_Phoenix_X[7].GetComponent<PH1_7>().BulletOrange = BulletOrange;
					BossObject_Phoenix_X[7].tag = "Tag_Enemy";
                    bossState = 7;
                }
                break;
            case 7:
                if (BossObject_Phoenix_X[7].GetComponent<PH1_7>().HealthPoint <= 0.0f)
                {
                    if (BossObject_Phoenix_X[7].GetComponent<PH1_7>())
                    {
                        Destroy(BossObject_Phoenix_X[7].GetComponent<PH1_7>());
						BossObject_Phoenix_X[7].tag = "Tag_LostFocusEnemy";
						BossObject_Phoenix_X[7].layer = 8;
                    }
                    bossState = -8;
                }
                break;
            case -8:
                if (!BossObject_Phoenix_X[8].GetComponent<BossMoveToSpecPosY>())
                {
                    BossObject_Phoenix_X[8].AddComponent("BossMoveToSpecPosY");
                    BossObject_Phoenix_X[8].GetComponent<BossMoveToSpecPosY>().y = BossObject_Phoenix_X[8].transform.position.y - 6.5f;
					BossObject_Phoenix_X[8].GetComponent<BossMoveToSpecPosY>().moveTime = 5.5f;
                    BossObject_Phoenix_X[8].GetComponent<BossMoveToSpecPosY>().oriPos = transform.position;
                } else if (BossObject_Phoenix_X[8].GetComponent<BossMoveToSpecPosY>().isFinished)
                {
                    Destroy(BossObject_Phoenix_X[8].GetComponent<BossMoveToSpecPosY>());
                    BossObject_Phoenix_X[8].AddComponent("PH1_8");
                    BossObject_Phoenix_X[8].GetComponent<PH1_8>().StageRefPoint = StageRefPoint;
                    BossObject_Phoenix_X[8].GetComponent<PH1_8>().BulletRed = BulletRed;
                    BossObject_Phoenix_X[8].GetComponent<PH1_8>().BulletWhite = BulletWhite;
					BossObject_Phoenix_X[8].tag = "Tag_Enemy";
                    bossState = 8;
                }
                break;
            case 8:
                if (BossObject_Phoenix_X[8].GetComponent<PH1_8>().HealthPoint <= 0.0f)
                {
                    if (BossObject_Phoenix_X[8].GetComponent<PH1_8>())
                    {
                        Destroy(BossObject_Phoenix_X[8].GetComponent<PH1_8>());
						BossObject_Phoenix_X[8].tag = "Tag_LostFocusEnemy";
						BossObject_Phoenix_X[8].layer = 8;
                    }
                    bossState = -9;
                }
            break;
            case -9:
                if (!BossObject_Phoenix_X[9].GetComponent<BossMoveToSpecPosY>())
                {
                    BossObject_Phoenix_X[9].AddComponent("BossMoveToSpecPosY");
                    BossObject_Phoenix_X[9].GetComponent<BossMoveToSpecPosY>().y = BossObject_Phoenix_X[9].transform.position.y - 6.5f;
					BossObject_Phoenix_X[9].GetComponent<BossMoveToSpecPosY>().moveTime = 5.5f;
                    BossObject_Phoenix_X[9].GetComponent<BossMoveToSpecPosY>().oriPos = transform.position;
                } else if (BossObject_Phoenix_X[9].GetComponent<BossMoveToSpecPosY>().isFinished)
                {
                    Destroy(BossObject_Phoenix_X[9].GetComponent<BossMoveToSpecPosY>());
                    BossObject_Phoenix_X[9].AddComponent("PH1_9");
                    BossObject_Phoenix_X[9].GetComponent<PH1_9>().StageRefPoint = StageRefPoint;
                    BossObject_Phoenix_X[9].GetComponent<PH1_9>().BulletRed = BulletRed;
                    BossObject_Phoenix_X[9].GetComponent<PH1_9>().BulletOrange = BulletOrange;
                    BossObject_Phoenix_X[9].GetComponent<PH1_9>().BulletGreen = BulletGreen;
                    BossObject_Phoenix_X[9].GetComponent<PH1_9>().BulletCoconut = BulletCoconut;
					BossObject_Phoenix_X[9].tag = "Tag_Enemy";
                    bossState = 9;
                }
                break;
            case 9:
                if (BossObject_Phoenix_X[9].GetComponent<PH1_9>().HealthPoint <= 0.0f)
                {
                    if (BossObject_Phoenix_X[9].GetComponent<PH1_9>())
                    {
                        Destroy(BossObject_Phoenix_X[9].GetComponent<PH1_9>());
						BossObject_Phoenix_X[9].tag = "Tag_LostFocusEnemy";
						BossObject_Phoenix_X[9].layer = 8;
                    }
                    bossState = -10;
                }
                break;
            case -10:
                if (!BossObject_Phoenix_X[10].GetComponent<BossMoveToSpecPosY>())
                {
                    BossObject_Phoenix_X[10].AddComponent("BossMoveToSpecPosY");
                    BossObject_Phoenix_X[10].GetComponent<BossMoveToSpecPosY>().y = BossObject_Phoenix_X[10].transform.position.y - 6.5f;
					BossObject_Phoenix_X[10].GetComponent<BossMoveToSpecPosY>().moveTime = 5.5f;
                    BossObject_Phoenix_X[10].GetComponent<BossMoveToSpecPosY>().oriPos = transform.position;
                } else if (BossObject_Phoenix_X[10].GetComponent<BossMoveToSpecPosY>().isFinished)
                {
                    Destroy(BossObject_Phoenix_X[10].GetComponent<BossMoveToSpecPosY>());
                    BossObject_Phoenix_X[10].AddComponent("PH1_10");
                    BossObject_Phoenix_X[10].GetComponent<PH1_10>().StageRefPoint = StageRefPoint;
                    BossObject_Phoenix_X[10].GetComponent<PH1_10>().BulletRed = BulletRed;
                    BossObject_Phoenix_X[10].GetComponent<PH1_10>().BulletOrange = BulletOrange;
					BossObject_Phoenix_X[10].tag = "Tag_Enemy";
                    bossState = 10;
                }
                break;
            case 10:
                if (BossObject_Phoenix_X[10].GetComponent<PH1_10>().HealthPoint <= 0.0f)
                {
                    if (BossObject_Phoenix_X[10].GetComponent<PH1_10>())
                    {
                        Destroy(BossObject_Phoenix_X[10].GetComponent<PH1_10>());
						BossObject_Phoenix_X[10].tag = "Tag_LostFocusEnemy";
						BossObject_Phoenix_X[10].layer = 8;
                    }
                    bossState = -11;
                }
            break;
            case -11:
                if (!BossObject_Phoenix_X[11].GetComponent<BossMoveToSpecPosY>())
                {
                    BossObject_Phoenix_X[11].AddComponent("BossMoveToSpecPosY");
                    BossObject_Phoenix_X[11].GetComponent<BossMoveToSpecPosY>().y = BossObject_Phoenix_X[11].transform.position.y - 6.5f;
					BossObject_Phoenix_X[11].GetComponent<BossMoveToSpecPosY>().moveTime = 5.5f;
                    BossObject_Phoenix_X[11].GetComponent<BossMoveToSpecPosY>().oriPos = transform.position;
                } else if (BossObject_Phoenix_X[11].GetComponent<BossMoveToSpecPosY>().isFinished)
                {
                    Destroy(BossObject_Phoenix_X[11].GetComponent<BossMoveToSpecPosY>());
                    BossObject_Phoenix_X[11].AddComponent("PH1_11");
                    BossObject_Phoenix_X[11].GetComponent<PH1_11>().StageRefPoint = StageRefPoint;
                    BossObject_Phoenix_X[11].GetComponent<PH1_11>().BulletRed = BulletRed;
                    BossObject_Phoenix_X[11].GetComponent<PH1_11>().BulletDisk = BulletDisk;
                    BossObject_Phoenix_X[11].GetComponent<PH1_11>().BulletBlue = BulletBlue;
                    BossObject_Phoenix_X[11].GetComponent<PH1_11>().BulletWhite = BulletWhite;
					BossObject_Phoenix_X[11].tag = "Tag_Enemy";
                    bossState = 11;
                }
                break;
            case 11:
                if (BossObject_Phoenix_X[11].GetComponent<PH1_11>().HealthPoint <= 0.0f)
                {
                    if (BossObject_Phoenix_X[11].GetComponent<PH1_11>())
                    {
                        Destroy(BossObject_Phoenix_X[11].GetComponent<PH1_11>());
						BossObject_Phoenix_X[11].tag = "Tag_LostFocusEnemy";
						BossObject_Phoenix_X[11].layer = 8;
                    }
                    bossState = -12;
                }
                break;
            case -12:
                if (!BossObject_Phoenix_X[12].GetComponent<BossMoveToSpecPosY>())
                {
                    BossObject_Phoenix_X[12].AddComponent("BossMoveToSpecPosY");
                    BossObject_Phoenix_X[12].GetComponent<BossMoveToSpecPosY>().y = BossObject_Phoenix_X[12].transform.position.y - 6.5f;
					BossObject_Phoenix_X[12].GetComponent<BossMoveToSpecPosY>().moveTime = 5.5f;
                    BossObject_Phoenix_X[12].GetComponent<BossMoveToSpecPosY>().oriPos = transform.position;
                } else if (BossObject_Phoenix_X[12].GetComponent<BossMoveToSpecPosY>().isFinished)
                {
                    Destroy(BossObject_Phoenix_X[12].GetComponent<BossMoveToSpecPosY>());
                    BossObject_Phoenix_X[12].AddComponent("PH1_12");
                    BossObject_Phoenix_X[12].GetComponent<PH1_12>().StageRefPoint = StageRefPoint;
                    BossObject_Phoenix_X[12].GetComponent<PH1_12>().BulletRed = BulletRed;
                    BossObject_Phoenix_X[12].GetComponent<PH1_12>().BulletGreen = BulletGreen;
                    BossObject_Phoenix_X[12].GetComponent<PH1_12>().BulletBlue = BulletBlue;
                    BossObject_Phoenix_X[12].GetComponent<PH1_12>().BulletYellow = BulletYellow;
                    BossObject_Phoenix_X[12].GetComponent<PH1_12>().BulletWhite = BulletWhite;
                    BossObject_Phoenix_X[12].GetComponent<PH1_12>().BulletOrange = BulletOrange;
					BossObject_Phoenix_X[12].tag = "Tag_Enemy";
                    for (int i=1; i<12; i++)
                    {
                        BossObject_Phoenix_X[i].AddComponent("PH1_12_Absorb");
                        BossObject_Phoenix_X[i].GetComponent<PH1_12_Absorb>().startTime = Time.time;
                        BossObject_Phoenix_X[i].GetComponent<PH1_12_Absorb>().dest = BossObject_Phoenix_X[12].transform.position;
                        BossObject_Phoenix_X[i].GetComponent<PH1_12_Absorb>().oriPos = BossObject_Phoenix_X[i].transform.position;
                        BossObject_Phoenix_X[i].GetComponent<PH1_12_Absorb>().radius = (BossObject_Phoenix_X[12].transform.position - BossObject_Phoenix_X[i].transform.position).magnitude / 2.0f;
                        BossObject_Phoenix_X[i].GetComponent<PH1_12_Absorb>().moveTime = 5.0f;
                        
                    }
                    bossState = 12;
                }
                break;
            case 12:
                if (BossObject_Phoenix_X[12].GetComponent<PH1_12>().HealthPoint <= 0.0f)
                {
                    if (BossObject_Phoenix_X[12].GetComponent<PH1_12>())
                    {
                        Destroy(BossObject_Phoenix_X[12].GetComponent<PH1_12>());
                        Destroy(BossObject_Phoenix_X[12]);
                    }
                    GameObject[] bullets;
                    bullets = GameObject.FindGameObjectsWithTag("Tag_Bullet");
                    foreach (GameObject bullet in bullets) {
                        if(bullet.rigidbody != null){
                            bullet.rigidbody.velocity = (-bullet.rigidbody.velocity + new Vector3(0f,1f,0f)) * 5;
                        }
                    }
                    bossState = -13;
                }
                break;
            case -13:
                if (!Boss_Phoenix.GetComponent<BossMoveToSpecPosY>())
                {
                    Boss_Phoenix.AddComponent("BossMoveToSpecPosY");
                    Boss_Phoenix.GetComponent<BossMoveToSpecPosY>().y = Boss_Phoenix.transform.position.y + 25f;
                    Boss_Phoenix.GetComponent<BossMoveToSpecPosY>().moveTime = 8.0f;
                    Boss_Phoenix.GetComponent<BossMoveToSpecPosY>().oriPos = Boss_Phoenix.transform.position;
                    if (!MainCamera.GetComponent<Boss_Phoenix_CameraZoomOut>())
                    {
                        MainCamera.AddComponent("Boss_Phoenix_CameraZoomOut");
                        MainCamera.GetComponent<Boss_Phoenix_CameraZoomOut>().distance = 15.0f;
						MainCamera.GetComponent<Boss_Phoenix_CameraZoomOut>().height = 30f;//30.0f;
                        MainCamera.GetComponent<Boss_Phoenix_CameraZoomOut>().focusZSlippage = 4.0f;
                        MainCamera.GetComponent<Boss_Phoenix_CameraZoomOut>().moveTime = 4.0f;
                    }
                } else if (Boss_Phoenix.GetComponent<BossMoveToSpecPosY>().isFinished)
                {
                    Destroy(Boss_Phoenix.GetComponent<BossMoveToSpecPosY>());
                    Boss_Phoenix.tag = "Tag_Enemy";
                    Boss_Phoenix.layer = 10;
                        Boss_Phoenix.GetComponent<Boss_Phoenix>().StageRefPoint = StageRefPoint;
                    Boss_Phoenix.GetComponent<Boss_Phoenix>().status = Boss_Phoenix.GetComponent<Boss>();
                    Boss_Phoenix.GetComponent<Boss_Phoenix>().boss = Boss_Phoenix.transform;
                    Boss_Phoenix.GetComponent<Boss_Phoenix>().step = 1;
                    Destroy(gameObject);
                }
                break;
        }
    }
}
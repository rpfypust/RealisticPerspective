using UnityEngine;
using System.Collections;

public class Boss_Phoenix : MonoBehaviour
{
    public GameObject BulletRed; //red
    public GameObject BulletGreen; //green
    public GameObject BulletBlue; //blue
    public GameObject BulletYellow;
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
                break;
        }
    }
}
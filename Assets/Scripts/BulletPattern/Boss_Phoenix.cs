using UnityEngine;
using System.Collections;

public class Boss_Phoenix : MonoBehaviour
{
    public GameObject BulletRed; //red
    public GameObject BulletYellow;
    public GameObject BulletBlue;
    public GameObject BulletOrange;
    public GameObject BulletGreen;
    public GameObject BulletMeteorite;
    public GameObject BossObjectFire;
    public GameObject BossObjectGold;
    public GameObject BossObjectGround;
    public GameObject BossObjectWater;
    public GameObject BossObjectWood;
    public GameObject LaserRed;
    public GameObject LaserYellow;
    public GameObject LaserBlue;
    public GameObject LaserOrange;
    public GameObject LaserGreen;
    
    public Vector3 StageRefPoint;
    public BossStatus status;
    public Transform boss;

    private float startTime = 0.0f;
    private float lastTime = 0.0f;

    public int j = 0; //angle/bullet counter
    public int step = 0; //step counter

    private GameObject BulletX; //bullets are using this to be created
    private GameObject BossObjectFireX;
    private GameObject BossObjectGoldX;
    private GameObject BossObjectGroundX;
    private GameObject BossObjectWaterX;
    private GameObject BossObjectWoodX;

    void Awake()
    {
        startTime = Time.time;
        j = 0;
    }

    void OnDestroy()
    {
        Util.removeAllBulletsbyTag("Tag_Bullet");
    }

    void FixedUpdate()
    {
        if (step == 0)
        {
            //idle
        } else if (step <= 1)
        { 

        }
    }
}
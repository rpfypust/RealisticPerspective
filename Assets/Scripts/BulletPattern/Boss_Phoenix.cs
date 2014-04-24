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
    public Boss status;
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
    private GameObject[] Laser = new GameObject[5];
    private float radius = 31f;
    private Vector3 tempPos;
	private GameObject target;
	private SEManager sem;
	private BGMManager bgm;

    void Awake()
	{
		sem = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<SEManager>();
		bgm = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<BGMManager>();
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
            if (Time.time - lastTime > 0.5f)
            {
                tempPos = StageRefPoint + 31f * new Vector3(Mathf.Sin(j * 144f / 180f * Mathf.PI), 0f, Mathf.Cos(j * 144f / 180f * Mathf.PI));
                if (j == 0)
                {
                    BossObjectFireX = (GameObject)Instantiate(BossObjectFire, tempPos + new Vector3(5f, 36f, 5f), transform.rotation);
                    BossObjectFireX.AddComponent("PH1_Phoenix_FallDownBall");
                    BossObjectFireX.GetComponent<PH1_Phoenix_FallDownBall>().dest = tempPos;
                    BossObjectFireX.GetComponent<PH1_Phoenix_FallDownBall>().oriPos = tempPos + new Vector3(5f, 36f, 5f);
                    BossObjectFireX.GetComponent<PH1_Phoenix_FallDownBall>().moveTime = 0.6f;
                } else if (j == 1)
                {
                    BossObjectGoldX = (GameObject)Instantiate(BossObjectGold, tempPos + new Vector3(5f, 36f, 5f), transform.rotation);
                    BossObjectGoldX.AddComponent("PH1_Phoenix_FallDownBall");
                    BossObjectGoldX.GetComponent<PH1_Phoenix_FallDownBall>().dest = tempPos;
                    BossObjectGoldX.GetComponent<PH1_Phoenix_FallDownBall>().oriPos = tempPos + new Vector3(5f, 36f, 5f);
                    BossObjectGoldX.GetComponent<PH1_Phoenix_FallDownBall>().moveTime = 0.6f;
                } else if (j == 2)
                {
                    BossObjectWoodX = (GameObject)Instantiate(BossObjectWood, tempPos + new Vector3(5f, 36f, 5f), transform.rotation);
                    BossObjectWoodX.AddComponent("PH1_Phoenix_FallDownBall");
                    BossObjectWoodX.GetComponent<PH1_Phoenix_FallDownBall>().dest = tempPos;
                    BossObjectWoodX.GetComponent<PH1_Phoenix_FallDownBall>().oriPos = tempPos + new Vector3(5f, 36f, 5f);
                    BossObjectWoodX.GetComponent<PH1_Phoenix_FallDownBall>().moveTime = 0.6f;
                } else if (j == 3)
                {
                    BossObjectGroundX = (GameObject)Instantiate(BossObjectGround, tempPos + new Vector3(5f, 36f, 5f), transform.rotation);
                    BossObjectGroundX.AddComponent("PH1_Phoenix_FallDownBall");
                    BossObjectGroundX.GetComponent<PH1_Phoenix_FallDownBall>().dest = tempPos;
                    BossObjectGroundX.GetComponent<PH1_Phoenix_FallDownBall>().oriPos = tempPos + new Vector3(5f, 36f, 5f);
                    BossObjectGroundX.GetComponent<PH1_Phoenix_FallDownBall>().moveTime = 0.6f;
                } else if (j == 4)
                {
                    BossObjectWaterX = (GameObject)Instantiate(BossObjectWater, tempPos + new Vector3(5f, 36f, 5f), transform.rotation);
                    BossObjectWaterX.AddComponent("PH1_Phoenix_FallDownBall");
                    BossObjectWaterX.GetComponent<PH1_Phoenix_FallDownBall>().dest = tempPos;
                    BossObjectWaterX.GetComponent<PH1_Phoenix_FallDownBall>().oriPos = tempPos + new Vector3(5f, 36f, 5f);
                    BossObjectWaterX.GetComponent<PH1_Phoenix_FallDownBall>().moveTime = 0.6f;
                    step++;
                }
                lastTime = Time.time;
                j++;
            }
        } else if (step == 2)
        {
            if ((Time.time - lastTime) > 0.5f)
            {
                j = 0;
                tempPos = StageRefPoint + radius * new Vector3(Mathf.Sin(j * 144f / 180f * Mathf.PI), 0.5f / radius, Mathf.Cos(j * 144f / 180f * Mathf.PI));
                Laser [0] = (GameObject)Instantiate(LaserRed, tempPos, Quaternion.Euler(new Vector3(0f, j * 144f + 162f + 180f, 0f)));
                j++;
                tempPos = StageRefPoint + radius * new Vector3(Mathf.Sin(j * 144f / 180f * Mathf.PI), 0.5f / radius, Mathf.Cos(j * 144f / 180f * Mathf.PI));
                Laser [1] = (GameObject)Instantiate(LaserYellow, tempPos, Quaternion.Euler(new Vector3(0f, j * 144f + 162f + 180f, 0f)));
                j++;
                tempPos = StageRefPoint + radius * new Vector3(Mathf.Sin(j * 144f / 180f * Mathf.PI), 0.5f / radius, Mathf.Cos(j * 144f / 180f * Mathf.PI));
                Laser [2] = (GameObject)Instantiate(LaserGreen, tempPos, Quaternion.Euler(new Vector3(0f, j * 144f + 162f + 180f, 0f)));
                j++;
                tempPos = StageRefPoint + radius * new Vector3(Mathf.Sin(j * 144f / 180f * Mathf.PI), 0.5f / radius, Mathf.Cos(j * 144f / 180f * Mathf.PI));
                Laser [3] = (GameObject)Instantiate(LaserOrange, tempPos, Quaternion.Euler(new Vector3(0f, j * 144f + 162f + 180f, 0f)));
                j++;
                tempPos = StageRefPoint + radius * new Vector3(Mathf.Sin(j * 144f / 180f * Mathf.PI), 0.5f / radius, Mathf.Cos(j * 144f / 180f * Mathf.PI));
                Laser [4] = (GameObject)Instantiate(LaserBlue, tempPos, Quaternion.Euler(new Vector3(0f, j * 144f + 162f + 180f, 0f)));
                j = 0;
                lastTime = Time.time;
                step++;
            }
        } else if (step == 3)
        {
            for (int i=0; i<5; i++)
            {
                Laser [i].transform.localScale = new Vector3(1f, 1f, 2 * radius * Mathf.Cos(0.1f * Mathf.PI) * (Time.time - lastTime) / 4f);
            }
            if ((Time.time - lastTime) > 4f)
            {
                j = 0;
                step++;
            }
        } else if (step == 4)
        {
            if ((Time.time - lastTime) > 0.17f)
            {
                float angle = Random.value * 2f * Mathf.PI;
                float radius = Random.value * 40f + 5f;
                tempPos = StageRefPoint + radius * new Vector3(Mathf.Sin(angle), 0f, Mathf.Cos(angle));
                BulletX = (GameObject)Instantiate(BulletMeteorite, tempPos + new Vector3(5f, 36f, 5f), transform.rotation);
                BulletX.AddComponent("PH1_Phoenix_FallDownBall");
                BulletX.GetComponent<PH1_Phoenix_FallDownBall>().dest = tempPos;
                BulletX.GetComponent<PH1_Phoenix_FallDownBall>().oriPos = tempPos + new Vector3(5f, 36f, 5f);
                BulletX.GetComponent<PH1_Phoenix_FallDownBall>().moveTime = 1f;
                lastTime = Time.time;
                j++;
                if (j >= 25)
                {
                    j = 0;
                    step++;
                }
            }
        } else if (step == 5)
        {
            if ((Time.time - lastTime) > 0.2f)
            {
                if (j == 0)
                {
                    BossObjectFireX.AddComponent("PH1_Phoenix_Stone");
                    BossObjectFireX.GetComponent<PH1_Phoenix_Stone>().Bullet = BulletRed;
                    BossObjectFireX.GetComponent<PH1_Phoenix_Stone>().circleSize = 16;
                    BossObjectFireX.GetComponent<PH1_Phoenix_Stone>().shootInterval = 1f;
                } else if (j == 1)
                {
                    BossObjectGoldX.AddComponent("PH1_Phoenix_Stone");
                    BossObjectGoldX.GetComponent<PH1_Phoenix_Stone>().Bullet = BulletYellow;
                    BossObjectGoldX.GetComponent<PH1_Phoenix_Stone>().circleSize = 16;
                    BossObjectGoldX.GetComponent<PH1_Phoenix_Stone>().shootInterval = 1f;
                } else if (j == 2)
                {
                    BossObjectWoodX.AddComponent("PH1_Phoenix_Stone");
                    BossObjectWoodX.GetComponent<PH1_Phoenix_Stone>().Bullet = BulletGreen;
                    BossObjectWoodX.GetComponent<PH1_Phoenix_Stone>().circleSize = 16;
                    BossObjectWoodX.GetComponent<PH1_Phoenix_Stone>().shootInterval = 1f;
                } else if (j == 3)
                {
                    BossObjectGroundX.AddComponent("PH1_Phoenix_Stone");
                    BossObjectGroundX.GetComponent<PH1_Phoenix_Stone>().Bullet = BulletOrange;
                    BossObjectGroundX.GetComponent<PH1_Phoenix_Stone>().circleSize = 16;
                    BossObjectGroundX.GetComponent<PH1_Phoenix_Stone>().shootInterval = 1f;
                } else if (j == 4)
                {
                    BossObjectWaterX.AddComponent("PH1_Phoenix_Stone");
                    BossObjectWaterX.GetComponent<PH1_Phoenix_Stone>().Bullet = BulletBlue;
                    BossObjectWaterX.GetComponent<PH1_Phoenix_Stone>().circleSize = 16;
                    BossObjectWaterX.GetComponent<PH1_Phoenix_Stone>().shootInterval = 1f;
                    step++;
                }
                lastTime = Time.time;
                j++;
            }
        } else if (step == 6)
        {
            //idle
            if (status.HealthPoint <= 4500f)
            {
                j = 0;
                step++;
            }
        } else if (step == 7)
        {
            if ((Time.time - lastTime) > 3f)
            {
                if (status.HealthPoint <= 3000f)
                {
                    j = 0;
                    step++;
                } else
				{
					sem.PlaySoundEffect(1);
                    tempPos = StageRefPoint + radius * new Vector3(Mathf.Sin(j * 144f / 180f * Mathf.PI), 0.5f / radius, Mathf.Cos(j * 144f / 180f * Mathf.PI));
                    if (j == 0)
                    {
                        BulletX = (GameObject)Instantiate(LaserRed, tempPos, Quaternion.Euler(new Vector3(0f, j * 144f + 90f, 0f)));
                    } else if (j == 1)
                    {
                        BulletX = (GameObject)Instantiate(LaserYellow, tempPos, Quaternion.Euler(new Vector3(0f, j * 144f + 90f, 0f)));
                    } else if (j == 2)
                    {
                        BulletX = (GameObject)Instantiate(LaserGreen, tempPos, Quaternion.Euler(new Vector3(0f, j * 144f + 90f, 0f)));
                    } else if (j == 3)
                    {
                        BulletX = (GameObject)Instantiate(LaserOrange, tempPos, Quaternion.Euler(new Vector3(0f, j * 144f + 90f, 0f)));
                    } else if (j == 4)
                    {
                        BulletX = (GameObject)Instantiate(LaserBlue, tempPos, Quaternion.Euler(new Vector3(0f, j * 144f + 90f, 0f)));
                    }
                    BulletX.AddComponent("PH1_2_Laser");
                    BulletX.GetComponent<PH1_2_Laser>().angle = -180.0f;
                    BulletX.GetComponent<PH1_2_Laser>().maxLength = 100.0f;
                    BulletX.GetComponent<PH1_2_Laser>().duration = 3f;
                    lastTime = Time.time;
                    j++;
                    j %= 5;
                }
            }
        } else if (step == 8)
        {
            float temp = 10f;
            BossObjectFireX.AddComponent("PH1_Phoenix_Rotate");
            BossObjectFireX.GetComponent<PH1_Phoenix_Rotate>().StageRefPoint = StageRefPoint;
            BossObjectFireX.GetComponent<PH1_Phoenix_Rotate>().angularSpeed = temp;
            BossObjectGoldX.AddComponent("PH1_Phoenix_Rotate");
            BossObjectGoldX.GetComponent<PH1_Phoenix_Rotate>().StageRefPoint = StageRefPoint;
            BossObjectGoldX.GetComponent<PH1_Phoenix_Rotate>().angularSpeed = temp;
            BossObjectWoodX.AddComponent("PH1_Phoenix_Rotate");
            BossObjectWoodX.GetComponent<PH1_Phoenix_Rotate>().StageRefPoint = StageRefPoint;
            BossObjectWoodX.GetComponent<PH1_Phoenix_Rotate>().angularSpeed = temp;
            BossObjectGroundX.AddComponent("PH1_Phoenix_Rotate");
            BossObjectGroundX.GetComponent<PH1_Phoenix_Rotate>().StageRefPoint = StageRefPoint;
            BossObjectGroundX.GetComponent<PH1_Phoenix_Rotate>().angularSpeed = temp;
            BossObjectWaterX.AddComponent("PH1_Phoenix_Rotate");
            BossObjectWaterX.GetComponent<PH1_Phoenix_Rotate>().StageRefPoint = StageRefPoint;
            BossObjectWaterX.GetComponent<PH1_Phoenix_Rotate>().angularSpeed = temp;
            for (int i=0; i<5; i++)
            {
                Laser [i].AddComponent("PH1_Phoenix_Rotate");
                Laser [i].GetComponent<PH1_Phoenix_Rotate>().StageRefPoint = StageRefPoint;
                Laser [i].GetComponent<PH1_Phoenix_Rotate>().angularSpeed = temp;
            }
            for (int i=0; i<5; i++)
            { 
                tempPos = StageRefPoint + radius * new Vector3(Mathf.Sin(i * 144f / 180f * Mathf.PI), 0.5f / radius, Mathf.Cos(i * 144f / 180f * Mathf.PI));
                for (int k=-2; k<3; k++)
                {
                    if (i == 0)
                    {
                        BulletX = (GameObject)Instantiate(LaserRed, tempPos, Quaternion.Euler(new Vector3(0f, i * 144f + k * 18f + 180f, 0f)));
                        BulletX.transform.parent = BossObjectFireX.transform;
                    } else if (i == 1)
                    {
                        BulletX = (GameObject)Instantiate(LaserYellow, tempPos, Quaternion.Euler(new Vector3(0f, i * 144f + k * 18f + 180f, 0f)));
                        BulletX.transform.parent = BossObjectGoldX.transform;
                    } else if (i == 2)
                    {
                        BulletX = (GameObject)Instantiate(LaserGreen, tempPos, Quaternion.Euler(new Vector3(0f, i * 144f + k * 18f + 180f, 0f)));
                        BulletX.transform.parent = BossObjectWoodX.transform;
                    } else if (i == 3)
                    {
                        BulletX = (GameObject)Instantiate(LaserOrange, tempPos, Quaternion.Euler(new Vector3(0f, i * 144f + k * 18f + 180f, 0f)));
                        BulletX.transform.parent = BossObjectGroundX.transform;
                    } else if (i == 4)
                    {
                        BulletX = (GameObject)Instantiate(LaserBlue, tempPos, Quaternion.Euler(new Vector3(0f, i * 144f + k * 18f + 180f, 0f)));
                        BulletX.transform.parent = BossObjectWaterX.transform;
                    }
                    BulletX.AddComponent("PH1_Phoenix_ExtendLaser");
                    BulletX.GetComponent<PH1_Phoenix_ExtendLaser>().maxLength = 50f;
                    BulletX.GetComponent<PH1_Phoenix_ExtendLaser>().duration = 7f;
                }
            }
            
            step++;
        } else if (step == 9)
        {
            //idle
            if (status.HealthPoint <= 1500f)
            {
                j = 0;
                step++;
            }
        } else if (step == 10)
        {
            if ((Time.time - lastTime) > 4f)
            {
                //idle
                if (status.HealthPoint <= 400f)
                {
                    j = 0;
                    step++;
                } else
                {
                    target = GameObject.FindWithTag("Player");
                    BulletX = (GameObject)Instantiate(BulletMeteorite, target.transform.position + new Vector3(5f, 36f, 5f), transform.rotation);
                    BulletX.AddComponent("PH1_Phoenix_FallDownBall");
                    BulletX.GetComponent<PH1_Phoenix_FallDownBall>().dest = target.transform.position;
                    BulletX.GetComponent<PH1_Phoenix_FallDownBall>().oriPos = target.transform.position + new Vector3(15f, 36f, 0f);
					BulletX.GetComponent<PH1_Phoenix_FallDownBall>().moveTime = 2f;
					BulletX.GetComponent<EnemyBullet>().damage = 7.0f;
                    Destroy(BulletX, 5f);
                    lastTime = Time.time;
                }
            }
        } else if (step == 11)
        {
            BossObjectFireX.GetComponent<PH1_Phoenix_Stone>().shootInterval = 0.5f;
            BossObjectGoldX.GetComponent<PH1_Phoenix_Stone>().shootInterval = 0.5f;
            BossObjectWoodX.GetComponent<PH1_Phoenix_Stone>().shootInterval = 0.5f;
            BossObjectGroundX.GetComponent<PH1_Phoenix_Stone>().shootInterval = 0.5f;
            BossObjectWaterX.GetComponent<PH1_Phoenix_Stone>().shootInterval = 0.5f;
            Time.timeScale = 0.5f;
            step++;
        } else if (step == 12)
        {
            //idle
            if (status.HealthPoint <= 0f)
            {
                step++;
            }
        } else if (step == 13) //die
        {
            Destroy(BossObjectFireX.GetComponent<PH1_Phoenix_Stone>());
            Destroy(BossObjectGoldX.GetComponent<PH1_Phoenix_Stone>());
            Destroy(BossObjectWoodX.GetComponent<PH1_Phoenix_Stone>());
            Destroy(BossObjectGroundX.GetComponent<PH1_Phoenix_Stone>());
            Destroy(BossObjectWaterX.GetComponent<PH1_Phoenix_Stone>());
            Destroy(BossObjectFireX.GetComponent<PH1_Phoenix_Rotate>());
            Destroy(BossObjectGoldX.GetComponent<PH1_Phoenix_Rotate>());
            Destroy(BossObjectWoodX.GetComponent<PH1_Phoenix_Rotate>());
            Destroy(BossObjectGroundX.GetComponent<PH1_Phoenix_Rotate>());
            Destroy(BossObjectWaterX.GetComponent<PH1_Phoenix_Rotate>());
            for (int i=0; i<5; i++)
            {
                Destroy(Laser [i].GetComponent<PH1_Phoenix_Rotate>());
            }
            Util.removeAllBulletsbyTag("Tag_Laser");
            foreach(GameObject bullet in GameObject.FindGameObjectsWithTag("Tag_Bullet")){
                GameObject.Destroy(bullet,18f);
            }
            BossObjectFireX.AddComponent("PH1_Phoenix_StoneExplode");
            BossObjectFireX.GetComponent<PH1_Phoenix_StoneExplode>().waitTime = 6f;
            BossObjectFireX.GetComponent<PH1_Phoenix_StoneExplode>().Bullet = BulletRed;
            BossObjectGoldX.AddComponent("PH1_Phoenix_StoneExplode");
            BossObjectGoldX.GetComponent<PH1_Phoenix_StoneExplode>().waitTime = 6f;
            BossObjectGoldX.GetComponent<PH1_Phoenix_StoneExplode>().Bullet = BulletYellow;
            BossObjectWoodX.AddComponent("PH1_Phoenix_StoneExplode");
            BossObjectWoodX.GetComponent<PH1_Phoenix_StoneExplode>().waitTime = 6f;
            BossObjectWoodX.GetComponent<PH1_Phoenix_StoneExplode>().Bullet = BulletGreen;
            BossObjectGroundX.AddComponent("PH1_Phoenix_StoneExplode");
            BossObjectGroundX.GetComponent<PH1_Phoenix_StoneExplode>().waitTime = 6f;
            BossObjectGroundX.GetComponent<PH1_Phoenix_StoneExplode>().Bullet = BulletOrange;
            BossObjectWaterX.AddComponent("PH1_Phoenix_StoneExplode");
            BossObjectWaterX.GetComponent<PH1_Phoenix_StoneExplode>().waitTime = 6f;
            BossObjectWaterX.GetComponent<PH1_Phoenix_StoneExplode>().Bullet = BulletBlue;
            transform.position -= new Vector3(0f,-30f,0f);
			sem.PlaySoundEffect(8);
			bgm.StopBGM();
            Destroy(gameObject,20f);
            step++;
            
        }
    }
}
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
			if ((Time.time - lastTime) > 0.15f)
			{
				if (j == 0)
				{
					BossObjectFireX.AddComponent("PH1_Phoenix_Stone");
					BossObjectFireX.GetComponent<PH1_Phoenix_Stone>().Bullet = BulletRed;
					BossObjectFireX.GetComponent<PH1_Phoenix_Stone>().circleSize = 16;
					BossObjectFireX.GetComponent<PH1_Phoenix_Stone>().shootInterval = 0.75f;
				} else if (j == 1)
				{
					BossObjectGoldX.AddComponent("PH1_Phoenix_Stone");
					BossObjectGoldX.GetComponent<PH1_Phoenix_Stone>().Bullet = BulletYellow;
					BossObjectGoldX.GetComponent<PH1_Phoenix_Stone>().circleSize = 16;
					BossObjectGoldX.GetComponent<PH1_Phoenix_Stone>().shootInterval = 0.75f;
				} else if (j == 2)
				{
					BossObjectWoodX.AddComponent("PH1_Phoenix_Stone");
					BossObjectWoodX.GetComponent<PH1_Phoenix_Stone>().Bullet = BulletGreen;
					BossObjectWoodX.GetComponent<PH1_Phoenix_Stone>().circleSize = 16;
					BossObjectWoodX.GetComponent<PH1_Phoenix_Stone>().shootInterval = 0.75f;
				} else if (j == 3)
				{
					BossObjectGroundX.AddComponent("PH1_Phoenix_Stone");
					BossObjectGroundX.GetComponent<PH1_Phoenix_Stone>().Bullet = BulletOrange;
					BossObjectGroundX.GetComponent<PH1_Phoenix_Stone>().circleSize = 16;
					BossObjectGroundX.GetComponent<PH1_Phoenix_Stone>().shootInterval = 0.75f;
				} else if (j == 4)
				{
					BossObjectWaterX.AddComponent("PH1_Phoenix_Stone");
					BossObjectWaterX.GetComponent<PH1_Phoenix_Stone>().Bullet = BulletBlue;
					BossObjectWaterX.GetComponent<PH1_Phoenix_Stone>().circleSize = 16;
					BossObjectWaterX.GetComponent<PH1_Phoenix_Stone>().shootInterval = 0.75f;
					step++;
				}
				lastTime = Time.time;
                j++;
			}
		}
	}
}
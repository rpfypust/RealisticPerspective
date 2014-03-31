using UnityEngine;
using System.Collections;

public class Boss_CS : MonoBehaviour
{
	public GameObject BulletRed; //red
	public GameObject BulletGreen; //green
	public GameObject BulletBlue; //blue
	public GameObject BulletD;
	public GameObject BossObject_Tower;
	public GameObject BossObject_Platform;
	public GameObject BossObject_PlatformComputer;
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
				if (!boss.gameObject.GetComponent<BossMoveToSpecPos>())
				{
					boss.gameObject.AddComponent("BossMoveToSpecPos");
					boss.gameObject.GetComponent<BossMoveToSpecPos>().x = StageRefPoint.x + 16.0f;
					boss.gameObject.GetComponent<BossMoveToSpecPos>().z = StageRefPoint.z + 30.0f;
					boss.gameObject.GetComponent<BossMoveToSpecPos>().moveTime = 3.0f;
					boss.gameObject.GetComponent<BossMoveToSpecPos>().oriPos = transform.position;
				} else if (boss.gameObject.GetComponent<BossMoveToSpecPos>().isFinished)
				{
					Destroy(boss.gameObject.GetComponent<BossMoveToSpecPos>());
					//Add CS1_0.cs
					gameObject.AddComponent("CS1_0");
					gameObject.GetComponent<CS1_0>().BulletRed = BulletRed;
					gameObject.GetComponent<CS1_0>().BulletGreen = BulletGreen;
					gameObject.GetComponent<CS1_0>().BulletBlue = BulletBlue;
					gameObject.GetComponent<CS1_0>().BulletD = BulletD;
					gameObject.GetComponent<CS1_0>().StageRefPoint = StageRefPoint;
					gameObject.GetComponent<CS1_0>().status = status;
					gameObject.GetComponent<CS1_0>().boss = boss;
					status.isInvicible = false;
					bossState = 1;
				}
				break;
			case 1:
				if (status.HealthPoint <= 4900.0f)
				{
					if (gameObject.GetComponent<CS1_0>())
					{
						Destroy(gameObject.GetComponent<CS1_0>());
					}
					status.isInvicible = true;
					bossState = -1;
				}
				break;
			case -1:
				if (!boss.gameObject.GetComponent<BossMoveToSpecPos>())
				{
					boss.gameObject.AddComponent("BossMoveToSpecPos");
					boss.gameObject.GetComponent<BossMoveToSpecPos>().x = StageRefPoint.x + 16.0f;
					boss.gameObject.GetComponent<BossMoveToSpecPos>().z = StageRefPoint.z + 30.0f;
					boss.gameObject.GetComponent<BossMoveToSpecPos>().moveTime = 2.0f;
					boss.gameObject.GetComponent<BossMoveToSpecPos>().oriPos = transform.position;
				} else if (boss.gameObject.GetComponent<BossMoveToSpecPos>().isFinished)
				{
					Destroy(boss.gameObject.GetComponent<BossMoveToSpecPos>());
					//Add CS1_Error.cs
					gameObject.AddComponent("CS1_Error");
					gameObject.GetComponent<CS1_Error>().BulletRed = BulletRed;
					gameObject.GetComponent<CS1_Error>().BulletGreen = BulletGreen;
					gameObject.GetComponent<CS1_Error>().BulletBlue = BulletBlue;
					gameObject.GetComponent<CS1_Error>().BulletD = BulletD;
					gameObject.GetComponent<CS1_Error>().StageRefPoint = StageRefPoint;
					gameObject.GetComponent<CS1_Error>().status = status;
					gameObject.GetComponent<CS1_Error>().boss = boss;
					status.isInvicible = false;
					bossState = 2;
				}
				break;
			case 2:
				if (status.HealthPoint <= 4800.0f)
				{
					if (gameObject.GetComponent<CS1_Error>())
					{
						Destroy(gameObject.GetComponent<CS1_Error>());
					}
					status.isInvicible = true;
					bossState = -2;
				}
				break;
			case -2:
				if (!boss.gameObject.GetComponent<BossMoveToSpecPos>())
				{
					boss.gameObject.AddComponent("BossMoveToSpecPos");
					boss.gameObject.GetComponent<BossMoveToSpecPos>().x = StageRefPoint.x + 16.0f;
					boss.gameObject.GetComponent<BossMoveToSpecPos>().z = StageRefPoint.z + 38.0f;
					boss.gameObject.GetComponent<BossMoveToSpecPos>().moveTime = 4.0f;
					boss.gameObject.GetComponent<BossMoveToSpecPos>().oriPos = transform.position;
				} else if (boss.gameObject.GetComponent<BossMoveToSpecPos>().isFinished)
				{
					Destroy(boss.gameObject.GetComponent<BossMoveToSpecPos>());
					//Add CS1_WhileTrue.cs
					gameObject.AddComponent("CS1_WhileTrue");
					gameObject.GetComponent<CS1_WhileTrue>().BulletRed = BulletRed;
					gameObject.GetComponent<CS1_WhileTrue>().BulletGreen = BulletGreen;
					gameObject.GetComponent<CS1_WhileTrue>().BulletBlue = BulletBlue;
					gameObject.GetComponent<CS1_WhileTrue>().BulletD = BulletD;
					gameObject.GetComponent<CS1_WhileTrue>().StageRefPoint = StageRefPoint;
					gameObject.GetComponent<CS1_WhileTrue>().status = status;
					gameObject.GetComponent<CS1_WhileTrue>().boss = boss;
					status.isInvicible = false;
					bossState = 3;
				}
				break;
			case 3:
				if (status.HealthPoint <= 4700.0f)
				{
					if (gameObject.GetComponent<CS1_WhileTrue>())
					{
						Destroy(gameObject.GetComponent<CS1_WhileTrue>());
					}
					status.isInvicible = true;
					bossState = -3;
				}
				break;
			case -3:
				boss.rigidbody.MovePosition(StageRefPoint + new Vector3(16.0f, -5.0f, 24.0f));
				GameObject.FindWithTag("Tag_Enemy").tag = "Tag_LostFocusEnemy";
                //Add CS1_Antivirus.cs
				gameObject.AddComponent("CS1_Antivirus");
				gameObject.GetComponent<CS1_Antivirus>().BulletRed = BulletRed;
				gameObject.GetComponent<CS1_Antivirus>().BulletGreen = BulletGreen;
				gameObject.GetComponent<CS1_Antivirus>().BulletBlue = BulletBlue;
				gameObject.GetComponent<CS1_Antivirus>().BulletD = BulletD;
				gameObject.GetComponent<CS1_Antivirus>().BossObject_Tower = BossObject_Tower;
				gameObject.GetComponent<CS1_Antivirus>().BossObject_Platform = BossObject_Platform;
				gameObject.GetComponent<CS1_Antivirus>().StageRefPoint = StageRefPoint;
				gameObject.GetComponent<CS1_Antivirus>().status = status;
				gameObject.GetComponent<CS1_Antivirus>().boss = boss;
				countdownUntil = Time.time + 10.0f;
				bossState = 4;
				break;
			case 4:
				if (Time.time >= countdownUntil)
				{
					if (gameObject.GetComponent<CS1_Antivirus>())
					{
						Destroy(gameObject.GetComponent<CS1_Antivirus>());
					}
					boss.rigidbody.MovePosition(StageRefPoint + new Vector3(16.0f, 0.5f, 24.0f));
					GameObject.FindWithTag("Tag_LostFocusEnemy").tag = "Tag_Enemy";
					status.isInvicible = true;
					bossState = -5;
				}
				break;
			case -5:
				break;
		}
	}
}
using UnityEngine;
using System.Collections;

public class CS1_P2P : MonoBehaviour
{
	public GameObject BulletRed; //red
	public GameObject BulletGreen; //green
	public GameObject BulletBlue; //blue
	public GameObject BulletYellow;
	public GameObject BossObject_Computer;
	
	public Vector3 StageRefPoint;
	public BossStatus status;
	public Transform boss;
	private Transform player;
	
	private float startTime = 0.0f;
	private float lastStepTime = 0.0f;
	private int round = 0;
	
	public int j = 0; //angle/bullet counter
	public int step = 0; //step counter

	public int[,] g;
	private int gx = 0;
	private int gz = 0;
	private int gx2 = 0;
	private int gz2 = 0;
	private int playerX = 0;
	private int playerZ = 0;
	private int bossX = 0;
	private int bossZ = 0;
	private Vector3 ComputerApos;
	private Vector3 ComputerBpos;
	
	private GameObject ComputerA; //bullets are using this to be created
	private GameObject ComputerB; //bullets are using this to be created
	
	void Awake()
	{
		startTime = Time.time;
		j = 0;
		g = new int[8,12];
		player = GameObject.FindWithTag("Player").transform;
	}
	
	void OnDestroy()
	{
		Util.removeAllBulletsbyTag("Tag_Bullet");
		if (boss.gameObject.GetComponent <BossRandomMoveInArea>())
		{
			Destroy(boss.gameObject.GetComponent <BossRandomMoveInArea>());
		}
	}
	
	void FixedUpdate()
	{
		float cTime = Time.time - startTime;

		if (step ==0){
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
            step++;
		}else if(step == 1){

			playerX = Mathf.FloorToInt((player.position.x - StageRefPoint.x)/4.0f);
			playerZ = Mathf.FloorToInt((player.position.z - StageRefPoint.z)/4.0f);
			bossX = Mathf.FloorToInt((boss.position.x - StageRefPoint.x)/4.0f);
			bossZ = Mathf.FloorToInt((boss.position.z - StageRefPoint.z)/4.0f);
			do{
				gx = Mathf.FloorToInt(Random.value * 8);
				gz = Mathf.FloorToInt(Random.value * 12);
			}while( (g[gx,gz] == 1) || ((gx == playerX)&&(gz == playerZ)) || ((gx == bossX)&&(gz == bossZ)) );
			g[gx,gz] = 1;
			do{
				gx2 = Mathf.FloorToInt(Random.value * 8);
				gz2 = Mathf.FloorToInt(Random.value * 12);
			}while( (g[gx2,gz2] == 1) || ((gx2 == playerX)&&(gz2 == playerZ)) || ((gx2 == bossX)&&(gz2 == bossZ)) );
			g[gx2,gz2] = 1;

			ComputerApos = new Vector3(gx*4 + Random.value*4, -1.5f, gz*4 + Random.value*4);
			ComputerBpos = new Vector3(gx2*4 + Random.value*4, -1.5f, gz2*4 + Random.value*4);
			ComputerA = (GameObject)Instantiate(BossObject_Computer, ComputerApos, Quaternion.LookRotation(ComputerApos-ComputerBpos));
			ComputerB = (GameObject)Instantiate(BossObject_Computer, ComputerBpos, Quaternion.LookRotation(ComputerBpos-ComputerApos));

			ComputerA.AddComponent("CS1_P2P_Computer");
			ComputerA.GetComponent<CS1_P2P_Computer>().BulletRed = BulletRed;
			ComputerA.GetComponent<CS1_P2P_Computer>().BulletYellow = BulletYellow;
			ComputerA.GetComponent<CS1_P2P_Computer>().StageRefPoint = StageRefPoint;
			ComputerA.GetComponent<CS1_P2P_Computer>().faceTo = ComputerB.transform;
			ComputerA.GetComponent<CS1_P2P_Computer>().gx = gx;
			ComputerA.GetComponent<CS1_P2P_Computer>().gz = gz;
			ComputerA.GetComponent<CS1_P2P_Computer>().boss = transform;
			
			ComputerB.AddComponent("CS1_P2P_Computer");
			ComputerB.GetComponent<CS1_P2P_Computer>().BulletRed = BulletRed;
			ComputerB.GetComponent<CS1_P2P_Computer>().BulletYellow = BulletYellow;
			ComputerB.GetComponent<CS1_P2P_Computer>().StageRefPoint = StageRefPoint;
			ComputerB.GetComponent<CS1_P2P_Computer>().faceTo = ComputerA.transform;
			ComputerB.GetComponent<CS1_P2P_Computer>().gx = gx2;
			ComputerB.GetComponent<CS1_P2P_Computer>().gz = gz2;
			ComputerB.GetComponent<CS1_P2P_Computer>().boss = transform;

            step++;
			lastStepTime = cTime;
		}else if(step == 2){
			float timeTemp = 4.0f - 0.32f * round;
			if (timeTemp < 0.8f){
				timeTemp = 0.8f;
			}
			if(cTime - lastStepTime > timeTemp){
				step = 1;
				round++;
			}
		}
	}
}
using UnityEngine;
using System.Collections;

public class CS1_P2P : MonoBehaviour
{
	public GameObject BulletRed; //red
	public GameObject BulletGreen; //green
	public GameObject BulletBlue; //blue
	public GameObject BulletD;
	public GameObject BossObject_PlatformComputer;
	
	public Vector3 StageRefPoint;
	public BossStatus status;
	public Transform boss;
	
	private float startTime = 0.0f;
	
	public int j = 0; //angle/bullet counter
	public int l = 0; //destroyed bullet counter
	public int step = 0; //step counter

	public int round = 0;
	
	private GameObject BulletX; //bullets are using this to be created
	
	void Awake()
	{
		startTime = Time.time;
		j = 0;
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
		if (step ==0){

		}else if(step == 1){

		}
	}
}
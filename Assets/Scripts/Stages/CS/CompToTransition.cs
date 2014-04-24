using UnityEngine;
using System.Collections;

public class CompToTransition : MonoBehaviour {
	
	public GameObject bossObj;
	private Boss boss;
	private bool exiting;
	private GameController gamecon;

	void Awake()
	{
		boss = bossObj.GetComponent<Boss>();
		gamecon = GameObject.FindGameObjectWithTag(Tags.gameController)
			.GetComponent<GameController>();
		exiting = false;
	}

	void Update () {
		if (!exiting && boss.HealthPoint <= 0.0f) {
			exiting = true;
			Flag.GetInstance().CompCleared = true;
			gamecon.LoadLevel(SceneIndice.TRANSITION);
		}
	}
}

using UnityEngine;
using System.Collections;

public class CompToTransition : MonoBehaviour {
	
	public GameObject bossObj;
	private Boss boss;
	private GameController gamecon;

	void Awake()
	{
		boss = bossObj.GetComponent<Boss>();
		gamecon = GameObject.FindGameObjectWithTag(Tags.gameController)
			.GetComponent<GameController>();
	}

	void Update () {
        if (boss.HealthPoint <= 0.0f) {
			enabled = false;
            Flag.GetInstance().CompCleared = true;
            StartCoroutine(Wait());
		}
    }
    
    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(5.0f);
        gamecon.LoadLevel(SceneIndice.TRANSITION);
    }
}

using UnityEngine;
using System.Collections;

public class TeleportToCOMPBOSS : MonoBehaviour {

	private GameController gamecon;
	private Layers layer;

	void Awake()
	{
		layer = GameObject.FindGameObjectWithTag(Tags.gameController)
			.GetComponent<Layers>();
		gamecon = GameObject.FindGameObjectWithTag(Tags.gameController)
			.GetComponent<GameController>();	
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == layer.player
		    || other.gameObject.layer == layer.playerHitArea) {
			collider.enabled = false;
			gamecon.LoadLevel(SceneIndice.BOSS_COMP);
		}
	}
}

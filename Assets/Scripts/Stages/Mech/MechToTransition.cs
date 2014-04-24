using UnityEngine;
using System.Collections;

public class MechToTransition : MonoBehaviour {

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
			Flag.GetInstance().MechCleared = true;
			gamecon.LoadLevel(SceneIndice.TRANSITION);
		}
	}
}

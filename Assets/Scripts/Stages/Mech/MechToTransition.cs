using UnityEngine;
using System.Collections;

public class MechToTransition : MonoBehaviour {

	private GameController gamecon;
	private Layers layer;
	private BGMManager bgm;
	
	void Awake()
	{
		layer = GameObject.FindGameObjectWithTag(Tags.gameController)
			.GetComponent<Layers>();
		gamecon = GameObject.FindGameObjectWithTag(Tags.gameController)
			.GetComponent<GameController>();
		bgm = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<BGMManager>();
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == layer.player
		    || other.gameObject.layer == layer.playerHitArea) {
			collider.enabled = false;
			Flag.GetInstance().MechCleared = true;
			bgm.StopBGM();
			gamecon.LoadLevel(SceneIndice.TRANSITION);
		}
	}
}

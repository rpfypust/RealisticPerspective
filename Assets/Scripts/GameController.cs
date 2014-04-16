using UnityEngine;
using System.Collections;

public sealed class GameController : MonoBehaviour {

	private static GameController instance;

	void Awake()
	{
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad(gameObject);
		} else {
			Destroy(gameObject);
		}
	}
}

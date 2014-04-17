using UnityEngine;
using System.Collections;

public sealed class GameController : MonoBehaviour {

	private static GameController instance;

	private Fader fader;
	private GUIManager gman;

	void Awake()
	{
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad(gameObject);
		} else {
			Destroy(gameObject);
		}

		fader = GetComponent<Fader>();
		gman = GetComponent<GUIManager>();
	}

	public void LoadLevel(int index)
	{
		StartCoroutine(LoadLevelCoroutine(index));
	}

	private IEnumerator LoadLevelCoroutine(int index)
	{
		gman.register(fader);
		yield return StartCoroutine(fader.Fade(0f, 1f, 1f));
		Application.LoadLevel(index);
		yield return StartCoroutine(fader.Fade(1f, 0f, 1f));
		gman.unregister(fader);
	}
}

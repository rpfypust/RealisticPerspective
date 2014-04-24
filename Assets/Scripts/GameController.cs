using UnityEngine;
using System.Collections;

public sealed class GameController : MonoBehaviour {

	private static GameController instance;

	private GameOverMenu gameover;
	private Fader fader;
	private PauseScreen pauseScreen;
	private GUIManager gman;
	private BGMManager bgmm;
	private SEManager semm;
	private SEManager storysemm;

	private bool paused;

	void Awake()
	{
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad(gameObject);
		} else {
			Destroy(gameObject);
		}
		gameover = GetComponent<GameOverMenu>();
		fader = GetComponent<Fader>();
		gman = GetComponent<GUIManager>();
		pauseScreen = GetComponent<PauseScreen>();
		bgmm = GetComponent<BGMManager>();
		semm = GetComponent<SEManager>();
		GameObject storyController = GameObject.FindGameObjectWithTag(Tags.storyController);
		if (storyController != null) {
			storysemm = storyController.GetComponent<SEManager>();
		}

		paused = false;
	}

	private void LateUpdate()
	{
		if (Input.GetButtonDown("Pause")) {
			paused = !paused;
			if (paused) {
				if (bgmm.IsPlayingBGM()) {
					bgmm.PauseBGM();
				}
					semm.PauseSE();
				if (storysemm != null) 
					storysemm.PauseSE();
				Time.timeScale = 0f;
				gman.register(pauseScreen);
			} else {
				if (bgmm.IsPaused()) {
					bgmm.ResumeBGM();
				}
					semm.ResumeSE();
				if (storysemm != null) 
					storysemm.ResumeSE();
				Time.timeScale = 1f;
				gman.unregister(pauseScreen);
			}
		}
	}

	public void LoadLevel(int index)
	{
		StartCoroutine(LoadLevelCoroutine(index));
	}

	private IEnumerator LoadLevelCoroutine(int index)
	{
		if (!gman.isRegistered(fader)) {
			gman.register(fader);
			yield return StartCoroutine(fader.Fade(0f, 1f, 1f));
		}
		Application.LoadLevel(index);
		yield return StartCoroutine(fader.Fade(1f, 0f, 1f));
		gman.unregister(fader);
	}

	public void DisplayGameOverMenu()
	{
		StartCoroutine(DisplayGameOverMenuCoroutine());
	}

	private IEnumerator DisplayGameOverMenuCoroutine()
	{
		gman.register(fader);
		yield return StartCoroutine(fader.Fade(0f, 1f, 3f));
		gameover.DisplayMenu();
	}
}

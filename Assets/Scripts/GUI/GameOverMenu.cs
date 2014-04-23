using UnityEngine;
using System.Collections;

public class GameOverMenu : MonoBehaviour, IDrawable {

	private GameController gamecon;
	private GUIManager gman;
	private Rect buttonRect;

	private bool interacted;

	void Awake()
	{
		GameObject gameconobj = GameObject.FindGameObjectWithTag(Tags.gameController);
		gamecon = gameconobj.GetComponent<GameController>();
		gman = gameconobj.GetComponent<GUIManager>();
		buttonRect = new Rect(640, 216, 640, 648);
	}

	public void DisplayMenu()
	{
		interacted = false;
		gman.register(this);
	}

	void Update()
	{
		if (interacted)
			gman.unregister(this);
	}

	public void DrawOnGUI()
	{
		GUIStyle style = new GUIStyle(GUI.skin.button);
		style.fontSize = 43;

		GUILayout.BeginArea(buttonRect);
		GUILayout.BeginVertical();

		if (GUILayout.Button("Retry", style, GUILayout.ExpandHeight(true))) {
			interacted = true;
			gamecon.ReloadLevel();
		}
		if (GUILayout.Button("Back to Title", style, GUILayout.ExpandHeight(true))) {
			interacted = true;
			// load title
		}

		GUILayout.EndVertical();
		GUILayout.EndArea();
	}
}

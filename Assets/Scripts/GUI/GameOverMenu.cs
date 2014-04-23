using UnityEngine;
using System.Collections;

public class GameOverMenu : MonoBehaviour, IDrawable {

	private GameController gamecon;
	private GUIManager gman;
	private Rect buttonRect;

	private int choice;

	void Awake()
	{
		GameObject gameconobj = GameObject.FindGameObjectWithTag(Tags.gameController);
		gamecon = gameconobj.GetComponent<GameController>();
		gman = gameconobj.GetComponent<GUIManager>();
		buttonRect = new Rect(640, 216, 640, 648);
	}

	public void DisplayMenu()
	{
		choice = 0;
		gman.register(this);
	}

	void Update()
	{
		if (choice != 0) {
			switch (choice) {
			case 1:
				gamecon.LoadLevel(Application.loadedLevel);
				break;
			case 2:
				gamecon.LoadLevel(SceneIndice.TITLE);
				break;
			}
			choice = 0;
			gman.unregister(this);
		}
	}

	public void DrawOnGUI()
	{
		GUIStyle style = new GUIStyle(GUI.skin.button);
		style.fontSize = 43;

		GUILayout.BeginArea(buttonRect);
		GUILayout.BeginVertical();

		if (GUILayout.Button("Retry", style, GUILayout.ExpandHeight(true))) {
			choice = 1;
		}
		if (GUILayout.Button("Back to Title", style, GUILayout.ExpandHeight(true))) {
			choice = 2;
		}

		GUILayout.EndVertical();
		GUILayout.EndArea();
	}
}

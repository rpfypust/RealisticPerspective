using UnityEngine;

public class MainMenu : TitleScreen, IDrawable {

	private Rect buttonRect;
	private GameController gamecon;
	private GUIManager gman;

	protected override void Awake()
	{
		base.Awake();

		gamecon = GameObject.FindGameObjectWithTag(Tags.gameController)
			.GetComponent<GameController>();
		gman = GameObject.FindGameObjectWithTag(Tags.gameController)
			.GetComponent<GUIManager>();

		buttonRect = new Rect(640, 216, 640, 648);
	}

	private void OnEnable()
	{
		gman.register(this);
	}

	private void OnDisable()
	{
		gman.unregister(this);
	}

	public void DrawOnGUI()
	{
		base.DrawOnGUI();
		GUIStyle style = new GUIStyle(GUI.skin.button);
		style.fontSize = 43;

		GUILayout.BeginArea(buttonRect);
		GUILayout.BeginVertical();
		if (GUILayout.Button("New Game", style, GUILayout.ExpandHeight(true))) {
			// load the first scene
			Debug.Log("new game");
			//gamecon.LoadLevel(0);
		}
		if (GUILayout.Button("Continue", style, GUILayout.ExpandHeight(true))) {
			// get current progress from permanent storage
			// load the atrium scene
			Debug.Log("continue");
			//gamecon.LoadLevel(0);
		}
		if (GUILayout.Button("Exit", style, GUILayout.ExpandHeight(true))) {
			Application.Quit();
		}
		GUILayout.EndVertical();
		GUILayout.EndArea();
	}
}

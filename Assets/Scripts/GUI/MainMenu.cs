using UnityEngine;

public class MainMenu : MonoBehaviour, IDrawable {

	private Rect buttonRect;
	private Rect titleRect;
	private GameController gamecon;
	private GUIManager gman;

	private Texture2D bgimg;
	private Texture2D titleimg;
	private float width;
	private float height;

	private int choice;

	private void Awake()
	{
		gamecon = GameObject.FindGameObjectWithTag(Tags.gameController)
			.GetComponent<GameController>();
		gman = GameObject.FindGameObjectWithTag(Tags.gameController)
			.GetComponent<GUIManager>();
		bgimg = Resources.Load<Texture2D>("cover_1920x1080");
		titleimg = Resources.Load<Texture2D>("title_name");

		buttonRect = new Rect(700, 500, 640, 600);
		titleRect = new Rect(100, 0, 1800, 400);
		choice = 0;
	}

	private void Start()
	{
		width = GUIManager.width;
		height = GUIManager.height;
		gman.register(this);
	}

	void Update()
	{
		switch (choice) {
		case 1:
			Flag.SetInstance(new Flag());
			Flag.GetInstance().NewProgress = Flag.StoryProgress.A;
			gamecon.LoadLevel(SceneIndice.TRANSITION);
			gman.unregister(this);
			choice = 0;
			break;
		case 2:
			Flag.SetInstance(XMLUtil.LoadXML<Flag>(Application.persistentDataPath + "/save.data"));
			Flag.GetInstance().LogFlags();
			gamecon.LoadLevel(SceneIndice.TRANSITION);
			gman.unregister(this);
			choice = 0;
			break;
		}

	}

	public void DrawOnGUI()
	{
		GUI.DrawTexture(new Rect(0, 0, width, height), bgimg);
		GUI.DrawTexture(titleRect, titleimg);
		GUIStyle style = new GUIStyle(GUI.skin.button);
		style.fontSize = 140;
		style.font = GetComponent<TextMesh>().font;
		style.hover.textColor  = Color.gray;
		GUI.backgroundColor = Color.clear;

		GUILayout.BeginArea(buttonRect);
		GUILayout.BeginVertical();
		if (GUILayout.Button("New Game", style, GUILayout.Height(160))) {
			choice = 1;
		}
		if (GUILayout.Button("Continue", style, GUILayout.Height(160))) {
			choice = 2;
		}
		if (GUILayout.Button("Exit", style, GUILayout.Height(160))) {
			Application.Quit();
		}
		GUILayout.EndVertical();
		GUILayout.EndArea();
	}
}

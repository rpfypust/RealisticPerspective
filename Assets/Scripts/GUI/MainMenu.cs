using UnityEngine;

public class MainMenu : MonoBehaviour, IDrawable {

	private Rect buttonRect;
	private GameController gamecon;
	private GUIManager gman;

	private Texture2D bgimg;
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

		buttonRect = new Rect(640, 216, 640, 648);
		choice = 0;
	}

	private void Start()
	{
		width = GUIManager.width;
		height = GUIManager.height;
		gman.register(this);

		Debug.Log("in title");
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
		GUIStyle style = new GUIStyle(GUI.skin.button);
		style.fontSize = 43;

		GUILayout.BeginArea(buttonRect);
		GUILayout.BeginVertical();
		if (GUILayout.Button("New Game", style, GUILayout.ExpandHeight(true))) {
			choice = 1;
		}
		if (GUILayout.Button("Continue", style, GUILayout.ExpandHeight(true))) {
			choice = 2;
		}
		if (GUILayout.Button("Exit", style, GUILayout.ExpandHeight(true))) {
			Application.Quit();
		}
		GUILayout.EndVertical();
		GUILayout.EndArea();
	}
}

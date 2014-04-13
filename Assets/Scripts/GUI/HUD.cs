using UnityEngine;

public class HUD : MonoBehaviour, IDrawable {
	
	private Texture2D uiTex;
	private Texture2D bossBack;
	private Texture2D bossFore;
	private Texture2D hpBack;
	private Texture2D hpFore;
	private Texture2D mpBack;
	private Texture2D mpFore;

	private GUIManager gman;
	private CutSceneManager cman;

	private float width;
	private float height;

	private Player player;
	
	void Awake()
	{
		uiTex = Resources.Load<Texture2D>("ui_1920x1080");
		gman = GameObject.FindGameObjectWithTag(Tags.gameController)
			.GetComponent<GUIManager>();

		player = GameObject.FindGameObjectWithTag(Tags.player).transform.parent
			.GetComponent<Player>();

		bossBack = MakeSolid(new Color32(0x46, 0x0a, 0x04, 0xff));
		bossFore = MakeSolid(new Color32(0xc8, 0x14, 0x14, 0xff));

		hpBack = MakeSolid(new Color32(0x0a, 0x46, 0x0a, 0xff));
		hpFore = MakeSolid(new Color32(0x14, 0xc8, 0x14, 0xff));

		mpBack = mpFore = MakeSolid(Color.black);
	}
	
	void Start()
	{
		width = GUIManager.width;
		height = GUIManager.height;
	}
	
	void OnEnable()
	{
		gman.register(this);
	}
	
	void OnDisable()
	{
		gman.unregister(this);
	}

	private Texture2D MakeSolid(Color c)
	{
		Texture2D tex = new Texture2D(1, 1);
		tex.SetPixel(0, 0, c);
		tex.Apply();
		return tex;
	}
	
	public void DrawOnGUI()
	{
		DrawBossHPBar();
		DrawPlayerHPBar();
		DrawPlayerMPBar();
		DrawUI();
		DrawTime();
		DrawScore();
	}

	private void DrawBossHPBar()
	{
		GUI.DrawTexture(new Rect(18f, 4f, 1898f, 18f), bossBack);
		GUI.DrawTexture(new Rect(18f, 4f, 900f, 18f), bossFore);
	}

	private void DrawPlayerHPBar()
	{
		float length = player.HPPercent * 1227f;
		GUI.DrawTexture(new Rect(18f, 40f, 1227f, 15f), hpBack);
		GUI.DrawTexture(new Rect(18f, 40f, length, 15f), hpFore);
	}

	private void DrawPlayerMPBar()
	{
		GUI.DrawTexture(new Rect(18f, 64f, 1227f, 13f), mpBack);
	}

	private void DrawUI()
	{
		GUI.DrawTexture(new Rect(0f, 0f, width, height), uiTex);
	}

	private void DrawTime()
	{

	}

	private void DrawScore()
	{

	}
}

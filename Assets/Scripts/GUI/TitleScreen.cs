using UnityEngine;

public class TitleScreen : MonoBehaviour {

	private Texture2D bgimg;
	private float width;
	private float height;

	protected virtual void Awake()
	{
		bgimg = Resources.Load<Texture2D>("cover_1920x1080");
	}

	protected virtual void Start()
	{
		width = GUIManager.width;
		height = GUIManager.height;
	}

	public void DrawOnGUI()
	{
		GUI.DrawTexture(new Rect(0, 0, width, height), bgimg);
	}
}

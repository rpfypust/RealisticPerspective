using UnityEngine;
using System.Collections;

public class PauseScreen : MonoBehaviour, IDrawable {

	[Range(0f, 1f)]
	public float alpha;

	private float width;
	private float height;
	private Texture2D tex;

	void Awake()
	{
		tex = Util.makeSolid(new Color(0f, 0f, 0f, alpha));
		width = GUIManager.width;
		height = GUIManager.height;
	}

	public void DrawOnGUI()
	{
		GUI.DrawTexture(new Rect(0, 0, width, height), tex);
		GUIStyle style = new GUIStyle(GUI.skin.label);
		style.fontSize = 150;
		style.fontStyle = FontStyle.Bold;
		GUI.Label(new Rect(890, 440, 250, 200), "||", style);
	}
}

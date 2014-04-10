using UnityEngine;
using System.Collections;

public class DialogManager : MonoBehaviour, IDrawable {
	
	private GUIManager gman;
	private float screenHeight;
	private float screenWidth;
	
	public int characterPerSecond = 30;
	private float waitInterval;
	
	private string speaker;
	private string content;
	private int emotion;
	private Vector3 emotionPt;
	public int iconSize = 300;

	public Texture[] emotionIcons;

	void Awake()
	{
		gman = GetComponent<GUIManager>();
		screenHeight = GUIManager.height;
		screenWidth = GUIManager.width;
		
		waitInterval = 1.0f / characterPerSecond;

	}

		public void openDialog()
	{
		gman.register(this);
		speaker = "";
		content = "";
		emotion = 0;
		emotionPt = new Vector3();
	}
	
	public void closeDialog()
	{
		gman.unregister(this);
	}

	public void clearEmotion()
	{
		emotion = -1;
	}

	public IEnumerator display(Dialog d)
	{
		speaker = d.Speaker;
		emotion = d.Emotion;
		for (int i = 0; i <= d.Content.Length; i++) {
			content = d.Content.Substring(0, i);
			emotion = -1;
			yield return new WaitForSeconds(waitInterval);
		}
	}

	public IEnumerator display(Dialog d, Transform ePt)
	{
		speaker = d.Speaker;
		emotion = d.Emotion;
		for (int i = 0; i <= d.Content.Length; i++) {
			content = d.Content.Substring(0, i);
			emotionPt = Camera.main.WorldToViewportPoint(ePt.position);
			emotionPt.x = emotionPt.x * screenWidth - iconSize/2/emotionPt.z;
			emotionPt.y = (1 - emotionPt.y )* screenHeight - iconSize/2/emotionPt.z;
			yield return new WaitForSeconds(waitInterval);
		}
	}
	
	public void DrawOnGUI()
	{
		Color tmpColor = GUI.color;
		GUI.color = new Color(1,1,1,0.95f);

		GUIStyle nameStyle = new GUIStyle(GUI.skin.textArea);
		nameStyle.alignment = TextAnchor.MiddleCenter;
		nameStyle.fixedHeight = 70;
		nameStyle.fixedWidth = 250;
		nameStyle.fontSize = 40;

		GUILayout.BeginArea(new Rect(0, 740, 250, 70), GUI.skin.box);
		GUILayout.Label(speaker, nameStyle);
		GUILayout.EndArea();

		GUIStyle textStyle = new GUIStyle(GUI.skin.textArea);
		textStyle.alignment = TextAnchor.UpperLeft;
		textStyle.fixedHeight = screenHeight-810;
		textStyle.fixedWidth = screenWidth;
		textStyle.fontSize = 50;
		textStyle.padding = new RectOffset(30,30,40,40);

		GUILayout.BeginArea(new Rect(0, 810, screenWidth, screenHeight-810), GUI.skin.box);
		GUILayout.Label(content, textStyle);
		GUILayout.EndArea();

		if(emotion!=-1)
		{
			GUI.DrawTexture(new Rect(emotionPt.x, emotionPt.y, iconSize/emotionPt.z, iconSize/emotionPt.z), emotionIcons[emotion], ScaleMode.StretchToFill, true, 10.0F);
		}

		GUI.color = tmpColor;
	}
}
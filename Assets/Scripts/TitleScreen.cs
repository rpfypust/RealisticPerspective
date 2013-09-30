using UnityEngine;
using System.Collections;

public class TitleScreen : MonoBehaviour {
	
	public Texture2D backgroundImage;
	public GUISkin skin;
	
	private int optimalWidth = 1280;
	private int optimalHeight = 720;
	private Vector3 scaleVector;
	private int fontSize;
	
	void Start() {
		float scaleFactor = ((float) Screen.height) / optimalHeight;
		scaleVector = new Vector3(scaleFactor, scaleFactor, 1.0f);
		fontSize = Mathf.RoundToInt(optimalHeight * 0.04f);
	}
	
	void OnGUI() {
		GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, scaleVector);
		GUI.skin = skin;
		skin.button.fontSize = fontSize;
		
		// Draw the background image
		GUI.DrawTexture(new Rect(0, 0, optimalWidth, optimalHeight), backgroundImage, ScaleMode.StretchToFill);
		
		int areaWidth = Mathf.RoundToInt(optimalWidth / 3.0f);
		int areaHeight = Mathf.RoundToInt(optimalHeight * 0.6f);
		int areaX = optimalWidth / 2 - areaWidth / 2;
		int areaY = Mathf.RoundToInt(optimalHeight * 0.2f);
		
		GUILayout.BeginArea(new Rect(areaX, areaY, areaWidth, areaHeight));
		GUILayout.BeginVertical();
		if (GUILayout.Button("Play Game", GUILayout.ExpandHeight(true))) {
			Application.LoadLevel("testing_use");
		}
		if (GUILayout.Button("Load Game", GUILayout.ExpandHeight(true))) {
			Debug.Log("game loaded");
		}
		if (GUILayout.Button("Options", GUILayout.ExpandHeight(true))) {
			Debug.Log("options");
		}
		if (GUILayout.Button("Quit", GUILayout.ExpandHeight(true))) {
			Application.Quit();
		}
		GUILayout.EndVertical();
		GUILayout.EndArea();
	}
}

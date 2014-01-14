using UnityEngine;
using System.Collections;

public class TitleScreen : MonoBehaviour {
	
	public Texture2D backgroundImage;
	
	private Rect buttonArea;
	private Vector3 scaleVector;
	private int fontSize;
	
	private Fader fader;
	
	void Awake() {
		fader = GameObject.Find("ScreenFader").GetComponent<Fader>();
	}
	
	void Start() {
		// calculate the scale vector
		float widthRatio = Screen.width / 1920f;
		float heightRatio = Screen.height / 1080f;
		float scaleFactor = (widthRatio > heightRatio) ? heightRatio : widthRatio;
		scaleVector = new Vector3(scaleFactor, scaleFactor, 1f);
		
		// initialize the button area
		int areaWidth = 640;
		int areaHeight = 648;
		int areaX = 640;
		int areaY = 216;
		buttonArea = new Rect(areaX, areaY, areaWidth, areaHeight);
		
		// initialize the font style
		fontSize = 43;
	}
	
	void OnGUI() {
		// backup the matrix
		Matrix4x4 backupMatrix = GUI.matrix;
		
		GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, scaleVector);
		
		// Draw the background image
		GUI.DrawTexture(new Rect(0, 0, 1920, 1080), backgroundImage, ScaleMode.StretchToFill);
		
		GUIStyle buttonStyle = new GUIStyle(GUI.skin.button);
		buttonStyle.fontSize = fontSize;
		
		GUILayout.BeginArea(buttonArea);
		GUILayout.BeginVertical();
		if (GUILayout.Button("Play Game", buttonStyle, GUILayout.ExpandHeight(true))) {
			fader.LoadLevel(1);
			//Application.LoadLevel("testing_use");
		}
		if (GUILayout.Button("Load Game", buttonStyle, GUILayout.ExpandHeight(true))) {
			fader.LoadLevel(2);
			Debug.Log("game loaded");
		}
		if (GUILayout.Button("Options", buttonStyle, GUILayout.ExpandHeight(true))) {
			Debug.Log("options");
		}
		if (GUILayout.Button("Quit", buttonStyle, GUILayout.ExpandHeight(true))) {
			Application.Quit();
		}
		GUILayout.EndVertical();
		GUILayout.EndArea();
		
		// restore the matrix
		GUI.matrix = backupMatrix;
	}
}

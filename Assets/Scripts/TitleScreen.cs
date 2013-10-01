using UnityEngine;
using System.Collections;

public class TitleScreen : MonoBehaviour {
	
	public Texture2D backgroundImage;
	
	private int nativeWidth = 1280;
	private int nativeHeight = 720;
	private Rect buttonArea;
	private Vector3 scaleVector;
	private int fontSize;
	
	void Start() {
		// calculate the scale vector
		float widthRatio = ((float) Screen.width) / nativeWidth;
		float heightRatio = ((float) Screen.height) / nativeHeight;
		float scaleFactor = (widthRatio > heightRatio) ? heightRatio : widthRatio;
		scaleVector = new Vector3(scaleFactor, scaleFactor, 1.0f);
		
		// initialize the button area
		int areaWidth = Mathf.RoundToInt(nativeWidth / 3.0f);
		int areaHeight = Mathf.RoundToInt(nativeHeight * 0.6f);
		int areaX = nativeWidth / 2 - areaWidth / 2;
		int areaY = Mathf.RoundToInt(nativeHeight * 0.2f);
		buttonArea = new Rect(areaX, areaY, areaWidth, areaHeight);
		
		// initialize the font style
		fontSize = Mathf.RoundToInt(nativeHeight * 0.04f);
	}
	
	void OnGUI() {
		// backup the matrix
		Matrix4x4 backupMatrix = GUI.matrix;
		
		GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, scaleVector);
		
		// Draw the background image
		GUI.DrawTexture(new Rect(0, 0, nativeWidth, nativeHeight), backgroundImage, ScaleMode.StretchToFill);
		
		GUIStyle buttonStyle = new GUIStyle(GUI.skin.button);
		buttonStyle.fontSize = fontSize;
		
		GUILayout.BeginArea(buttonArea);
		GUILayout.BeginVertical();
		if (GUILayout.Button("Play Game", buttonStyle, GUILayout.ExpandHeight(true))) {
			Application.LoadLevel("testing_use");
		}
		if (GUILayout.Button("Load Game", buttonStyle, GUILayout.ExpandHeight(true))) {
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

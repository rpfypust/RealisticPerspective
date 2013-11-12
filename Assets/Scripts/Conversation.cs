using UnityEngine;
using System.Collections;

public class Conversation : MonoBehaviour {
	/* enum for specifying mode */
	private enum Mode {
		Chat,
		Choice
	}
	
	private Vector3 scaleVector;
	private Vector2 scrollPosition;
	
	private Mode _mode;
	private string _paragraph;
	private string _speaker;
	private string[] _choices;
	
	/* reference to flag */
	
	void Awake() {
		/* initialize reference to flag */
	}
	
	void Start() {
		float widthRatio = Screen.width / 1920f;
		float heightRatio = Screen.height / 1080f;
		float scaleFactor = (widthRatio > heightRatio) ? heightRatio : widthRatio;
		scaleVector = new Vector3(scaleFactor, scaleFactor, 1.0f);
		scrollPosition = Vector2.zero;
		
		_mode = Mode.Chat;
		_paragraph = "This is a sample paragraph";
		_speaker = "Narrator";
	}
	
	void OnGUI() {
		Matrix4x4 backupMatrix = GUI.matrix;
		GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, scaleVector);
		GUIStyle style = new GUIStyle(GUI.skin.label);
		style.fontSize = 41;
		GUILayout.BeginArea(new Rect(0, 740, 200, 70), GUI.skin.box);
		GUILayout.Label(_speaker, style);
		GUILayout.EndArea();
		GUILayout.BeginArea(new Rect(0, 810, 1980, 270), GUI.skin.box);
		scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Width(1900), GUILayout.Height(240));
		for (int i = 0; i < 100; ++i)
			GUILayout.Label(_paragraph, style);
		GUILayout.EndScrollView();
		GUILayout.EndArea();
		
		GUI.matrix = backupMatrix;
	}
}

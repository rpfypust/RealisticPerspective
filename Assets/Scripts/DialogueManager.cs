using UnityEngine;
using System.Collections;

public class DialogueManager : MonoBehaviour {
	
	private Vector3 scaleVector;
	private Vector2 scrollPosition;

	private string dialogue;
	private string speaker;
	
	void Start() {
		float widthRatio = Screen.width / 1920f;
		float heightRatio = Screen.height / 1080f;
		float scaleFactor = (widthRatio > heightRatio) ? heightRatio : widthRatio;
		scaleVector = new Vector3(scaleFactor, scaleFactor, 1.0f);
		scrollPosition = Vector2.zero;

		dialogue = "";
		speaker = "";
	}
	
	void OnGUI() {
		Matrix4x4 backupMatrix = GUI.matrix;
		GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, scaleVector);

		GUIStyle style = new GUIStyle(GUI.skin.label);
		style.fontSize = 41;

		GUILayout.BeginArea(new Rect(0, 740, 200, 70), GUI.skin.box);
		GUILayout.Label(speaker, style);
		GUILayout.EndArea();

		GUILayout.BeginArea(new Rect(0, 810, 1980, 270), GUI.skin.box);
		scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Width(1900), GUILayout.Height(240));
		GUILayout.Label(dialogue, style);
		GUILayout.EndScrollView();
		GUILayout.EndArea();

		GUILayout.BeginArea(new Rect(495, 100, 990, 500), GUI.skin.box);
		GUILayout.EndArea();
		
		GUI.matrix = backupMatrix;
	}

}

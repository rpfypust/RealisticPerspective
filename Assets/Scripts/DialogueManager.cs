using UnityEngine;
using System.Collections;

public class DialogueManager : MonoBehaviour {
	
	private Vector3 scaleVector;
	private Vector2 scrollPosition;

	public int characterPerSecond = 10;

	private Dialogue[] dialogues;
	private Dialogue currentDialogue;
	private int currentLength;
	private bool isPrinting;
	private bool isChoosing;

	void Awake() {
		this.enabled = false;
	}

	void OnEnable() {
		InvokeRepeating("increment", Time.time, 1.0f / characterPerSecond);
	}

	void Start() {
		float widthRatio = Screen.width / 1920f;
		float heightRatio = Screen.height / 1080f;
		float scaleFactor = (widthRatio > heightRatio) ? heightRatio : widthRatio;
		scaleVector = new Vector3(scaleFactor, scaleFactor, 1.0f);
		scrollPosition = Vector2.zero;

	}
	
	void OnGUI() {
		Matrix4x4 backupMatrix = GUI.matrix;
		GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, scaleVector);

		GUIStyle style = new GUIStyle(GUI.skin.label);
		style.fontSize = 41;

		GUILayout.BeginArea(new Rect(0, 740, 200, 70), GUI.skin.box);
		GUILayout.Label(currentDialogue.Speaker, style);
		GUILayout.EndArea();

		GUILayout.BeginArea(new Rect(0, 810, 1980, 270), GUI.skin.box);
		scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Width(1900), GUILayout.Height(240));
		GUILayout.Label(currentDialogue.Text.Substring(0, currentLength), style);
		GUILayout.EndScrollView();
		GUILayout.EndArea();

		GUILayout.BeginArea(new Rect(495, 100, 990, 500), GUI.skin.box);
		GUILayout.EndArea();
		
		GUI.matrix = backupMatrix;
	}

	public void showDialogue(Dialogue[] _dialogues) {
		dialogues = _dialogues;
		currentDialogue = dialogues[0];
		currentLength = 0;
		isPrinting = true;
		isChoosing = false;
		this.enabled = true;
	}

	private void increment() {
		if (currentLength < currentDialogue.Text.Length)
			currentLength++;
		else {
			isPrinting = false;
			CancelInvoke("increment");
		}
	}
}

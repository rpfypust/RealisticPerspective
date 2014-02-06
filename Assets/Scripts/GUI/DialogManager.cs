using UnityEngine;
using System.Collections;

public class DialogManager : MonoBehaviour {
	private Vector3 scaleVector;
	private Vector2 scrollPosition;

	public int characterPerSecond = 30;

	private Dialog[] dialogues;
	private int currentDialogue;
	private int currentLength;
	private bool isPrinting;
	private bool isChoosing;

	void Awake() {
		this.enabled = false;
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
		GUILayout.Label(dialogues[currentDialogue].Speaker, style);
		GUILayout.EndArea();

		GUILayout.BeginArea(new Rect(0, 810, 1980, 270), GUI.skin.box);
		scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Width(1900), GUILayout.Height(240));
		GUILayout.Label(dialogues[currentDialogue].Text.Substring(0, currentLength), style);
		GUILayout.EndScrollView();
		GUILayout.EndArea();

		GUILayout.BeginArea(new Rect(495, 100, 990, 500), GUI.skin.box);
		GUILayout.EndArea();

		GUI.matrix = backupMatrix;
	}

	void Update() {
		if (Input.GetButtonUp("Fire1")) {
			Debug.Log("button pressed");
			if (isPrinting) {
				showDialogue(currentDialogue, true);
			} else if (currentDialogue == dialogues.Length - 1) {
				this.enabled = false;
			} else {
				showDialogue(++currentDialogue);
			}
		}
	}

	public void showDialogue(Dialog[] _dialogues) {
		dialogues = _dialogues;
		currentDialogue = 0;
		this.enabled = true;
		showDialogue(0);
	}

	private void showDialogue(int i, bool immediate = false) {
		if (i > dialogues.Length - 1) {
			if (IsInvoking("printDialogue"))
				CancelInvoke("printDialogue");
			this.enabled = false;
		} else if (!immediate) {
			isPrinting = true;
			currentLength = 0;
			InvokeRepeating("printDialogue", 1.0f, 1.0f / characterPerSecond);
		} else {
			isPrinting = false;
			currentLength = dialogues[i].Text.Length;
			if (IsInvoking("printDialogue"))
				CancelInvoke("printDialogue");
		}
	}

	private void printDialogue() {
		if (currentLength < dialogues[currentDialogue].Text.Length)
			currentLength++;
		else {
			isPrinting = false;
			CancelInvoke("printDialogue");
		}
	}
}

using UnityEngine;
using System.Collections;

public class TitleScreen : MonoBehaviour {
	
	public Texture2D backgroundImage;
	public GUIStyle style;
	
	void OnGUI() {
		GUILayout.Box(backgroundImage);
		
		int areaWidth = Mathf.RoundToInt(Screen.width / 3.0f);
		int areaHeight = Mathf.RoundToInt(Screen.height * 0.8f);
		int areaX = Screen.width / 2 - areaWidth / 2;
		int areaY = Mathf.RoundToInt(Screen.height * 0.2f);
		
		GUILayout.BeginArea(new Rect(areaX, areaY, areaWidth, areaHeight));
		GUILayout.BeginVertical();
		if (GUILayout.Button("Play Game")) {
			Debug.Log("game started");
		}
		if (GUILayout.Button("Load Game")) {
			Debug.Log("game loaded");
		}
		if (GUILayout.Button("Options")) {
			Debug.Log("options");
		}
		if (GUILayout.Button("Quit")) {
			Application.Quit();
		}
		GUILayout.EndVertical();
		GUILayout.EndArea();
	}
}

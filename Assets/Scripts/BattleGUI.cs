using UnityEngine;
using System.Collections;

public class BattleGUI : MonoBehaviour
{
	private static int nativeWidth = 1280;
	private static int nativeHeight = 720;
	private static string[] keys = {"q", "w", "e", "r", "t", "y", "u", "i", "o", "p"};
	private Vector3 scaleVector;
	
	// rects
	private Rect barGroup;
	private Rect timeGroup;
	private Rect shortcutArea;
	private Rect skillArea;
	private Rect scoreGroup;
	
	// textures
	private Texture2D barBackground;
	private Texture2D bossBarForeground;
	private Texture2D healthBarForeground;
	private Texture2D manaBarForground;
	
	// references
	private Player player;
	private TimeCounter timeCounter;
	
	void Awake() {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		timeCounter = GameObject.Find("TimeCounter").GetComponent<TimeCounter>();
	}
	
	void Start()
	{
		// calculate the scale vector
		float widthRatio = ((float) Screen.width) / nativeWidth;
		float heightRatio = ((float) Screen.height) / nativeHeight;
		float scaleFactor = (widthRatio > heightRatio) ? heightRatio : widthRatio;
		scaleVector = new Vector3(scaleFactor, scaleFactor, 1.0f);
		
		// initialize rects
		barGroup = new Rect(10, 10, 1000, 80);
		timeGroup = new Rect(1180, 10, 90, 50);
		shortcutArea = new Rect(20, 620, 380, 80);
		skillArea = new Rect(534, 644, 212, 56);
		scoreGroup = new Rect(1060, 666, 200, 34);
		
		// initialize textures
		barBackground = makeTexture(980, 20, Color.black);
		bossBarForeground = makeTexture(980, 20, Color.red);
		healthBarForeground = makeTexture(600, 20, Color.red);
		manaBarForground = makeTexture(600, 20, Color.blue);
	}
	
	void OnGUI()
	{
		// backup the matrix
		Matrix4x4 backupMatrix = GUI.matrix;
		
		GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, scaleVector);
		
		// Draw the bars
		GUI.BeginGroup(barGroup, GUI.skin.box);
		drawBar(new Rect(0, 0, 980, 20), barBackground, bossBarForeground, player.currentHealthPercent());
		drawBar(new Rect(0, 25, 600, 20), barBackground, healthBarForeground, player.currentHealthPercent());
		drawBar(new Rect(0, 50, 600, 20), barBackground, manaBarForground, player.currentHealthPercent());
		GUI.EndGroup();
		
		// Draw the time
		GUI.BeginGroup(timeGroup, GUI.skin.box);
		drawTime(new Rect(0, 0, 90, 50), timeCounter.Time);
		GUI.EndGroup();
		
		// Draw the shortcut
		GUILayout.BeginArea(shortcutArea, GUI.skin.box);
		GUILayout.BeginVertical();
		
		GUILayout.BeginHorizontal();
		for (int i = 1; i < 11; ++i) {
			GUILayout.Box(i.ToString(), GUILayout.Width(32), GUILayout.Height(32));
		}
		GUILayout.FlexibleSpace();
		GUILayout.EndHorizontal();
		
		GUILayout.BeginHorizontal();
		GUILayout.FlexibleSpace();
		for (int i = 0; i < 10; ++i) {
			GUILayout.Box(keys[i], GUILayout.Width(32), GUILayout.Height(32));
		}
		GUILayout.EndHorizontal();
		
		GUILayout.EndVertical();
		GUILayout.EndArea();
		
		// Draw the skills
		GUILayout.BeginArea(skillArea, GUI.skin.box);
		GUILayout.BeginHorizontal();
		for (int i = 0; i < 4; ++i) {
			GUILayout.Box(i.ToString(), GUILayout.Width(48), GUILayout.Height(48));
		}
		GUILayout.EndHorizontal();
		GUILayout.EndArea();
		
		// Draw the score
		GUI.BeginGroup(scoreGroup, GUI.skin.box);
		drawScore(new Rect(0, 0, 200, 50), 88888888);
		GUI.EndGroup();
		
		// restore the matrix
		GUI.matrix = backupMatrix;
	}
	
	Texture2D makeTexture(int width, int height, Color color)
	{
		// create the pixels array
		Color[] pixels = new Color[width * height];
		
		// initialize the array with given color
		for (int i = 0; i < width * height; i++) {
			pixels[i] = color;
		}
		
		// create the result texture
		Texture2D resultTexture = new Texture2D(width, height);
		resultTexture.SetPixels(pixels);
		resultTexture.Apply();
		return resultTexture;
	}
	
	Rect clipBar(Rect rect, float percent) {
		int width = Mathf.RoundToInt(rect.width * percent);
		return new Rect(rect.x, rect.y, width, rect.height);
	}
	
	void drawBar(Rect rect, Texture2D background, Texture2D foreground, float percent) {
		GUI.DrawTexture(rect, background);
		GUI.DrawTexture(clipBar(rect, percent), foreground);
	}
	
	void drawTime(Rect rect, int time) {
		int minute = time / 60;
		int second = time % 60;
		string displayTime = (minute < 10) ? "0" : "";
		displayTime += minute.ToString() + ":";
		displayTime += (second < 10) ? "0" : "";
		displayTime += second.ToString();
		GUIStyle style = new GUIStyle(GUI.skin.label);
		style.fontSize = Mathf.RoundToInt(nativeHeight * 0.04f);
		style.alignment = TextAnchor.UpperRight;
		GUI.Label(rect, displayTime, style);
	}
	
	void drawScore(Rect rect, int score) {
		// the score is of magnitude 10^8
		int numOfDigits = countDigits(score);
		string displayScore = "";
		for (int i = 0; i < 8 - numOfDigits; i++)
			displayScore += "0";
		displayScore += score.ToString();
		GUIStyle style = new GUIStyle(GUI.skin.label);
		style.fontSize = Mathf.RoundToInt(nativeHeight * 0.04f);
		style.alignment = TextAnchor.UpperRight;
		GUI.Label(rect, displayScore, style);
	}
	
	int countDigits(int number) {
		int digits = 0;
		while (number > 0) {
			number /= 10;
			digits++;
		}
		return digits;
	}
}

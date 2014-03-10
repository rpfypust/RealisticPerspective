//using UnityEngine;
//using System.Collections;
//
//public class BattleGUI : MonoBehaviour
//{
//	private static string[] keys = {"q", "w", "e", "r", "t", "y", "u", "i", "o", "p"};
//	private Vector3 scaleVector;
//	
//	// rects
//	private Rect barGroup;
//	private Rect timeGroup;
//	private Rect shortcutArea;
//	private Rect skillArea;
//	private Rect scoreGroup;
//	
//	// textures
//	private Texture2D barBackground;
//	private Texture2D bossBarForeground;
//	private Texture2D healthBarForeground;
//	private Texture2D manaBarForground;
//	
//	// references
//	private Player player;
//	private TimeCounter timeCounter;
//	
//	void Awake() {
//		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
//		timeCounter = GameObject.Find("TimeCounter").GetComponent<TimeCounter>();
//	}
//	
//	void Start()
//	{
//		// calculate the scale vector
//		float widthRatio = Screen.width / 1920f;
//		float heightRatio = Screen.height / 1080f;
//		float scaleFactor = (widthRatio > heightRatio) ? heightRatio : widthRatio;
//		scaleVector = new Vector3(scaleFactor, scaleFactor, 1.0f);
//		
//		// initialize rects
//		barGroup = new Rect(30, 30, 1500, 120);
//		timeGroup = new Rect(1770, 30, 135, 75);
//		shortcutArea = new Rect(30, 930, 570, 120);
//		skillArea = new Rect(801, 966, 318, 84);
//		scoreGroup = new Rect(1590, 999, 300, 51);
//		
//		// initialize textures
//		barBackground = makeTexture(1470, 30, Color.black);
//		bossBarForeground = makeTexture(1470, 30, Color.red);
//		healthBarForeground = makeTexture(900, 30, Color.red);
//		manaBarForground = makeTexture(900, 30, Color.blue);
//	}
//	
//	void OnGUI()
//	{
//		// backup the matrix
//		Matrix4x4 backupMatrix = GUI.matrix;
//		
//		GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, scaleVector);
//		
//		// Draw the bars
//		GUI.BeginGroup(barGroup, GUI.skin.box);
//		drawBar(new Rect(0, 0, 1470, 30), barBackground, bossBarForeground, player.currentHealthPercent());
//		drawBar(new Rect(0, 40, 900, 30), barBackground, healthBarForeground, player.currentHealthPercent());
//		drawBar(new Rect(0, 80, 600, 30), barBackground, manaBarForground, player.currentHealthPercent());
//		GUI.EndGroup();
//		
//		// Draw the time
//		GUI.BeginGroup(timeGroup, GUI.skin.box);
//		drawTime(new Rect(0, 0, 135, 75), timeCounter.getCurrentTime);
//		GUI.EndGroup();
//		
//		// Draw the shortcut
//		GUILayout.BeginArea(shortcutArea, GUI.skin.box);
//		GUILayout.BeginVertical();
//		
//		GUILayout.BeginHorizontal();
//		for (int i = 1; i < 11; ++i) {
//			GUILayout.Box(i.ToString(), GUILayout.Width(48), GUILayout.Height(48));
//		}
//		GUILayout.FlexibleSpace();
//		GUILayout.EndHorizontal();
//		
//		GUILayout.BeginHorizontal();
//		GUILayout.FlexibleSpace();
//		for (int i = 0; i < 10; ++i) {
//			GUILayout.Box(keys[i], GUILayout.Width(48), GUILayout.Height(48));
//		}
//		GUILayout.EndHorizontal();
//		
//		GUILayout.EndVertical();
//		GUILayout.EndArea();
//		
//		// Draw the skills
//		GUILayout.BeginArea(skillArea, GUI.skin.box);
//		GUILayout.BeginHorizontal();
//		for (int i = 0; i < 4; ++i) {
//			GUILayout.Box(i.ToString(), GUILayout.Width(72), GUILayout.Height(72));
//		}
//		GUILayout.EndHorizontal();
//		GUILayout.EndArea();
//		
//		// Draw the score
//		GUI.BeginGroup(scoreGroup, GUI.skin.box);
//		drawScore(new Rect(0, 0, 300, 75), 88888888);
//		GUI.EndGroup();
//		
//		// restore the matrix
//		GUI.matrix = backupMatrix;
//	}
//	
//	Texture2D makeTexture(int width, int height, Color color)
//	{
//		// create the pixels array
//		Color[] pixels = new Color[width * height];
//		
//		// initialize the array with given color
//		for (int i = 0; i < width * height; i++) {
//			pixels[i] = color;
//		}
//		
//		// create the result texture
//		Texture2D resultTexture = new Texture2D(width, height);
//		resultTexture.SetPixels(pixels);
//		resultTexture.Apply();
//		return resultTexture;
//	}
//	
//	Rect clipBar(Rect rect, float percent) {
//		int width = Mathf.RoundToInt(rect.width * percent);
//		return new Rect(rect.x, rect.y, width, rect.height);
//	}
//	
//	void drawBar(Rect rect, Texture2D background, Texture2D foreground, float percent) {
//		GUI.DrawTexture(rect, background);
//		GUI.DrawTexture(clipBar(rect, percent), foreground);
//	}
//	
//	void drawTime(Rect rect, float time) {
//        int minute = Mathf.FloorToInt(time / 60);
//        float second = time - minute * 60;
//        string timeString = string.Format("{0}:{1}", minute.ToString("00"), second.ToString("00.000"));
//		GUIStyle style = new GUIStyle(GUI.skin.label);
//		style.fontSize = 43;
//		style.alignment = TextAnchor.UpperRight;
//		GUI.Label(rect, timeString, style);
//	}
//	
//	void drawScore(Rect rect, int score) {
//		// the score is of magnitude 10^8
//		int numOfDigits = countDigits(score);
//		string displayScore = "";
//		for (int i = 0; i < 8 - numOfDigits; i++)
//			displayScore += "0";
//		displayScore += score.ToString();
//		GUIStyle style = new GUIStyle(GUI.skin.label);
//		style.fontSize = 43;
//		style.alignment = TextAnchor.UpperRight;
//		GUI.Label(rect, displayScore, style);
//	}
//	
//	private int countDigits(int number) {
//		int digits = 0;
//		while (number > 0) {
//			number /= 10;
//			digits++;
//		}
//		return digits;
//	}
//}

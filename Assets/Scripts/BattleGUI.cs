using UnityEngine;
using System.Collections;

public class BattleGUI : MonoBehaviour
{
	private static int nativeWidth = 1280;
	private static int nativeHeight = 720;
	private Vector3 scaleVector;
	
	// rects
	private Rect bossHealthBarRect;
	private Rect healthBarRect;
	private Rect manaBarRect;
	private Rect timeRect;
	private Rect shortcutRect;
	private Rect skillRect;
	private Rect scoreRect;
	
	// textures
	private Texture2D emptyBar;
	private Texture2D fullBossHealthBar;
	private Texture2D fullHealthBar;
	private Texture2D fullManaBar;
	
	// parameters
	private int leftPadding = 10;
	private int topPadding = 10;
	private int spacing = 5;
	private int bossHealthBarLength = Mathf.RoundToInt(nativeWidth * 0.8f);
	private int barLength = Mathf.RoundToInt(nativeWidth * 0.6f);
	private int barHeight = 20;
	
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
		bossHealthBarRect = new Rect(leftPadding, topPadding, bossHealthBarLength, barHeight);
		healthBarRect = new Rect(leftPadding, topPadding + barHeight + spacing, barLength, barHeight);
		manaBarRect = new Rect(leftPadding, topPadding + 2 * (barHeight + spacing), barLength, barHeight);
		timeRect = new Rect(1180, topPadding, 50, 50);
		
		// initialize textures
		emptyBar = makeTexture(bossHealthBarLength, barHeight, Color.black);
		fullBossHealthBar = makeTexture(bossHealthBarLength, barHeight, Color.red);
		fullHealthBar = makeTexture(barLength, barHeight, Color.red);
		fullManaBar = makeTexture(barLength, barHeight, Color.blue);
	}
	
	void OnGUI()
	{
		// backup the matrix
		Matrix4x4 backupMatrix = GUI.matrix;
		
		GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, scaleVector);
		
		// Draw the bars
		drawBar(bossHealthBarRect, emptyBar, fullBossHealthBar, player.currentHealthPercent());
		drawBar(healthBarRect, emptyBar, fullHealthBar, player.currentHealthPercent());
		drawBar(manaBarRect, emptyBar, fullManaBar, player.currentHealthPercent());
		
		// Draw the time
		GUI.Box(timeRect, timeCounter.Time.ToString());
		
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
	
	void drawBar(Rect rect, Texture2D empty, Texture2D full, float percent) {
		GUI.DrawTexture(rect, empty);
		GUI.DrawTexture(clipBar(rect, percent), full);
	}
}

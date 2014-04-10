using UnityEngine;
using System.Collections;

public class Fader : MonoBehaviour, IDrawable {

	private Texture2D tex;
	private float screenWidth;
	private float screenHeight;

	void Awake()
	{
		tex = new Texture2D(1,1);
		tex.SetPixel(0, 0, Color.clear);
		tex.Apply();

		screenHeight = GUIManager.height;
		screenWidth = GUIManager.width;
	}

	public void DrawOnGUI()
	{
		GUI.DrawTexture(new Rect(0f, 0f, screenWidth, screenHeight), tex);
	}

	public IEnumerator Fade(float start, float end, float duration)
	{
		Color color = Color.black;

		color.a = Mathf.Clamp01(start);
		tex.SetPixel(0, 0 , color);
		tex.Apply();

		float step = (end - start) / duration * Time.fixedDeltaTime;
		float startTime = Time.time;
		while (Time.time - startTime <= duration) {
			color.a = color.a + step;
			tex.SetPixel(0, 0, color);
			tex.Apply();
			yield return new WaitForFixedUpdate();
		}

		color.a = Mathf.Clamp01(end);
		tex.SetPixel(0, 0 , color);
		tex.Apply();
	}

	
//	void Start() {
//		screenRect = new Rect(0, 0, Screen.width, Screen.height);
//	}
//	
//	void OnGUI() {
//		if (Application.isLoadingLevel) {
//			// Draw the texture if level is loading
//			GUI.DrawTexture(screenRect, texture);
//		} else if (fadingToBlack) {
//			alpha += Mathf.Clamp01(fadeSpeed * Time.deltaTime);
//			GUI.color = new Color(0, 0, 0, alpha);
//			
//			GUI.DrawTexture(screenRect, texture);
//			
//			if (GUI.color.a >= 0.95f) {
//				fadingToBlack = false;
//				Application.LoadLevel(levelIndex);
//			}
//		} else if (fadingToClear) {
//			alpha -= Mathf.Clamp01(fadeSpeed * Time.deltaTime);
//			GUI.color = new Color(0, 0, 0, alpha);
//			
//			GUI.DrawTexture(screenRect, texture);
//			
//			if (GUI.color.a <= 0.05f) {
//				fadingToClear = false;
//				this.enabled = false;
//			}
//		}
//	}
//	
//	void OnLevelWasLoaded(int level) {
//		fadingToClear = true;
//	}
//	
//	public void LoadLevel(int index) {
//		this.enabled = true;
//		levelIndex = index;
//		fadingToBlack = true;
//		fadingToClear = false;
//		alpha = 0.0f;
//	}
}

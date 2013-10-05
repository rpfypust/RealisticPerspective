using UnityEngine;
using System.Collections;

public class Fader : MonoBehaviour {

	public float fadeSpeed = 0.5f;
	public Texture2D texture;
	
	private Rect screenRect;
	private int levelIndex;
	private bool fadingToBlack;
	private bool fadingToClear;
	private float alpha;
	
	void Awake() {
		Object.DontDestroyOnLoad(transform.gameObject);
	}
	
	void Start() {
		screenRect = new Rect(0, 0, Screen.width, Screen.height);
	}
	
	void OnGUI() {
		if (Application.isLoadingLevel) {
			// Draw the texture if level is loading
			GUI.DrawTexture(screenRect, texture);
		} else if (fadingToBlack) {
			alpha += Mathf.Clamp01(fadeSpeed * Time.deltaTime);
			GUI.color = new Color(0, 0, 0, alpha);
			
			GUI.DrawTexture(screenRect, texture);
			
			if (GUI.color.a >= 0.95f) {
				fadingToBlack = false;
				Application.LoadLevel(levelIndex);
			}
		} else if (fadingToClear) {
			alpha -= Mathf.Clamp01(fadeSpeed * Time.deltaTime);
			GUI.color = new Color(0, 0, 0, alpha);
			
			GUI.DrawTexture(screenRect, texture);
			
			if (GUI.color.a <= 0.05f) {
				fadingToClear = false;
				this.enabled = false;
			}
		}
	}
	
	void OnLevelWasLoaded(int level) {
		fadingToClear = true;
	}
	
	public void LoadLevel(int index) {
		this.enabled = true;
		levelIndex = index;
		fadingToBlack = true;
		fadingToClear = false;
		alpha = 0.0f;
	}
}

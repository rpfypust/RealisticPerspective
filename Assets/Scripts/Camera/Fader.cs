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

	public IEnumerator SolidBlack(float duration)
	{
		tex.SetPixel(0, 0, Color.black);
		tex.Apply();
		yield return new WaitForSeconds(duration);
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
}

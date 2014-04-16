using UnityEngine;
using System.Collections;

public sealed class TimeCounter : MonoBehaviour, IDrawable {
	
	private float time;
	private bool running;

	private GUIManager gman;

	private void Awake()
	{
		gman = GameObject.FindGameObjectWithTag(Tags.gameController)
			.GetComponent<GUIManager>();
	}

    public void startTimer() {
		StartCoroutine(countUp());
		gman.register(this);
    }

	private IEnumerator countUp()
	{
		running = true;
		time = 0.0f;
		while (running) {
			time += Time.deltaTime;
			yield return new WaitForFixedUpdate();
		}
	}

    public float stopTimer() {
		running = false;
		gman.unregister(this);
		return time;
    }

	public void DrawOnGUI()
	{
		GUI.skin = null;

		GUIStyle style = new GUIStyle();
		style.fontSize = 28;
		style.normal.textColor = Color.black;
		style.alignment = TextAnchor.MiddleRight;

		int secs = (int) time;
		int mins = secs / 60;
		secs = secs % 60;
		int fraction = ((int) (time * 100f) % 100);
		string s = string.Format("{0:00}:{1:00}.{2:00}", mins, secs, fraction);
		GUI.Label(new Rect(1780, 40, 120, 20), s, style);
	}
}

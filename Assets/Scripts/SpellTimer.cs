using UnityEngine;
using System.Collections;

[RequireComponent(typeof(GUIManager))]
public class SpellTimer : MonoBehaviour, IDrawable {

	private GUIManager gman;

	private float countDown;

	void Awake()
	{
		gman = GetComponent<GUIManager>();
	}

	/* start count from t to 0
	 * and display on the GUI
	 */
	public void startTimer(float t)
	{
		StopAllCoroutines();
		countDown = t;
		gman.register(this);
		StartCoroutine("startTimerCoroutine");
	}

	public void resumeTimer()
	{
		StopAllCoroutines();
		StartCoroutine("startTimerCoroutine");
	}

	public void pauseTimer()
	{
		StopAllCoroutines();
	}

	/* stop counting down and
	 * the timer will be removed
	 * from the GUI
	 */
	public void stopTimer()
	{
		StopAllCoroutines();
		gman.unregister(this);
	}

	private IEnumerator startTimerCoroutine()
	{
		while (countDown > 0) {
			countDown = Mathf.Max(0f, countDown - Time.deltaTime);
			yield return new WaitForFixedUpdate();
		}
		gman.unregister(this);
	}

	public void DrawOnGUI()
	{
		GUI.skin = null;
		GUI.skin.box.fontSize = 40;
		GUI.skin.box.alignment = TextAnchor.MiddleCenter;
		GUI.Label(new Rect(1700, 20, 200, 100), new GUIContent(string.Format("{0:f0}", countDown)), GUI.skin.box);
	}
}

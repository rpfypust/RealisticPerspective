using UnityEngine;
using System.Collections;

public class CinematicCamera : MonoBehaviour {

	private GUIManager gman;
	private Fader fader;

	void Awake()
	{
		gman = GameObject.FindGameObjectWithTag(Tags.storyController).GetComponent<GUIManager>();
		fader = GetComponent<Fader>();
	}

	public IEnumerator orbitMotion(Transform center, float angle)
	{	
		transform.parent = center;

		Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.up);

		float duration = angle / 30.0f;

		float elapsedTime = 0;

		while (elapsedTime <= duration) {
			center.transform.rotation = Quaternion.RotateTowards(center.transform.rotation, rotation, elapsedTime/duration);
			elapsedTime += Time.fixedDeltaTime;
			yield return new WaitForFixedUpdate();
		}
	
		transform.parent = null;
	}

	public IEnumerator zoom(float percentage, float speed)
	{	
		Vector3 dest = transform.position + transform.forward.normalized * percentage;
		yield return StartCoroutine(transform.LinearMoveWithSpeed(transform.position, dest, speed));
	}

	public IEnumerator SolidBlack(float duration = 1f)
	{
		gman.register(fader);
		yield return StartCoroutine(fader.SolidBlack(duration));
		gman.unregister(fader);
	}
	
	public IEnumerator FadeIn(float duration = 1f)
	{
		gman.register(fader);
		yield return StartCoroutine(fader.Fade(0f, 1f, duration));
		gman.unregister(fader);
	}
	
	public IEnumerator FadeOut(float duration = 1f)
	{
		gman.register(fader);
		yield return StartCoroutine(fader.Fade(1f, 0f, duration));
		gman.unregister(fader);
	}
}

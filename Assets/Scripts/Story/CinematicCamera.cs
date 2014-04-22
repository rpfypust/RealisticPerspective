using UnityEngine;
using System.Collections;

public class CinematicCamera : MonoBehaviour {

	private GUIManager gman;
	private SEManager sem;
	private Fader fader;

	void Awake()
	{
		gman = GameObject.FindGameObjectWithTag(Tags.storyController).GetComponent<GUIManager>();
		sem = GameObject.FindGameObjectWithTag(Tags.storyController).GetComponentInChildren<SEManager>();
		fader = GetComponent<Fader>();
	}

	public IEnumerator orbitMotion(Transform center, float angle, float time)
	{	
		transform.parent = center;

		float step =  angle / time;
		float elapsedTime = 0;

		while (elapsedTime <= time) {
			center.transform.RotateAround(center.transform.position, Vector3.up, step*Time.fixedDeltaTime);
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

	public IEnumerator shake(float amplitude = 0.15f, float duration = 1f)
	{
		sem.PlaySoundEffect(3);
		float elapsedTime = 0;
		Vector3 originalPos = transform.position;
		while (elapsedTime <= duration) {
			transform.position = originalPos + Vector2Extensions.toVector3XZ(Random.insideUnitCircle * amplitude);
			elapsedTime += Time.fixedDeltaTime;
			yield return new WaitForFixedUpdate();
		}
		transform.position = originalPos;
	}

	public IEnumerator rotateY(float angle, float time)
	{	
		float step =  angle / time;
		float elapsedTime = 0;
		
		while (elapsedTime <= time) {
			transform.Rotate(0, step*Time.fixedDeltaTime, 0);
			elapsedTime += Time.fixedDeltaTime;
			yield return new WaitForFixedUpdate();
		}
	}

	public IEnumerator rotateX(float angle, float time)
	{	
		float step =  angle / time;
		float elapsedTime = 0;
		
		while (elapsedTime <= time) {
			transform.Rotate(step*Time.fixedDeltaTime, 0, 0);
			elapsedTime += Time.fixedDeltaTime;
			yield return new WaitForFixedUpdate();
		}

	}

	public IEnumerator pan(Vector3 movement, float time)
	{	

		Vector3 step = new Vector3(movement.x, movement.y, movement.z) / time;
		float elapsedTime = 0;
		
		while (elapsedTime <= time) {
			transform.position += step * Time.fixedDeltaTime;
			elapsedTime += Time.fixedDeltaTime;
			yield return new WaitForFixedUpdate();
		}
	}

	public IEnumerator shift(Vector3 position, Vector3 rotation)
	{	
		transform.position = position;
		transform.rotation = Quaternion.Euler(rotation);
		yield return null;
	}
}

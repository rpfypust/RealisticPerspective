using UnityEngine;
using System.Collections;

public static class TransformExtensions {
	public static IEnumerator LinearMove(this Transform t, Vector3 start, Vector3 end, float duration)
	{
		t.position = start;
		float distance = Vector3.Distance(start, end);
		float step = distance / duration * Time.fixedDeltaTime;
		float startTime = Time.time;
		while (Time.time - startTime <= duration) {
			t.position = Vector3.MoveTowards(t.position, end, step);
			yield return new WaitForFixedUpdate();
		}
	}
}

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public sealed class LinearMotion : Motion {

	public Vector3 destination;
	public float totalTime;

	public void setJourney(Vector3 d, float t)
	{
		destination = d;
		totalTime = t;
	}

	protected override IEnumerator moveCoroutine()
	{
		Vector3 des = destination;
		float startTime = Time.time;
		float total = totalTime;
		Vector3 velocity = (des - transform.position) / total;
		while (Time.time - startTime < total) {
			rigidbody.MovePosition(transform.TransformPoint(velocity * Time.deltaTime));
			yield return new WaitForFixedUpdate();
		}
	}
}

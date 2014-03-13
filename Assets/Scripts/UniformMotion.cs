using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public sealed class UniformMotion : Motion {

	private Vector3 velocity;

	void Awake()
	{
		rigidbody.useGravity = false;
		rigidbody.freezeRotation = false;
	}

	public void setVelocity(Vector3 v)
	{
		velocity = v;
	}

	protected override IEnumerator moveCoroutine() {
		Vector3 v = velocity;
		for(;;) {
			rigidbody.MovePosition(transform.position + (v * Time.deltaTime));
			yield return new WaitForFixedUpdate();
		}
	}
}

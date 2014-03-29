using UnityEngine;
using System.Collections;

public class UFO : Monster {
	//TODO: implement chase, attack
	protected override void Start() {
		base.Start();
		agent.updateRotation = false; // UFO handles its rotation seperately
	}

	public override void chase(Vector3 destination) {
		Vector2 direction = destination.toVector2XZ() - transform.position.toVector2XZ();
		if (direction.magnitude > attackRange) {
			Vector3 des = (direction.normalized * attackRange).toVector3XZ() + transform.position;
			agent.SetDestination(des);
		} else
			agent.SetDestination(transform.position);
	}
}

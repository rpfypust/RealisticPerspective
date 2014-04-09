using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class Slime : Monster {

	public float bulletSpeed = 2f;
	public float bulletLife = 5f;

	private HashIDs hash;
	private Animator animator;

	protected override void Awake() {
		base.Awake();
		animator = GetComponent<Animator>();
		hash = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<HashIDs>();
	}

	protected override void handleAnimation() {
		if (actionType == ActionType.chasing || actionType == ActionType.patrolling)
			animator.SetBool(hash.walkingBool, true);
		else
			animator.SetBool(hash.walkingBool, false);
	}

	public override void attack(Vector3 target) {
		Vector3 p = transform.position;
		p.y = 0.5f;
		Vector3 v = (target.toVector2XZ() - p.toVector2XZ())
			.toVector3XZ().normalized * bulletSpeed;
		UniformMotion um = BulletFactory.CreateUniformMotionBullet(p, v, bulletLife);
		um.startMoving();
	}
}

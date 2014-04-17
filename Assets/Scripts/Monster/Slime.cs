using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class Slime : Monster {

	public float bulletSpeed = 5f;
	public float bulletLife = 5f;

	private HashIDs hash;
	private Animator animator;

	protected override void Awake() {
		base.Awake();
		animator = GetComponent<Animator>();
		hash = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<HashIDs>();

		attackDuration = 0.5f;
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
		StartCoroutine(attackCoroutine(p, v));
	}

	private IEnumerator attackCoroutine(Vector3 p, Vector3 v)
	{
		for (int i = 0; i < 3; i++) {
			BulletFactory.CreateUniformMotionBullet(p, v, bulletLife).startMoving();
			yield return new WaitForSeconds(0.1f);
		}
	}
}

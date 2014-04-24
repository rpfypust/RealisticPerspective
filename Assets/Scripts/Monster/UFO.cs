using UnityEngine;
using System.Collections;

public class UFO : Monster {

	public int bulletsPerAttack;
	public float bulletSpeed;
	public float bulletLife;

	protected override void Start() {
		base.Start();
		agent.updateRotation = false; // UFO handles its rotation seperately
	}

	public override void attack(Vector3 target) {
		Vector2 p = transform.position.toVector2XZ();
		Vector2 dir = target.toVector2XZ() - p;
		StartCoroutine(attackCoroutine(dir.normalized));
	}

	private IEnumerator attackCoroutine(Vector2 initDir)
	{
		Vector3 p = transform.position;
		p.y = 1f + transform.position.y;

		int n = bulletsPerAttack;
		float waitInterval = attackDuration / n;
		float theta = 2 * Mathf.PI / n;
		Vector2 dir = initDir;
		for (int i = 0; i < n; i++) {
			Vector3 v = dir.toVector3XZ() * bulletSpeed;

			UniformMotion um = BulletFactory.CreateUniformMotionBullet(p, v, bulletLife);
			um.startMoving();

			dir = dir.rotateBy(theta);
			yield return new WaitForSeconds(waitInterval);
		}
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

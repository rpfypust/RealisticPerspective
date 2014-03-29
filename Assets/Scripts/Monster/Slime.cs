using UnityEngine;
using System.Collections;

public class Slime : Monster {

	public float bulletSpeed = 2f;
	public float bulletLife = 5f;

	public override void attack(Vector3 target) {
		Vector3 p = transform.position;
		Vector3 v = (target.toVector2XZ() - p.toVector2XZ())
			.toVector3XZ().normalized * bulletSpeed;
		UniformMotion um = BulletFactory.CreateUniformMotionBullet(p, v, bulletLife);
		um.startMoving();
	}
}

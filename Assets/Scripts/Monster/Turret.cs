using UnityEngine;
using System.Collections;

public sealed class Turret : Monster {

	[Range(0, 1)]
	public float weight = 0.5f;

	public float bulletSpeed = 6f;
	public float bulletLife = 5f;

	private Vector3 predictedVelocity;
	private Vector3 previousPosition;
	private float previousTime;

	void OnEnable()
	{
		MonsterAI.OnFirstAlerted += startPrediction;
		MonsterAI.OnAlerted += updatePrediction;
		MonsterAI.OnDisAlerted += resetPrediction;
	}

	void OnDisable()
	{
		MonsterAI.OnFirstAlerted -= startPrediction;
		MonsterAI.OnAlerted -= updatePrediction;
		MonsterAI.OnDisAlerted -= resetPrediction;
	}

	private void startPrediction(object sender, MonsterAI.AlertEventArgs e)
	{
		previousPosition = e.targetPosition;
		predictedVelocity = Vector3.zero;
		previousTime = Time.time;
	}

	private void resetPrediction(object sender, System.EventArgs e)
	{
		previousPosition = Vector3.zero;
		predictedVelocity = Vector3.zero;
	}

	private void updatePrediction(object sender, MonsterAI.AlertEventArgs e)
	{
		float currentTime = Time.time;
		float deltaTime = currentTime - previousTime;
		if (deltaTime == 0.0f)
			return;

		Vector3 displacement = e.targetPosition - previousPosition;

		predictedVelocity = predictedVelocity * weight + displacement / deltaTime * (1 - weight);

		previousPosition = e.targetPosition;
		previousTime = currentTime;
	}

	public override void born() {
		// turret are placed on stage, not spawned
	}

	public override void patrol(Vector3 destination) {
		// turret cannot move
	}

	public override void chase(Vector3 destination) {
		// turret cannot move
	}

	public override void attack(Vector3 target) {
		Vector3 position = transform.position;
		position.y = 1f;
		Vector3 velocity;

		/* We need to find the velocity(direction) which can
		 * possibly hit the moving target.
		 * Assume the target will keep linear motion with the
		 * current predicted velocity, then we have to find
		 * the intersection of the target and the bullet being
		 * shot.
		 * Clearly, a possible hit may happen after t seconds.
		 * the velocity of bullet is p / t + v, where
		 * p is the position of the target relative to the
		 * shooting point,
		 * v is the predicted velocity of the target.
		 * The motion of the bullet is described as a cone,
		 * since we do not know the direction of it.
		 * The cone is open along the time axis.
		 * The motion of the target is described as a ray.
		 * The problem become finding intersection of a cone
		 * and a ray.
		 * Equation of cone:
		 * x^2 + z^2 = (speed^2)(t^2)
		 * Equation of ray:
		 * (x, t, z) = (p.x + v.x * t, t, p.z + v.z * t)
		 * Substitution gives a quadratic equation to solve
		 */

		Vector2 p = target.toVector2XZ() - transform.position.toVector2XZ();
		Vector2 v = predictedVelocity.toVector2XZ();
		float a = Vector2.Dot(v, v) - bulletSpeed * bulletSpeed;
		float b = Vector2.Dot(p, v);
		float c = Vector2.Dot(p, p);
		float r1, r2;
		if (Util.solveQuadratic(a, b, c, out r1, out r2) >= 0f
		    && (r1 > 0f || r2 > 0f)) {
			float t;
			if (r1 > 0f && r2 > 0f)
				t = Mathf.Min(r1, r2);
			else
				t = Mathf.Max(r1, r2);
			Vector2 u = p / t + v;
			velocity = u.toVector3XZ().normalized * bulletSpeed;
		} else {
			velocity = p.toVector3XZ().normalized * bulletSpeed;
		}
		UniformMotion um = BulletFactory.CreateUniformMotionBullet(position, velocity, bulletLife);
		um.startMoving();
	}

	public override bool hasFinishedCurrentMove() {
		if (ActionType.attacking == actionType)
			return attackDurationTimer >= attackDuration;
		return true;
	}
}

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(MonsterAI))]
public sealed class Wizard : Monster {

	public float bulletSpeed = 8f;
	public float bulletLife = 5f;

	private Vector3 latestTargetPosition;

	private MonsterAI ai;
	private HashIDs hash;
	private Animator animator;

	protected override void Awake() {
		base.Awake();
		ai = GetComponent<MonsterAI>();
		animator = GetComponent<Animator>();
		hash = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<HashIDs>();
	}

	void OnEnable()
	{
		ai.OnAlerted += updateTargetPosition;
	}
	
	void OnDisable()
	{
		ai.OnAlerted -= updateTargetPosition;
	}

	private void updateTargetPosition(Vector3 p)
	{
		latestTargetPosition = p;
	}

	protected override void handleAnimation() {
		if (actionType == ActionType.patrolling)
			animator.SetBool(hash.patrollingBool, true);
		else
			animator.SetBool(hash.patrollingBool, false);
	}

	public override void attack(Vector3 target) {
		stopMoving();

		Vector3 p = transform.position;
		Vector3 v = (latestTargetPosition.toVector2XZ() - p.toVector2XZ())
			.toVector3XZ().normalized * bulletSpeed;
		UniformMotion um = BulletFactory.CreateUniformMotionBullet(p, v, bulletLife);
		um.startMoving();
		transform.position = ai.randomPositionInBounds();
		transform.rotation = Quaternion.LookRotation(latestTargetPosition.toVector2XZ().toVector3XZ());
	}
}

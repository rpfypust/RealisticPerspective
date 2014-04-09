using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(MonsterAI))]
public sealed class Wizard : Monster {

	public float bulletSpeed = 8f;
	public float bulletLife = 5f;

	public float teleportDuration = 0.2f;

	private Vector3 latestTargetPosition;

	private MonsterAI ai;
	private HashIDs hash;
	private Animator animator;

	private Transform meshTransform;

	protected override void Awake() {
		base.Awake();
		ai = GetComponent<MonsterAI>();
		animator = GetComponent<Animator>();
		hash = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<HashIDs>();

		meshTransform = transform.Find("Armature");
		attackDuration = 0.2f + teleportDuration * 2;
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

	private IEnumerator attackCoroutine()
	{
		Vector3 normalScale = Vector3.one;
		Vector3 finalScale = Vector3.forward * 2f;
		yield return StartCoroutine(meshTransform.ScaleWithTime(normalScale,
		                                                        finalScale,
		                                                        teleportDuration));

		transform.position = ai.randomPositionInBounds();
		transform.rotation = Quaternion.LookRotation(latestTargetPosition.toVector2XZ().toVector3XZ());
		yield return StartCoroutine(meshTransform.ScaleWithTime(finalScale,
		                                                        normalScale,
		                                                        teleportDuration));
	}

	public override void attack(Vector3 target) {
		stopMoving();

		Vector3 p = transform.position;
		p.y = 0.5f;
		Vector3 v = (latestTargetPosition.toVector2XZ() - p.toVector2XZ())
			.toVector3XZ().normalized * bulletSpeed;
		UniformMotion um = BulletFactory.CreateUniformMotionBullet(p, v, bulletLife);
		um.startMoving();

		StartCoroutine(attackCoroutine());
	}
}

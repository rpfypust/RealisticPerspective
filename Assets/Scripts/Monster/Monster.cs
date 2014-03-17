using UnityEngine;
using System.Collections;

[RequireComponent(typeof(NavMeshAgent))]
public class Monster : Character {

	protected enum ActionType {
		none,
		chasing,
		patrolling,
		attacking
	};

	public GameObject bornEffect;
	public GameObject dieEffect;
	public float attackRange = 3f;
	public float attackDuration = 0.5f;			// time needed to perform an attack
	public float patrolInterval = 2f;			// interval between two patrols
	public float attackInterval = 2f;			// interval between two attacks

	protected NavMeshAgent agent;
	private bool startedCurrentMove;

	protected ActionType actionType;
	protected float attackDurationTimer;
	protected float patrolIntervalTimer;
	protected float attackIntervalTimer;
	private Vector3 scheduledTargetPosition;

	protected virtual void Awake() {
		agent = GetComponent<NavMeshAgent>();
	}

	protected override void Start() {
		base.Start();
		startedCurrentMove = false;
		actionType = ActionType.none;
		attackDurationTimer = 0f;
		patrolIntervalTimer = patrolInterval;
		attackIntervalTimer = attackInterval;

		born();
	}

	protected virtual void Update() {
		if (!startedCurrentMove)
			tryStartCurrentMove();
		updateActionType();
		updateTimers();
	}

	private void tryStartCurrentMove() {
		switch (actionType) {
			case ActionType.patrolling:
				schedulePatrol(scheduledTargetPosition);
				break;
			case ActionType.attacking:
				scheduleAttack(scheduledTargetPosition);
				break;
		}
	}

	private void updateTimers() {
		if (ActionType.attacking != actionType)
			attackIntervalTimer += Time.deltaTime;
		if (ActionType.patrolling != actionType)
			patrolIntervalTimer += Time.deltaTime;
	}

	private void updateActionType() {
		if (hasFinishedCurrentMove()) {
			switch (actionType) {
			case ActionType.attacking:
				attackDurationTimer = 0f;
				break;
			}
			actionType = ActionType.none;
		} else {
			switch (actionType) {
			case ActionType.attacking:
				attackDurationTimer += Time.deltaTime;
				break;
			}
		}
	}

	public virtual bool hasFinishedCurrentMove() {
		switch (actionType) {
		case ActionType.patrolling:
			return agent.hasReachedDestination();
		case ActionType.chasing:
			return true;
		case ActionType.attacking:
			return attackDurationTimer >= attackDuration;
		}
		return true;
	}

	public virtual void born() {
		Instantiate(bornEffect, transform.position, bornEffect.transform.rotation);
	}

	public virtual void die() {

	}

	public bool canLaunchAttack(Vector3 destination) {
		float distance = (destination.toVector2XZ() - transform.position.toVector2XZ()).magnitude;
		return (distance <= attackRange && attackIntervalTimer >= attackInterval);
	}

	public void scheduleAttack(Vector3 destination) {
		if (canLaunchAttack(destination)) {
			actionType = ActionType.attacking;
			scheduledTargetPosition = destination;
			startedCurrentMove = true;
			attackIntervalTimer = 0.0f;
			attack(destination);
		} else
			scheduleChase(destination);
	}

	public void schedulePatrol(Vector3 destination) {
		actionType = ActionType.patrolling;
		scheduledTargetPosition = destination;

		if (patrolIntervalTimer >= patrolInterval) {
			startedCurrentMove = true;
			patrolIntervalTimer = 0.0f;
			patrol(destination);
		} else
			startedCurrentMove = false;
	}

	public virtual void patrol(Vector3 destination) {
		agent.SetDestination(destination);
	}

	public virtual void attack(Vector3 target) {

	}

	public void scheduleChase(Vector3 destination) {
		actionType = ActionType.chasing;
		scheduledTargetPosition = destination;
		startedCurrentMove = true;

		chase(destination);
	}

	public virtual void chase(Vector3 destination) {
		Vector2 direction = destination.toVector2XZ() - transform.position.toVector2XZ();
		if (direction.magnitude > attackRange) {
			Vector3 des = (direction.normalized * attackRange).toVector3XZ() + transform.position;
			agent.SetDestination(des);
		} else {
			agent.SetDestination(transform.position);
			Quaternion targetRotation = Quaternion.LookRotation(direction.toVector3XZ());
			Quaternion newRotation = Quaternion.Lerp(transform.rotation, 
			                                         targetRotation, 
			                                         agent.angularSpeed * Time.deltaTime);
			transform.rotation = newRotation;
		}
	}

	public override void takeDamage(float damage) {
		base.takeDamage(damage);
		Debug.Log(string.Format("Monster HP: {0}/{1}", HP, maxHP));
	}
}

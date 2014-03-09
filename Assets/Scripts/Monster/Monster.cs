using UnityEngine;
using System.Collections;

[RequireComponent(typeof(NavMeshAgent))]
public class Monster : MonoBehaviour {

	public GameObject bornEffect;
	public GameObject dieEffect;
	public float attackRange = 3f;
	public float attackDuration = 0.5f; // time needed to perform an attack

	public enum ActionType {
		none,
		chasing,
		patrolling,
		attacking
	};

	private NavMeshAgent agent;

	private bool finishedCurrentMove;
	public bool FinishedCurrentMove {
		get { return finishedCurrentMove; }
	}

	public ActionType actionType;
	private float attackTimer;


	void Awake() {
		agent = GetComponent<NavMeshAgent>();
	}

	void Start() {
		finishedCurrentMove = true;
		actionType = ActionType.none;
		attackTimer = 0f;
		born();
	}

	void Update() {
		updateActionType();
	}

	private void updateActionType() {
		switch (actionType) {
		case ActionType.patrolling:
			if (agent.hasReachedDestination()) {
				finishedCurrentMove = true;
				actionType = ActionType.none;
			}
			break;
		case ActionType.chasing:
			if (agent.hasReachedDestination()) { 
				finishedCurrentMove = true;
				actionType = ActionType.none;
			}
			break;
		case ActionType.attacking:
			if (attackTimer >= attackDuration) {
				attackTimer = 0f;
				finishedCurrentMove = true;
				actionType = ActionType.none;
			} else {
				attackTimer += Time.deltaTime;
			}
			break;
		default:
			break;
		}
	}

	public virtual void born() {
		Instantiate(bornEffect, transform.position, bornEffect.transform.rotation);
	}

	public virtual void die() {

	}

	public virtual void attack(Vector3 location) {
		actionType = ActionType.attacking;
		finishedCurrentMove = false;

		// implementation of attack
		// ...
	}

	public virtual void patrolTo(Vector3 destination) {
		actionType = ActionType.patrolling;
		finishedCurrentMove = false;
		agent.SetDestination(destination);
	}

	public virtual void chase(Vector3 targetPosition) {
		actionType = ActionType.chasing;
		finishedCurrentMove = true; // always true to make AI updates target's position
		Vector2 direction = targetPosition.toVector2XZ() - transform.position.toVector2XZ();
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
}

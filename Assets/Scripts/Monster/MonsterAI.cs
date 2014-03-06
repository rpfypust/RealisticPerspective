using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Monster))]
public class MonsterAI : MonoBehaviour {

	public enum ActionState {
		idling,
		pending
	};

	public float sightDepth = 5f;            // how far can this monster see normaly
	public float alertedDepth = 7f;          // how far can alerted monster see
	public float sightAngle = 120f;          // how wide can this monster see, in degrees
	public float patrollingInterval = 2f;    // interval between two patrols
	public float attackInterval = 2f;        // interval between two attacks
	public Rect movementBounds;              // area the monster resides

	private SphereCollider alertAreaCollider;
	private Monster monster;
	private GameObject player;
	private Layers layers;
	private LayerMask mask;

	private bool isAlerted;
	public float patrollingTimer;
	public float attackingTimer;
	private Vector3 destination;
	public ActionState state;

	void Awake() {
		alertAreaCollider = GetComponent<SphereCollider>();
		monster = GetComponent<Monster>();
		player = GameObject.FindGameObjectWithTag(Tags.player);
		layers = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<Layers>();
	}

	void Start() {
		state = ActionState.idling;
		isAlerted = false;
		patrollingTimer = 0f;
		attackingTimer = 0f;
		mask = 1 << layers.player;
	}

	void OnTriggerStay(Collider other) {
		if (!isAlerted) {
			isAlerted = isHeroInSight(other);
		}
		if (isAlerted) {
			destination = player.transform.position;
			alertAreaCollider.radius = alertedDepth;
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject == player) {
			isAlerted = false;
			alertAreaCollider.radius = sightDepth;
		}
	}

	void Update() {
		switch (state) {
		case ActionState.idling:
			takeAction();
			break;
		case ActionState.pending:
			if (monster.finishedCurrentMove) {
				state = ActionState.idling;
			}
			break;
		default:
			break;
		}
		if (Monster.ActionType.patrolling != monster.actionType) {
			patrollingTimer += Time.deltaTime;
		}
		if (Monster.ActionType.attacking != monster.actionType) {
			attackingTimer += Time.deltaTime;
		}
	}

	private bool isHeroInSight(Collider other) {
		if (other.gameObject == player) {
			Vector3 direction = other.transform.position - transform.position;
			float angle = Vector3.Angle(transform.forward, direction);
			if (angle < sightAngle * 0.5f) {
				if (Physics.Raycast(transform.position, direction, alertAreaCollider.radius, mask)) {
					return true;
				}
			}
		}
		return false;
	}

	private void takeAction() {
		if (isAlerted && attackingTimer >= attackInterval) {
			attackingTimer = 0;
			state = ActionState.pending;
			monster.attack(destination);
		} else if (isAlerted && attackingTimer < attackInterval) {
			state = ActionState.pending;
			monster.chase(destination);
		} else if (!isAlerted && patrollingTimer >= patrollingInterval) {
			patrollingTimer = 0;
			state = ActionState.pending;
			monster.patrolTo(destination = patrollingDestination());
		}
	}

	private Vector3 patrollingDestination() {
		return Util.randomInsideRect(movementBounds).toVector3XZ();
	}
}

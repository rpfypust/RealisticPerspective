using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Monster))]
public class MonsterAI : MonoBehaviour {

	enum ActionState {
		idling,
		patrolling,
		chasing,
		attacking
	};

	public float sightAngle = 120f;
	public float patrollingInterval = 2f;
	public Rect movementBounds;

	private SphereCollider alertAreaCollider;
	private Monster monster;
	private GameObject player;
	private Layers layers;
	private LayerMask mask;
	private bool isAlerted;
	private Vector3 playerLastSeenPosition;
	private Vector3 patrolDestination;
	private ActionState state;

	void Awake() {
		alertAreaCollider = GetComponent<SphereCollider>();
		monster = GetComponent<Monster>();
		player = GameObject.FindGameObjectWithTag(Tags.player);
		layers = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<Layers>();
	}

	void Start() {
		state = ActionState.idling;
		isAlerted = false;
		mask = 1 << layers.player;
//        agent.stoppingDistance = 2 * (capsuleCollider.radius + 
//                                      player.transform.parent.GetComponent<CharacterController>().radius);
		// precious stoppingDistance should be set in inspector
		// after experiments
	}

	void OnTriggerStay(Collider other) {
		isAlerted = (!isAlerted) ? isHeroInSight(other) : isAlerted;
		playerLastSeenPosition = (isAlerted) ? player.transform.position : playerLastSeenPosition;
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject == player) {
			isAlerted = false;
		}
	}

	void Update() {
		updateAIState();
		switch (state) {
		case ActionState.idling:
			if (!IsInvoking("startPatrolling"))
				Invoke("startPatrolling", 2f);
			break;
		case ActionState.chasing:
			if (IsInvoking("startPatrolling"))
				CancelInvoke("startPatrolling");
			monster.startMoving(playerLastSeenPosition);
			break;
		case ActionState.patrolling:
			monster.startMoving(patrolDestination);
			break;
		default:
			break;
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

	private void updateAIState() {
		if (isAlerted) {
			state = ActionState.chasing;
		} else if (ActionState.chasing == state) {
			state = ActionState.idling;
		} else if (ActionState.patrolling == state &&
			monster.hasFinishedMoving()) {
			state = ActionState.idling;
		}
	}

	private void startPatrolling() {
		Vector2 p = Util.randomInsideRect(movementBounds);
		patrolDestination = p.toVector3XZ();
		state = ActionState.patrolling;
		monster.startMoving(patrolDestination);
	}
}

﻿using UnityEngine;
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
	[HideInInspector]
	public Rect movementBounds;             // area the monster resides

	private SphereCollider alertArea;        /* the radius is overrided by sightDepth and
	                                          * alertedDepth */
	private Monster monster;
	private GameObject player;
	private Layers layers;

	private LayerMask mask;
	private bool isAlerted;
	private Vector3 destination;
	public ActionState state;

	void Awake() {
		alertArea = GetComponent<SphereCollider>();
		monster = GetComponent<Monster>();
		player = GameObject.FindGameObjectWithTag(Tags.player);
		layers = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<Layers>();
	}

	void Start() {
		state = ActionState.idling;
		isAlerted = false;
		alertArea.radius = sightDepth;
		mask = 1 << layers.player;
	}

	void OnTriggerStay(Collider other) {
		if (!isAlerted) {
			isAlerted = isHeroInSight(other);
		}
		if (isAlerted) {
			destination = player.transform.position;
			alertArea.radius = alertedDepth;
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject == player) {
			isAlerted = false;
			alertArea.radius = sightDepth;
		}
	}

	void Update() {
		switch (state) {
		case ActionState.idling:
			takeAction();
			state = ActionState.pending;
			break;
		case ActionState.pending:
			if (monster.hasFinishedCurrentMove())
				state = ActionState.idling;
			break;
		}
	}

	private bool isHeroInSight(Collider other) {
		if (other.gameObject == player) {
			Vector3 direction = other.transform.position - transform.position;
			float angle = Vector3.Angle(transform.forward, direction);
			if (angle < sightAngle * 0.5f)
				return Physics.Raycast(transform.position, direction, alertArea.radius, mask);
		}
		return false;
	}

	private void takeAction() {
		if (isAlerted && monster.canLaunchAttack(destination))
			monster.scheduleAttack(destination);
		else if (isAlerted)
			monster.scheduleChase(destination);
		else
			monster.schedulePatrol(destination = patrollingDestination());
	}

	private Vector3 patrollingDestination() {
		return Util.randomInsideRect(movementBounds).toVector3XZ();
	}
}

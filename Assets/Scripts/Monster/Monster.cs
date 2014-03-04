using UnityEngine;
using System.Collections;

[RequireComponent(typeof(NavMeshAgent))]
public class Monster : MonoBehaviour {
	public GameObject bornEffect;
	public GameObject dieEffect;

	private NavMeshAgent agent;

	void Start() {
		agent = GetComponent<NavMeshAgent>();
		Instantiate(bornEffect, transform.position, bornEffect.transform.rotation);
	}

	public virtual void die() {

	}

	public virtual void startMoving(Vector3 destination) {
		agent.SetDestination(destination);
	}

	public virtual void stopMoving() {
		agent.Stop();
	}

	public bool hasFinishedMoving() {
		return agent.hasReachedDestination();
	}
}

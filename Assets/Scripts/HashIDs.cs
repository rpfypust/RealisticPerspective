using UnityEngine;
using System.Collections;

public class HashIDs : MonoBehaviour {
	public int walkingBool;
	public int runningBool;
	public int patrollingBool;
	public int idlingBool;
	public int attackingBool;
	public int chasingBool;

	void Awake() {
		walkingBool = Animator.StringToHash("Walking");
		runningBool = Animator.StringToHash("Running");
		patrollingBool = Animator.StringToHash("Patrolling");
		idlingBool = Animator.StringToHash("Idling");
		attackingBool = Animator.StringToHash("Attacking");
		chasingBool = Animator.StringToHash("Chasing");
	}
}

using UnityEngine;
using System.Collections;

public class CsBossAnimation : MonoBehaviour {

	private Animator animator;
	private HashIDs hash;
	private Vector3 oriPos;
	private bool isWalking;
	private bool isRunning;

	void Awake() {
		animator = GetComponent<Animator>();
		hash = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<HashIDs>();
		oriPos = transform.position;
		isWalking = false;
		isRunning = false;
	}

	void FixedUpdate() {

		if ((oriPos.x == transform.position.x && oriPos.z == transform.position.z) && isWalking) {
			animator.SetBool(hash.walkingBool, false);
			isWalking = false;
		}
		else if ((oriPos.x != transform.position.x || oriPos.z != transform.position.z) && !isWalking) {
			animator.SetBool(hash.walkingBool, true);
			isWalking = true;
		}

		if (GetComponentInChildren<CS1_0>()) {
			if (GetComponentInChildren<CS1_0>().step >=23 && GetComponentInChildren<CS1_0>().step >=38) {
				animator.SetBool(hash.walkingBool, false);
				isWalking = false;
			}
			else {
				animator.SetBool(hash.walkingBool, true);
				isWalking = true;
			}
		}

		if (transform.position.y != 0.5f && !isRunning) {
			animator.SetBool(hash.runningBool, true);
			isRunning = true;
		}
		else if ((oriPos.x == transform.position.x && oriPos.z == transform.position.z) && isRunning) {
			animator.SetBool(hash.runningBool, false);
			isRunning = false;
		}

		oriPos = transform.position;
	}

}



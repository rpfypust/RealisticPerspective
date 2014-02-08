using UnityEngine;
using System.Collections;

public class HashIDs : MonoBehaviour {
	public int walkingBool;
	public int runningBool;

	void Awake() {
		walkingBool = Animator.StringToHash("Walking");
		runningBool = Animator.StringToHash("Running");
	}
}

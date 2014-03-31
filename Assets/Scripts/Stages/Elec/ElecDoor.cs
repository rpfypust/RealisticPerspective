using UnityEngine;
using System.Collections;

public class ElecDoor : MonoBehaviour {

	private BoxCollider col;

	void Awake()
	{
		col = GetComponent<BoxCollider>();
	}

	public void Toggle(bool open)
	{
		AnimationState state = animation["Open"];

		if (open) {
			state.normalizedTime = 0f;
			state.speed = 1f;
			col.enabled = false;
		} else {
			state.normalizedTime = 1f;
			state.speed = -1f;
			col.enabled = true;
		}

		animation.Play();
	}
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Plot : MonoBehaviour {

	public void startStoryScene() {
		StartCoroutine(sequencer());
	}

	protected abstract IEnumerator sequencer();

//	protected IEnumerator interactToProceed()
//	{
//		bool interacted = false;
//		while (!interacted) {
//			// definition what is an interaction
//			interacted = Input.GetButton("Fire1");
//			yield return new WaitForFixedUpdate();
//		}
	}

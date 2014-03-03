using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour {
	public GameObject bornEffect;
	public GameObject dieEffect;

	void Start() {
		Instantiate(bornEffect, transform.position, bornEffect.transform.rotation);
	}

	public virtual void die() {

	}
}

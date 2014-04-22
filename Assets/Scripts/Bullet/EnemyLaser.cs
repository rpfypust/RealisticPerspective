using UnityEngine;
using System.Collections;

public class EnemyLaser : Bullet {

	void OnTriggerEnter(Collider col)
	{
		Debug.Log("laser");
		if (col.gameObject.tag == Tags.player) {
			Character c = col.transform.root.gameObject.GetComponentInChildren<Character>();
			dealDamage(c);
		}
	}
}

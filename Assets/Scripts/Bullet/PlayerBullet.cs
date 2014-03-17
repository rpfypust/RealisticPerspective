using UnityEngine;
using System.Collections;

public class PlayerBullet : Bullet {

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == Tags.enemy) {
			Character c = col.transform.root.gameObject.GetComponentInChildren<Character>();
			dealDamage(c);
			Destroy(gameObject);
		}
	}
}

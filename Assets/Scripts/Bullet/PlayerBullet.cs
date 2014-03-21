using UnityEngine;
using System.Collections;

public class PlayerBullet : Bullet {

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == Tags.enemy) {
			Character c = col.transform.root.gameObject.GetComponentInChildren<Character>();
			dealDamage(c);
			Destroy(gameObject);
		}
	}
}

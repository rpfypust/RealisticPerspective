using UnityEngine;
using System.Collections;

public class EnemyBullet : Bullet {

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == Tags.player) {
			Character c = col.transform.root.gameObject.GetComponentInChildren<Character>();
			dealDamage(c);
			Destroy(gameObject);
		}
	}
}

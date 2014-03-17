using UnityEngine;
using System.Collections;

public class EnemyBullet : Bullet {

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == Tags.player) {
			Character c = col.transform.root.gameObject.GetComponentInChildren<Character>();
			dealDamage(c);
			Destroy(gameObject);
		}
	}

}

using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public float damage = 1.0f;

	public virtual void dealDamage(Character c) {
		c.takeDamage(damage);
	}
}

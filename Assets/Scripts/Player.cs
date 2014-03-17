using UnityEngine;
using System.Collections;

public class Player : Character {
	public override void takeDamage(float damage) {
		base.takeDamage(damage);
		Debug.Log(string.Format("Player HP: {0}/{1}", HP, maxHP));
	}
}

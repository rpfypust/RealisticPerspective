using UnityEngine;
using System.Collections;

public class Player : Character {

	public const float INVINCIBLE_INTERVAL = 1f;
	private bool invincible;
	private Renderer ren;

	protected override void Awake() {
		base.Awake();
		invincible = false;
		ren = GetComponentInChildren<Renderer>();
	}

	private IEnumerator blink()
	{
		invincible = true;
		float startTime = Time.time;
		while (Time.time - startTime <= INVINCIBLE_INTERVAL) {
			ren.enabled = !ren.enabled;
			yield return new WaitForSeconds(0.1f);
		}
		ren.enabled = true;
		invincible = false;
	}

	public override void takeDamage(float damage) {
		if (!invincible) {
			StartCoroutine(blink());
			base.takeDamage(damage);
			Debug.Log(string.Format("Player HP: {0}/{1}", HP, maxHP));
		}
	}
}

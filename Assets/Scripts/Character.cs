using UnityEngine;

/* base class for Monster, Player and Boss
 */
public class Character : MonoBehaviour {
	public float maxHP;

	private float hp;
	private float HP {
		get {
			return hp;
		}
		set {
			hp = Mathf.Min(maxHP, Mathf.Max(0, value));
		}
	}

	public virtual void Start() {
		hp = maxHP;
	}

	public virtual bool isAlive() {
		return hp > 0.0f;
	}

	public virtual void takeDamage(float damage) {
		HP -= damage;
	}

	public virtual void heal(float value) {
		HP += value;
	}
}

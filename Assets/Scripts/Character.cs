using UnityEngine;

/* base class for Monster, Player and Boss
 */
public class Character : MonoBehaviour {
	public float maxHP;

	protected float hp;
	protected float HP {
		get {
			return hp;
		}
		set {
			hp = Mathf.Clamp(value, 0.0f, maxHP);
		}
	}

	protected virtual void Awake() {
		
	}

	protected virtual void Start() {
		hp = maxHP;
	}

	public virtual bool isAlive() {
		return hp > 0.0f;
	}

	public virtual void takeDamage(float damage) {
		HP -= damage;
		if (!isAlive())
			die();
	}

	public virtual void die() {
		
	}

	public virtual void heal(float value) {
		HP += value;
	}
}

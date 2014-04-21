using UnityEngine;

/* base class for Monster, Player and Boss
 */
public class Character : MonoBehaviour {
	public float MaxHealthPoint;

	protected float hp;
	public float HealthPoint {
		get {
			return hp;
		}
		set {
			hp = Mathf.Clamp(value, 0.0f, MaxHealthPoint);
		}
	}

	public float HPPercent {
		get {
			return hp / MaxHealthPoint;
		}
	}

	protected virtual void Awake() {
		
	}

	protected virtual void Start() {
		hp = MaxHealthPoint;
	}

	public virtual bool isAlive() {
		return hp > 0.0f;
	}

	public virtual void takeDamage(float damage) {
		HealthPoint -= damage;
		if (!isAlive())
			die();
	}

	public virtual void die() {
		
	}

	public virtual void heal(float value) {
		HealthPoint += value;
	}
}

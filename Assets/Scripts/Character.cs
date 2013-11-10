using UnityEngine;

public class Character
{
	/* constructor */
	public Character()
	{
		
	}
	
	/* stats of character */
	private float max_hp = 100.0f;
	private float hp = 100.0f;
	private float max_mp = 100.0f;
	private float mp = 100.0f;
	private float atk = 1.0f; /* dummy value */
	private float resistance = 0.0f;
	
	/* consumables and equipment */
	private Consumable[] consumables = new Consumable[30];
	private Accessory[] accessories = new Accessory[12];
	
	/* accessors */
	public float MaxHP { 
		get { 
			return max_hp;
		}
		set {
			max_hp = value;
		}
	}

	public float HP {
		get {
			return hp;
		}
		set {
			hp = Mathf.Min(max_hp, Mathf.Max(0.0f, value));
		}
	}

	public float MaxMP {
		get {
			return max_mp;
		}
		set {
			max_mp = value;
		}
	}

	public float MP {
		get {
			return mp;
		}
		set {
			mp = Mathf.Min(max_mp, Mathf.Max(0.0f, value));
		}
	}

	public float ATK {
		get {
			return atk;
		}
		set {
			atk = value;
		}
	}

	public float Resistance {
		get {
			return resistance;
		}
		set {
			resistance = value;
		}
	}
	
	/* functions modifying stats */
	public void Apply(Consumable c)
	{
		c.Apply(this);
	}
}

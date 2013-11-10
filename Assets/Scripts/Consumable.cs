using UnityEngine;

public abstract class Consumable : Item
{
	/* default constructor */
	public Consumable()
		:base()
	{
		
	}
	
	/* constructor */
	public Consumable(int _id, string _name, string _description, int _price)
		:base(_id, _name, _description, _price)
	{
		
	}

	public abstract void Apply(Character c);
}

public class HealthPotion : Consumable
{
	/* default constructor */
	public HealthPotion(float _recoverPoint) 
	: base()
	{
		this.recoverPoint = _recoverPoint;
	}
	
	/* constructor */
	public HealthPotion(int _id, string _name, string _description, int _price, float _recoverPoint) 
	: base(_id, _name, _description, _price)
	{
		this.recoverPoint = _recoverPoint;
	}
	
	/* the amount of health this potion recovers */
	private float recoverPoint;
	
	public override void Apply(Character c)
	{
		c.HP = c.HP + recoverPoint;
	}
}

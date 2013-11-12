﻿using UnityEngine;

/* base class for consumable item */
public abstract class Consumable : Item
{
	/* constructor */
	protected Consumable(string _name, int _price)
		:base(_name, _price)
	{
		
	}

	public abstract void Apply(Character c);
}

/* class for health potion */
public class HealthPotion : Consumable
{
	/* item definition */
	/* create items here */
	public static HealthPotion Little = new HealthPotion("Little health potion", 10, 10.0f);
	
	/* constructor */
	protected HealthPotion(string _name, int _price, float _recoverPoint) 
	: base(_name, _price)
	{
		this.recoverPoint = _recoverPoint;
	}
	
	public override string Description {
		get {
			return Name + " recovers " + recoverPoint;
		}
	}
	
	/* the amount of health this potion recovers */
	private float recoverPoint;
	
	public override void Apply(Character c)
	{
		c.HP = c.HP + recoverPoint;
	}
}

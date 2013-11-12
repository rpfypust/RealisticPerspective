using UnityEngine;

public abstract class Accessory : Item {
	/* constructor */
	protected Accessory(string _name, int _price) 
	:base(_name, _price){
		
	}
	
	public abstract void Equip(Character c);
	public abstract void Unequip(Character c);
}

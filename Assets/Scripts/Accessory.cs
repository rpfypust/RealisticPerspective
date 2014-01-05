using UnityEngine;

public abstract class Accessory : Item {
	protected Accessory(string _name, int _price) 
	:base(_name, _price){
		
	}
	
	public abstract bool Equip(Character c);
	public abstract bool Unequip(Character c);
}

using UnityEngine;

public abstract class Accessory : Item {
	public abstract void Equip(Character c);
	public abstract void Unequip(Character c);
}

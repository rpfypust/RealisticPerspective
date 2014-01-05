using UnityEngine;

public abstract class Item
{

	protected Item(string _name, int _price)
	{
		this.name = _name;
		this.price = _price;
	}
	

	private string name;
	private int price;
	

	public string Name {
		get {
			return name;
		}
	}

	public int Price {
		get {
			return price;
		}
	}
	
	public abstract string Description {get;}
}

using UnityEngine;

public class Item
{
	/* default constructor */
	public Item()
	{
		this.id = -1;
		this.name = "NULL ITEM";
		this.description = "NULL DESCRIPTION";
		this.price = -1;
	}
	
	/* constructor */
	public Item(int _id, string _name, string _description, int _price)
	{
		this.id = _id;
		this.name = _name;
		this.description = _description;
		this.price = _price;
	}
	
	/* fields */
	private int id;
	private string name;
	private string description;
	private int price;
	
	/* accessors */
	public int ID {
		get {
			return id;
		}
	}

	public string Name {
		get {
			return name;
		}
	}
	
	public string Description {
		get {
			return description;
		}
	}

	public int Price {
		get {
			return price;
		}
	}
}

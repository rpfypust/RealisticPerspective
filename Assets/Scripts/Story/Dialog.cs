using UnityEngine;
using System.Collections;

public class Dialog {
	
	public Dialog(string s = "empty speaker", string c = "empty content") {
		Speaker = s;
		Content = c;
	}
	
	public string Speaker {get; private set;}
	public string Content {get; private set;}
}

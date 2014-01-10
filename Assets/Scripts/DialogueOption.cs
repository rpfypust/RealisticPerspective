using UnityEngine;
using System.Collections;

public class DialogueOption {

	public DialogueOption() {
		text = "null";
		flag = "null";
		value = -1;
	}

	public DialogueOption(string _text, string _flag, int _value) {
		text = _text;
		flag = _flag;
		value = _value;
	}

	public string Text {
		get {
			return text;
		}
	}

	public string Flag {
		get {
			return flag;
		}
	}

	public int Value {
		get {
			return value;
		}
	}

	private string text;
	private string flag;
	private int value;
	
}

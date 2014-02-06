using UnityEngine;
using System.Collections;

public class Dialog {

	public Dialog() {
		speaker = "null";
		text = "null";
	}

	public Dialog(string _speaker, string _text) {
		speaker = _speaker;
		text = _text;
	}

	public string Speaker {
		get {
			return speaker;
		}
	}

	public string Text {
		get {
			return text;
		}
	}

	private string speaker;
	private string text;
}

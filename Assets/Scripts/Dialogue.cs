using UnityEngine;
using System.Collections;

public class Dialogue {

	public Dialogue() {
		speaker = "null";
		text = "null";
		options = null;
	}

	public Dialogue(string _speaker, string _text) {
		speaker = _speaker;
		text = _text;
		options = null;
	}

	public Dialogue(string _speaker, string _text, DialogueOption[] _options) {
		speaker = _speaker;
		text= _text;
		options = _options;
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

	public DialogueOption[] Options {
		get {
			return options;
		}
	}

	private string speaker;
	private string text;
	private DialogueOption[] options;
}

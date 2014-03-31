/*
 * Emotion 0 = normal
 * Emotion 1 = think
 * Emotion 2 = question
 * Emotion 3 = surprise
 */
using UnityEngine;
using System.Collections;

public class Dialog {
	
	public Dialog(string s = "empty speaker", string c = "empty content", int e = 0) {
		Speaker = s;
		Content = c;
		Emotion = e;
	}
	
	public string Speaker {get; private set;}
	public string Content {get; private set;}
	public int Emotion {get; private set;}
}

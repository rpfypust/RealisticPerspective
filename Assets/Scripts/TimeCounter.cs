using UnityEngine;
using System.Collections;

public class TimeCounter : MonoBehaviour {
	
	private int time;
	
	void Start () {
		time = 0;
		InvokeRepeating("countUp", 0.0f, 1.0f);
	}
	
	void OnDestroy() {
		CancelInvoke("countUp");
	}
	
	void countUp() {
		time += 1;
	}
	
	public int Time {
		get {
			return time;
		}		
	}
}

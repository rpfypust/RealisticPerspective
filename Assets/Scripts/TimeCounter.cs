using UnityEngine;
using System.Collections;

public class TimeCounter : MonoBehaviour {
	
	private float time;
	
	void Start () {
		time = 0.0f;
	}

    void Update() {
        time += Time.deltaTime;
    }

    public void startTimer() {
        time = 0.0f;
        this.enabled = true;
    }

    public float stopTimer() {
        this.enabled = false;
        return time;
    }
	
	public float getCurrentTime {
		get {
			return time;
		}		
	}
}

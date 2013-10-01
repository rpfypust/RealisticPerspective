using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	// For testing Battle GUI
	void OnGUI() {
		if (GUI.Button(new Rect(100, 100, 50, 20), "+10")) {
			CurrentHealthPoint = CurrentHealthPoint + 10.0f;
		}
		if (GUI.Button(new Rect(180, 100, 50, 20), "-10")) {
			CurrentHealthPoint = CurrentHealthPoint - 10.0f;
		}
	}
	
	private float maxHealthPoint = 100.0f;
	private float currentHealthPoint = 100.0f;
		
	public float MaxHealthPoint {
		get {
			return maxHealthPoint;
		}
	}
		
	public float CurrentHealthPoint {
		get {
			return currentHealthPoint;
		}
		set {
			if (value > maxHealthPoint)
				currentHealthPoint = maxHealthPoint;
			else if (value > 0.0f)
				currentHealthPoint = value;
			else {
				currentHealthPoint = 0.0f;
			}
		}
	}
	
	public float currentHealthPercent() {
		return currentHealthPoint / maxHealthPoint;
	}
}

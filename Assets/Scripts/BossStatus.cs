using UnityEngine;
using System.Collections;

public class BossStatus : Status
{

	// Use this for initialization
	void Start ()
	{
	
	}

	public int BulletPatternState = 0;
	
	void OnGUI ()
	{
		
		Vector2 nameSize;
		string showString = Mathf.Round (HealthPoint).ToString () + "/" + Mathf.Round (MaxHealthPoint).ToString ();
		nameSize = GUI.skin.label.CalcSize (new GUIContent (showString));
		GUI.color = Color.blue;
		GUI.Label (new Rect (0, nameSize.y * 4, nameSize.x, nameSize.y), showString);
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}

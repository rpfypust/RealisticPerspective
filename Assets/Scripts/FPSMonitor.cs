using UnityEngine;
using System.Collections;

public class FPSMonitor : MonoBehaviour
{

	void OnGUI()
	{
		Vector2 nameSize;
	
		string showString = Mathf.Round(1.0f / Time.deltaTime).ToString() + "fps";
		nameSize = GUI.skin.label.CalcSize(new GUIContent(showString));
		GUI.color = Color.red;
		GUI.Label(new Rect(0.0f, 0.0f, nameSize.x, nameSize.y), showString);
	
		showString = Time.frameCount.ToString() + " frames passed";
		nameSize = GUI.skin.label.CalcSize(new GUIContent(showString));
		GUI.color = Color.red;
		GUI.Label(new Rect(0.0f, nameSize.y, nameSize.x, nameSize.y), showString);
	
		showString = Mathf.Round(1000.0f * Time.time).ToString() + " seconds passed";
		nameSize = GUI.skin.label.CalcSize(new GUIContent(showString));
		GUI.color = Color.red;
		GUI.Label(new Rect(0.0f, nameSize.y * 2.0f, nameSize.x, nameSize.y), showString);
	
		showString = Mathf.Round(Time.frameCount / Time.time).ToString() + "fps";
		nameSize = GUI.skin.label.CalcSize(new GUIContent(showString));
		GUI.color = Color.red;
		GUI.Label(new Rect(0.0f, nameSize.y * 3.0f, nameSize.x, nameSize.y), showString);
	}
}

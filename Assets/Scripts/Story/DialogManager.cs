using UnityEngine;
using System.Collections;

public class DialogManager : MonoBehaviour, IDrawable {
	
	private GUIManager gman;
	
	private float screenHeight;
	private float screenWidth;
	
	public int characterPerSecond = 30;
	private float waitInterval;
	
	private string speaker;
	private string content;
	
	void Awake(){
		gman = GetComponent<GUIManager>();
		
		screenHeight = GUIManager.height;
		screenWidth = GUIManager.width;
		
		waitInterval = 1.0f / characterPerSecond;
	}
	
	public void openDialog()
	{
		gman.register(this);
		speaker = "";
		content = "";
	}
	
	public void closeDialog()
	{
		gman.unregister(this);
	}
	
	public IEnumerator display(Dialog d)
	{
		speaker = d.Speaker;
		for (int i = 0; i <= d.Content.Length; i++) {
			content = d.Content.Substring(0, i);
			yield return new WaitForSeconds(waitInterval);
		}
	}
	
	public void DrawOnGUI()
	{
		GUIStyle style = new GUIStyle(GUI.skin.label);
		style.fontSize = 40;
		
		GUILayout.BeginArea(new Rect(0, 740, 200, 70), GUI.skin.box);
		GUILayout.Label(speaker, style);
		GUILayout.EndArea();
		
		style.fontSize = 50;
		GUILayout.BeginArea(new Rect(0, 810, screenWidth, screenHeight-810), GUI.skin.box);
		GUILayout.Label(content, style);
		GUILayout.EndArea();
	}
}

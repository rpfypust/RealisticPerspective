using UnityEngine;
using System.Collections;

public class ShoppingScreen : MonoBehaviour {

	private Vector3 scaleVector;
	
	// group
	private Rect moneyGroup;
	private Rect mainGroup;
	
	private Vector2 scrollPosition;
	
	void Start() {
		// calculate the scale vector
		float widthRatio = Screen.width / 1920f;
		float heightRatio = Screen.height / 1080f;
		float scaleFactor = (widthRatio > heightRatio) ? heightRatio : widthRatio;
		scaleVector = new Vector3(scaleFactor, scaleFactor, 1.0f);
		
		scrollPosition = Vector2.zero;
		
		moneyGroup = new Rect(200, 30, 350, 100);
		mainGroup = new Rect(600, 30, 1290, 1020);
	}
	
	void OnGUI() {
		// backup the matrix
		Matrix4x4 backupMatrix = GUI.matrix;
		
		GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, scaleVector);
		
		GUI.BeginGroup(moneyGroup, GUI.skin.box);
		// draw the money
		drawMoney(new Rect(0, 0, 350, 100), 88888888);
		GUI.EndGroup();
		
		GUI.BeginGroup(mainGroup, GUI.skin.box);
	
		// draw a table of items for sale
		GUILayout.BeginArea(new Rect(30, 30, 1230, 700), GUI.skin.box);
		
		// draw the title row
		drawTitleRow();
		
		// draw the list of items for sale
		scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Width(1230), GUILayout.Height(600));
		for (int i = 0; i < 100; ++i)
			drawItemRow(null, "Dummy item", 88888, 90, i % 5);
		GUILayout.EndScrollView();
		GUILayout.EndArea();
		
		// draw the description box
		GUILayout.BeginArea(new Rect(30, 760, 850, 230), GUI.skin.box);
		GUIStyle style = new GUIStyle(GUI.skin.box);
		style.fontSize = 40;
		style.alignment = TextAnchor.MiddleLeft;
		style.fontStyle = FontStyle.Italic;
		GUILayout.Label("Description", style);
		style.fontSize = 30;
		style.fontStyle = FontStyle.Normal;
		GUILayout.Label("This is a dummy item description", style);
		GUILayout.EndArea();
		
		// draw the arrows and text field for modifying quantity
		// draw the total
		// draw the buy button
		
		// restore the matrix
		GUI.EndGroup();
		GUI.matrix = backupMatrix;
	}
	
	void drawMoney(Rect rect, int money) {
		GUIStyle style = new GUIStyle(GUI.skin.label);
		style.fontSize = 70;
		style.alignment = TextAnchor.MiddleLeft;
		GUI.Label(rect, "$", style);
		style.alignment = TextAnchor.MiddleRight;
		GUI.Label(rect, money.ToString(), style);
	}
	
	void drawItemRow(Texture2D icon, string name, int price, int owned, int increment) {
		GUIStyle style = new GUIStyle(GUI.skin.box);
		style.fontSize = 50;
		style.alignment = TextAnchor.MiddleLeft;
		
		GUILayout.BeginHorizontal(GUILayout.Width(1230), GUILayout.Height(50));
		
		GUILayout.Label(icon, style, GUILayout.Width(100));
		GUILayout.Label(name, style, GUILayout.Width(700));
		GUILayout.Label("$" + price.ToString(), style, GUILayout.Width(200));
		GUILayout.Label(owned.ToString(), style, GUILayout.Width(70));
		if (increment > 0) {
			GUILayout.Label("+", style, GUILayout.Width(35));
			style.normal.textColor = Color.green;
			GUILayout.Label(increment.ToString(), style, GUILayout.Width(70));
		}
		
		GUILayout.EndHorizontal();
	}
	
	void drawTitleRow() {
		GUIStyle style = new GUIStyle(GUI.skin.box);
		style.fontSize = 50;
		style.alignment = TextAnchor.MiddleLeft;
		GUILayout.BeginHorizontal(GUILayout.Width(1230), GUILayout.Height(50));
		GUILayout.Label("", style, GUILayout.Width(100));
		GUILayout.Label("Items", style, GUILayout.Width(700));
		GUILayout.Label("Price", style, GUILayout.Width(200));
		GUILayout.Label("Owned", style, GUILayout.Width(200));
		GUILayout.EndHorizontal();
	}
}

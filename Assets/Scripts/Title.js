var texture : Texture;

var skin : GUISkin;


function OnGUI() {
	GUI.skin = skin;

	GUILayout.Box(texture);
	
	var areaWidth = Screen.width / 3;
	var areaHeight = Screen.height * 0.8;
	var areaX = Screen.width / 2 - areaWidth / 2;
	var areaY = Screen.height * 0.2;
	
	GUILayout.BeginArea(Rect(areaX, areaY, areaWidth, areaHeight));
	GUILayout.BeginVertical();
	
	if (GUILayout.Button("Start Game")) {
		print("game started");
	}
	if (GUILayout.Button("Load Game")) {
		print("game loaded");
	}
	if (GUILayout.Button("Option")) {
		print("go to options screen");
	}
	if (GUILayout.Button("Exit")) {
		// This call is ignored in editor
		// only functions in builds
		Application.Quit();
	}
	
	GUILayout.EndVertical();
	GUILayout.EndArea();
}
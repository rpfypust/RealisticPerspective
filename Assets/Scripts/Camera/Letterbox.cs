using UnityEngine;
using System.Collections;

public class Letterbox : MonoBehaviour, IDrawable {

    [Range(0, 1)]
    public float heightRatio = 0.8f;

    private Texture2D matte;
    private float matteHeight;
    private float screenHeight;
    private float screenWidth;
    
    void Awake() {
        matte = new Texture2D(1, 1);
        matte.SetPixel(0, 0, Color.black);
        matte.Apply();

        screenHeight = GUIManager.height;
        screenWidth = GUIManager.width;
        matteHeight = screenHeight * (1 - heightRatio) / 2;
	}
    
	public void DrawOnGUI() {
        GUI.DrawTexture(new Rect(0, 0, screenWidth, matteHeight), matte);
        GUI.DrawTexture(new Rect(0, screenHeight - matteHeight, screenWidth, matteHeight), matte);
	}
}

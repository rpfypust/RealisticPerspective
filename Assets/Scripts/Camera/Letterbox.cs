using UnityEngine;
using System.Collections;

public class Letterbox : MonoBehaviour {

    [Range(0, 1)]
    public float heightRatio = 0.8f;
    
    private Texture2D matte;

    private float matteHeight;
    private int screenHeight;
    private int screenWidth;
    
    void Start() {
        matte = new Texture2D(1, 1);
        matte.SetPixel(0, 0, Color.black);
        matte.Apply();

        screenHeight = Screen.height;
        screenWidth = Screen.width;
        matteHeight = screenHeight * (1 - heightRatio) / 2;
	}
    
	void OnGUI() {
        GUI.DrawTexture(new Rect(0, 0, screenWidth, matteHeight), matte);
        GUI.DrawTexture(new Rect(0, screenHeight - matteHeight, screenWidth, matteHeight), matte);
	}
}

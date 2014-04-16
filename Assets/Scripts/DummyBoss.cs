using UnityEngine;

public class DummyBoss : MonoBehaviour, IDrawable {
	// draw the health point of boss if boss is absent

	private GUIManager gman;
	private Texture2D tex;

	void Awake()
	{
		gman = GameObject.FindGameObjectWithTag(Tags.gameController)
			.GetComponent<GUIManager>();
		tex = Util.makeSolid(Color.black);
	}

	void OnEnable()
	{
		gman.register(this);
	}

	void OnDisable()
	{
		gman.unregister(this);
	}

	public void DrawOnGUI()
	{
		GUI.DrawTexture(new Rect(18f, 4f, 1898f, 18f), tex);
	}
}

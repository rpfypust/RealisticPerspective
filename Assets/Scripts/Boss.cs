using UnityEngine;
using System.Collections;

public class Boss : Character, IDrawable {
	public bool isInvicible = false;
	private Texture2D bossBack;
	private Texture2D bossFore;
	private GUIManager gman;

	protected override void Awake() {
		base.Awake();
		gman = GameObject.FindGameObjectWithTag(Tags.gameController)
			.GetComponent<GUIManager>();
		bossBack = Util.makeSolid(new Color32(0x46, 0x0a, 0x04, 0xff));
		bossFore = Util.makeSolid(new Color32(0xc8, 0x14, 0x14, 0xff));
	}
	
	protected override void Start() {
		base.Start();
		gman.register(this);
	}
	
	private void OnDestroy()
	{
		gman.unregister(this);
	}

	public void DrawOnGUI()
	{
		float length = HPPercent * 1898f;
		GUI.DrawTexture(new Rect(18f, 4f, 1898f, 18f), bossBack);
		GUI.DrawTexture(new Rect(18f, 4f, length, 18f), bossFore);
	}
}

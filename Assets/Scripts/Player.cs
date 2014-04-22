using UnityEngine;
using System.Collections;

public sealed class Player : Character, IDrawable {

	public const float INVINCIBLE_INTERVAL = 1.5f;
	private bool invincible;
	private Renderer ren;

	private Texture2D hpFore;
	private Texture2D hpBack;
	private Texture2D mpFore;
	private Texture2D mpBack;

	public float maxMagicPoint = 50.0f;
	private float magicPoint;
	public float MagicPoint {
		get {return magicPoint;}
		set {
			magicPoint = Mathf.Clamp(value, 0.0f, maxMagicPoint);
		}
	}

	private GUIManager gman;

	protected override void Awake() {
		base.Awake();
		invincible = false;
		ren = GetComponentInChildren<Renderer>();
		gman = GameObject.FindGameObjectWithTag(Tags.gameController)
			.GetComponent<GUIManager>();

		hpFore = Util.makeSolid(new Color32(0x14, 0xc8, 0x14, 0xff));
		hpBack = Util.makeSolid(new Color32(0x0a, 0x46, 0x0a, 0xff));
		mpFore = Util.makeSolid(new Color32(0x00, 0x00, 0x99, 0xff));
		mpBack = Util.makeSolid(new Color32(0x13, 0x22, 0x32, 0xff));

		MagicPoint = maxMagicPoint;
	}

	protected override void Start() {
		base.Start();
		gman.register(this);
	}

	private void OnDestroy()
	{
		gman.unregister(this);
	}

	private IEnumerator blink()
	{
		invincible = true;
		float startTime = Time.time;
		while (Time.time - startTime <= INVINCIBLE_INTERVAL) {
			ren.enabled = !ren.enabled;
			yield return new WaitForSeconds(0.1f);
		}
		ren.enabled = true;
		invincible = false;
	}

	public override void takeDamage(float damage) {
		if (!invincible) {
			StartCoroutine(blink());
			base.takeDamage(damage);
			Debug.Log(string.Format("Player HP: {0}/{1}", HealthPoint, MaxHealthPoint));
		}
	}

	public void DrawOnGUI()
	{
		float hpLength = HPPercent * 1227f;
		float mpLength = MagicPoint / maxMagicPoint * 1227f;
		GUI.DrawTexture(new Rect(18f, 40f, 1227f, 16f), hpBack);
		GUI.DrawTexture(new Rect(18f, 40f, hpLength, 16f), hpFore);
		GUI.DrawTexture(new Rect(18f, 64f, 1227f, 16f), mpBack);
		GUI.DrawTexture(new Rect(18f, 64f, mpLength, 16f), mpFore);
	}
}

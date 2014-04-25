using UnityEngine;
using System.Collections;

public class StageSelectionMenu : MonoBehaviour, IDrawable {

	private Flag flag;
	private GUIManager gman;
	private CutSceneManager csm;
	private GameController gamecon;
	private Layers layer;

	private Rect buttonRect;
	private int choice;

	void Awake()
	{
		gman = GameObject.FindGameObjectWithTag(Tags.gameController)
			.GetComponent<GUIManager>();
		csm = GameObject.FindGameObjectWithTag(Tags.mainCamera)
			.GetComponent<CutSceneManager>();
		layer = GameObject.FindGameObjectWithTag(Tags.gameController)
			.GetComponent<Layers>();
		gamecon = GameObject.FindGameObjectWithTag(Tags.gameController)
			.GetComponent<GameController>();
		flag = Flag.GetInstance();		

		buttonRect = new Rect(640, 216, 640, 648);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == layer.player
		    || other.gameObject.layer == layer.playerHitArea) {
			choice = 0;
			csm.BeginCutScene();
			gman.register(this);
		}
	}

	void Update()
	{
		if (choice != 0) {
			switch (choice) {
			case 1:
				gamecon.LoadLevel(SceneIndice.COMP);
				break;
			case 2:
				gamecon.LoadLevel(SceneIndice.MECH);
				break;
			case 3:
				gamecon.LoadLevel(SceneIndice.ELEC);
				break;
			case 5:
				gamecon.LoadLevel(SceneIndice.BOSS_ATRIUM);
				break;
			}
			choice = 0;
			gman.unregister(this);
			csm.EndCutScene();
		}
	}

	public void DrawOnGUI()
	{
		GUIStyle style = new GUIStyle(GUI.skin.button);
		style.fontSize = 150;
		style.font = GetComponent<TextMesh>().font;
		style.hover.textColor  = Color.gray;
		GUI.backgroundColor = Color.clear;
		
		GUILayout.BeginArea(buttonRect);
		GUILayout.BeginVertical();

		if (!flag.CompCleared
		    && GUILayout.Button("COMP", style, GUILayout.ExpandHeight(true))) {
			choice = 1;
		}

		if (!flag.MechCleared
		    && GUILayout.Button("MECH", style, GUILayout.ExpandHeight(true))) {
			choice = 2;
		}

		if (!flag.ElecCleared
		    && GUILayout.Button("ELEC", style, GUILayout.ExpandHeight(true))) {
			choice = 3;
		}

		if (flag.ClearedStageCount() >= 3
		    && GUILayout.Button("????", style, GUILayout.ExpandHeight(true))) {
			choice = 5;
		}

		if (GUILayout.Button("Cancel", style, GUILayout.ExpandHeight(true))) {
			choice = 4;
		}

		GUILayout.EndVertical();
		GUILayout.EndArea();
	}
}

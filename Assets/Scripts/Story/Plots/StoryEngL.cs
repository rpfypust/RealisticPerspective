using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StoryEngL : Plot
{
	
	public Transform[] wayPoints;
	private Actor alpha;
	private Actor renroh;
	
	private void Awake()
	{
		gamecon = GameObject.FindGameObjectWithTag(Tags.gameController)
			.GetComponent<GameController>();
		bgm = GameObject.FindGameObjectWithTag(Tags.gameController)
			.GetComponent<BGMManager>();
		dman = GetComponent<DialogManager>();
		cam = GameObject.FindGameObjectWithTag(Tags.mainCamera).GetComponent<CinematicCamera>();
		alpha = GameObject.Find("Alpha").GetComponent<Actor>();
		renroh = GameObject.Find("Renroh").GetComponent<Actor>();
		StartCoroutine(renroh.crouch());

		dialogs = new List<Dialog>();		

		dialogs.Add(new Dialog("Renroh", "...... You're really tough......"));
		dialogs.Add(new Dialog("Alpha", "It's enough! Stop please."));
		dialogs.Add(new Dialog("Renroh", "No! I'm not going to be \"denied\" again!", 3));
		dialogs.Add(new Dialog("Renroh", "I'll show you my true power! You'll regret soon!", 3));
	}
	
	public void Start()
	{
		base.startStoryScene();
	}
	
	protected override IEnumerator sequencer()
	{	
		for (int index = 0; index < dialogs.Count; index++) {

			if (index == 0) {
				yield return StartCoroutine(cam.SolidBlack(1f));
				StartCoroutine(cam.FadeOut());
				bgm.changeVolume(0.5f);
				bgm.PlayBGM(1);
				StartCoroutine(alpha.runWithTime(wayPoints [0], 1));
				yield return StartCoroutine(renroh.tunnelOut());
				dman.openDialog();
			}

			if (index == 1) {
				StartCoroutine(cam.pan(new Vector3(1.2f, .1f, 0.8f), .5f));
				StartCoroutine(cam.rotateY(-40, .5f));
			}

			if (index == 3) {
				StartCoroutine(renroh.Uncrouch());
				StartCoroutine(cam.pan(new Vector3(-1.1f, .2f, 0.75f), .5f));
				yield return StartCoroutine(cam.rotateY(-50, .5f));
			}

			switch (dialogs [index].Speaker) {
				case "Alpha":
					yield return StartCoroutine(dman.display(dialogs [index], alpha.EmotionPt));
					yield return StartCoroutine(dman.interactToProceed());
					break;
					
				case "Renroh":
					yield return StartCoroutine(dman.display(dialogs [index], renroh.EmotionPt));
					yield return StartCoroutine(dman.interactToProceed());
					break;
			}
		}

		dman.closeDialog();
		yield return new WaitForSeconds(1f);
		base.skip();
	}
}

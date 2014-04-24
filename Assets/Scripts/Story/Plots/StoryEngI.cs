using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StoryEngI : Plot
{
	
	public Transform[] wayPoints;
	private Actor alpha;
	private Actor delta;
	private Actor doctor;
	private Actor girl;
	
	private void Awake()
	{
		gamecon = GameObject.FindGameObjectWithTag(Tags.gameController)
			.GetComponent<GameController>();
		bgm = GameObject.FindGameObjectWithTag(Tags.gameController)
			.GetComponent<BGMManager>();
		dman = GetComponent<DialogManager>();
		cam = GameObject.FindGameObjectWithTag(Tags.mainCamera).GetComponent<CinematicCamera>();
		alpha = GameObject.Find("Alpha").GetComponent<Actor>();
		delta = GameObject.Find("Delta").GetComponent<Actor>();
		doctor = GameObject.Find("Doctor").GetComponent<Actor>();
		girl = GameObject.Find("Girl").GetComponent<Actor>();

		dialogs = new List<Dialog>();		
		dialogs.Add(new Dialog("Alpha", "This is...... memory of other again?", 2));
		//Memory Enter Effect
		dialogs.Add(new Dialog("Girl", "Doctor, how's the patient's condition?", 2));
		dialogs.Add(new Dialog("Doctor", "After all rescue measures, the patient's condition has been stabilized."));
		dialogs.Add(new Dialog("Doctor", "However, at the present stage the patient is still in coma."));
		dialogs.Add(new Dialog("Doctor", "Whether he can wake up or not depends on how strong his will is."));
		dialogs.Add(new Dialog("Girl", "What if he can't wake up......", 2));
		dialogs.Add(new Dialog("Doctor", "I'm afraid that he will remain in vegetative state......"));
		dialogs.Add(new Dialog("Girl", "...... ...... ......"));
		dialogs.Add(new Dialog("Alpha", "It's over......"));
		//walk in suddenly
		dialogs.Add(new Dialog("Alpha", "Wa! Stop scaring people, ok?", 3));
		dialogs.Add(new Dialog("Delta", "If you got time to peer stranger's memory, I suggest you better work on the next enemy's base."));
		dialogs.Add(new Dialog("Alpha", "Yes yes...... Here I go..."));
		//Tunnel Out
		dialogs.Add(new Dialog("Delta", "..... Time is running out..."));
		
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
				yield return StartCoroutine(alpha.walkWithTime(wayPoints [0], 2));
				StartCoroutine(alpha.rotate(-90, 0.5f));
				dman.openDialog();
				yield return StartCoroutine(dman.display(dialogs [0], alpha.EmotionPt));
				yield return StartCoroutine(dman.interactToProceed());
				dman.closeDialog();
				continue;
			}

			if (index == 1) {
				yield return StartCoroutine(cam.pan(new Vector3(0, 1, 2), 2));
				StartCoroutine(doctor.tunnelOut());
				yield return StartCoroutine(girl.tunnelOut());
				yield return StartCoroutine(cam.pan(new Vector3(0, -0.5f, 0), 1));
				dman.openDialog();
			}

			if (index == 8) {
				dman.closeDialog();
				StartCoroutine(doctor.vanish());
				StartCoroutine(girl.vanish());
				StartCoroutine(cam.pan(new Vector3(0, 0.5f, 0), 1));
				yield return StartCoroutine(cam.pan(new Vector3(0, -1, -2), 2));
				dman.openDialog();
			}

			if (index == 9) {
				yield return StartCoroutine(delta.tunnelOut());
				yield return StartCoroutine(delta.walkWithTime(wayPoints [1], 2));
				StartCoroutine(delta.faceTo(alpha.transform, 0.5f));
				yield return StartCoroutine(alpha.faceTo(delta.transform, 0.5f));
			}

			if (index == 12)
				yield return StartCoroutine(alpha.tunnelIn());

			switch (dialogs [index].Speaker) {
				case "Doctor":
					yield return StartCoroutine(dman.display(dialogs [index], doctor.EmotionPt));
					yield return StartCoroutine(dman.interactToProceed());
					break;
					
				case "Girl":
					yield return StartCoroutine(dman.display(dialogs [index], girl.EmotionPt));
					yield return StartCoroutine(dman.interactToProceed());
					break;
			}
		}

		dman.closeDialog();
		base.skip();
	}
}

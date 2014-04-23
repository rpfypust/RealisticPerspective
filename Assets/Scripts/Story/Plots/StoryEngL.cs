using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StoryEngL : Plot {
	
	public Transform[] wayPoints;
	private List<Dialog> dialogs;
	private DialogManager dman;
	private CinematicCamera cam;
	private BGMManager bgm;
	private Actor alpha;
	private Actor renroh;
	
	private void Awake () {
		// initialize reference to dman
		dman = GetComponent<DialogManager>();
		cam = GameObject.FindGameObjectWithTag(Tags.mainCamera).GetComponent<CinematicCamera>();
		bgm = GetComponentInChildren<BGMManager>();
		alpha = GameObject.Find("Alpha").GetComponent<Actor>();
		renroh = GameObject.Find("Renroh").GetComponent<Actor>();
		StartCoroutine(renroh.crouch());

		dialogs = new List<Dialog>();		

		dialogs.Add(new Dialog("Renroh", "... You're really tough..."));
		dialogs.Add(new Dialog("Alpha", "It's enough! Stop please."));
		dialogs.Add(new Dialog("Renroh", "No! I'm not going to be \"denied\" again!",3));
		dialogs.Add(new Dialog("Renroh", "I'll show you my true power! You'll regret soon!",3));
	}
	
	
	public void Start()
	{
		base.startStoryScene();
	}
	
	protected override IEnumerator sequencer()

	{	
		yield return StartCoroutine(cam.SolidBlack(1f));
		StartCoroutine(cam.FadeOut());
		bgm.changeVolume(0.3f);
		bgm.PlayBGM(4);
		StartCoroutine(alpha.runWithTime(wayPoints[0],1));
		yield return StartCoroutine(renroh.tunnelOut());

		dman.openDialog();
		yield return StartCoroutine(dman.display(dialogs[0],renroh.EmotionPt));
		yield return StartCoroutine(dman.interactToProceed());

		StartCoroutine(cam.pan(new Vector3(1.2f,.1f,0.8f),.5f));
		StartCoroutine(cam.rotateY(-40,.5f));

		yield return StartCoroutine(dman.display(dialogs[1],alpha.EmotionPt));
		yield return StartCoroutine(dman.interactToProceed());
		yield return StartCoroutine(dman.display(dialogs[2],renroh.EmotionPt));
		yield return StartCoroutine(dman.interactToProceed());
		StartCoroutine(renroh.Uncrouch());
		StartCoroutine(cam.pan(new Vector3(-1.1f,.2f,0.75f),.5f));
		yield return StartCoroutine(cam.rotateY(-50,.5f));
		yield return StartCoroutine(dman.display(dialogs[3],renroh.EmotionPt));
		yield return StartCoroutine(dman.interactToProceed());
		dman.closeDialog();
		yield return new WaitForSeconds(1f);
		yield return StartCoroutine(cam.FadeIn());
	}
}

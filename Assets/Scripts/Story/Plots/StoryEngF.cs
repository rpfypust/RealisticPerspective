using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StoryEngF : Plot {

	public Transform[] wayPoints;
	private List<Dialog> dialogs;
	private DialogManager dman;
	private CinematicCamera cam;
	private BGMManager bgm;
	private Actor alpha;
	private Actor alice;
	
	private void Awake () {
		// initialize reference to dman
		dman = GetComponent<DialogManager>();
		cam = GameObject.FindGameObjectWithTag(Tags.mainCamera).GetComponent<CinematicCamera>();
		bgm = GetComponentInChildren<BGMManager>();
		alpha = GameObject.Find("Alpha").GetComponent<Actor>();
		alice = GameObject.Find("Alice").GetComponent<Actor>();
		
		dialogs = new List<Dialog>();		

		//Tunnel effect
		dialogs.Add(new Dialog("Alpha", "It seems like Beta is not there..."));
		dialogs.Add(new Dialog("Alice", "Eh... Alpha, are you just pop out from nowhere?",2));
		dialogs.Add(new Dialog("Alpha", "Er!? You must be kidding, I've been here for a while...",3));
		dialogs.Add(new Dialog("Alice", "Really?",2));
		dialogs.Add(new Dialog("Alpha", "Sure..."));
		dialogs.Add(new Dialog("Alice", "Okay, maybe I saw it wrong."));
		dialogs.Add(new Dialog("Alice", "By the way, do you have any progress in searching Beta? I'm still worrying about her..."));
		dialogs.Add(new Dialog("Alpha", "I've already have a clue. Don't worry, I'll found her soon."));
		dialogs.Add(new Dialog("Alpha", "Alice, you should rather be careful then worrying others as the campus is not safe now."));
		dialogs.Add(new Dialog("Alpha", "If someone claims he is member of \"the Reality\", you should run away immediate."));
		dialogs.Add(new Dialog("Alice", "\"The Reality\"... Why do you know that? Does this have anything to do with Beta?",3));
		dialogs.Add(new Dialog("Alpha", "I can't say any more, I don't want to put you in danger. Just remember don't associates with \"the Reality\"."));
		dialogs.Add(new Dialog("Alpha", "I need to go now, I'll contact you if I found Beta."));
		//RunAway Camera
		dialogs.Add(new Dialog("Alice", "Alpha, wait..."));
		dialogs.Add(new Dialog("Alice", "\"the Reality\"..."));
		
	}

	public void Start()
	{
		base.startStoryScene();
	}
	
	protected override IEnumerator sequencer()
	{	
		yield return StartCoroutine(cam.SolidBlack(1f));
		StartCoroutine(cam.FadeOut());
		bgm.PlayBGM(0);
		yield return StartCoroutine(alpha.tunnelOut());
		dman.openDialog();
		yield return StartCoroutine(dman.display(dialogs[0],alpha.EmotionPt));
		yield return StartCoroutine(dman.interactToProceed());
		dman.closeDialog();


		StartCoroutine(cam.transform.LinearMoveWithTime(cam.transform.position, wayPoints[1].position, 2f));
		yield return StartCoroutine(alpha.walkWithTime(wayPoints[0],1f));

		yield return StartCoroutine(alice.walkWithTime(wayPoints[2],1f));
		yield return StartCoroutine(alice.faceTo(alpha.transform,0.2f));
		StartCoroutine(alpha.faceTo(alice.transform,0.5f));

		yield return StartCoroutine(cam.rotateY(-15, 1));
		yield return StartCoroutine(cam.zoom (0.5f, 1));

		dman.openDialog();
		for (int index = 1; index < 13; index++) {
			switch(dialogs[index].Speaker)
			{
			case "Alpha":
				yield return StartCoroutine(dman.display(dialogs[index],alpha.EmotionPt));
				yield return StartCoroutine(dman.interactToProceed());
				break;
				
			case "Alice":
				yield return StartCoroutine(dman.display(dialogs[index],alice.EmotionPt));
				yield return StartCoroutine(dman.interactToProceed());
				break;
			}
		}

		yield return new WaitForSeconds(0.5f);

		StartCoroutine(alice.faceTo(wayPoints[3],1f));
		StartCoroutine(cam.orbitMotion(wayPoints[4],150,1));
		StartCoroutine(alpha.walkWithTime(wayPoints[3],2));
		yield return new WaitForSeconds(0.5f);
		yield return StartCoroutine(dman.display(dialogs[13],alice.EmotionPt));
		yield return new WaitForSeconds(1.5f);
		Destroy(GameObject.Find("Alpha"));
		yield return StartCoroutine(dman.interactToProceed());
		yield return StartCoroutine(dman.display(dialogs[14],alice.EmotionPt));
		yield return new WaitForSeconds(1f);
		yield return StartCoroutine(dman.interactToProceed());
		dman.closeDialog();

		StartCoroutine(cam.FadeIn());
	}
}

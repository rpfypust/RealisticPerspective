using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StoryEngK : Plot {
	
	public Transform[] wayPoints;
	private List<Dialog> dialogs;
	private DialogManager dman;
	private CinematicCamera cam_0;
	private CinematicCamera cam_1;
	private Actor alpha;
	private Actor delta;
	private Actor renroh;
	private GameObject stage;
	private GameObject atrium;


	private void Awake () {
		// initialize reference to dman
		dman = GetComponent<DialogManager>();

		alpha = GameObject.Find("Alpha").GetComponent<Actor>();
		delta = GameObject.Find("Delta").GetComponent<Actor>();
		renroh = GameObject.Find("Renroh").GetComponent<Actor>();
		stage = GameObject.Find("Stage");
		atrium = GameObject.Find("Atrium");
		cam_0 = stage.GetComponentInChildren<CinematicCamera>();
		cam_1 = atrium.GetComponentInChildren<CinematicCamera>();
		atrium.SetActive(false);

		dialogs = new List<Dialog>();		

		dialogs.Add(new Dialog("Alpha", "It's wired. It's the last base but I still can't find Beta."));
		//Shake 
		dialogs.Add(new Dialog("Alpha", "What!?",3));
		dialogs.Add(new Dialog("Delta", "Alpha, bad news!",3));
		dialogs.Add(new Dialog("Alpha", " Delta, what happened?",2));
		dialogs.Add(new Dialog("Delta", "A large \"Tunnel\" appears at the atrium!",3));
		dialogs.Add(new Dialog("Delta", "It seems that the enemy headquarter is located at the atrium."));
		dialogs.Add(new Dialog("Alpha", "How's the situation at the atrium then?",2));
		dialogs.Add(new Dialog("Delta", "I don't have the details. But if we can't stop the \"Tunnel\", I'm afraid that..."));
		dialogs.Add(new Dialog("Alpha", "The consequence will be bad, right?"));
		dialogs.Add(new Dialog("Alpha", "Don't worry, I'll stop it."));
		dialogs.Add(new Dialog("Delta", "Alpha, be careful..."));
		dialogs.Add(new Dialog("Alpha", "Okay, just leave it to me. Everything will be all right."));
		dialogs.Add(new Dialog("Delta", "Alpha..."));
		//Fade IN&OUT changes sences
		dialogs.Add(new Dialog("Alpha", "It's not looking good here..."));
		dialogs.Add(new Dialog("Alpha", "!?",3));
		//Pan + Zoom
		dialogs.Add(new Dialog("Renroh", "Now you finally come."));
		dialogs.Add(new Dialog("Alpha", "You're...Dr. Renroh?",2));
		dialogs.Add(new Dialog("Renroh", "Correct, Alpha."));
		dialogs.Add(new Dialog("Alpha", "Why do you know my name?",2));
		dialogs.Add(new Dialog("Renroh", "Your sabotages to my bases have long been reported. How could I miss your name then?"));
		dialogs.Add(new Dialog("Alpha", "Then why didn't you stop me?",2));
		dialogs.Add(new Dialog("Renroh", "Not necessary. Those bases are just pawns scarified to save the queen."));
		dialogs.Add(new Dialog("Alpha", "What...",3));
		dialogs.Add(new Dialog("Renroh", "Everything is under control for this moment."));
		dialogs.Add(new Dialog("Alpha", "What are you going to do?",2));
		dialogs.Add(new Dialog("Renroh", "Revenge! A Revenge to everyone!",3));
		dialogs.Add(new Dialog("Alpha", "Revenge? Why?",2));
		dialogs.Add(new Dialog("Renroh", "Everyone sneer at my hypothesis without trying to understand it!"));
		dialogs.Add(new Dialog("Renroh", "So I need to prove it to everyone that my hypothesis is correct!"));
		dialogs.Add(new Dialog("Renroh", "\"The Worlds\" is real!",3));
		dialogs.Add(new Dialog("Alpha", "You've prove that already by now. Stop involving the innocent people to this!"));
		dialogs.Add(new Dialog("Renroh", "Naive, Naive, Naive!",3));
		dialogs.Add(new Dialog("Renroh", "People are ignorant. They will fear things out of their imagination, and then \"Deny\" them."));
		dialogs.Add(new Dialog("Renroh", "Since ancient times, many advocators of brand new hypothesis has been neglected and persecuted."));
		dialogs.Add(new Dialog("Renroh", "Roger Bacon, Giordano Bruno, Galileo Galilei..."));
		dialogs.Add(new Dialog("Renroh", "That's why I need to use the power of \"the Inner World\" to eradicate their stubborn perception."));
		dialogs.Add(new Dialog("Alpha", "Mind Control? It can't be possible.",1));
		dialogs.Add(new Dialog("Renroh", "It's possible. This is achievable if the \"Tunnel\" that bridge \"the Inner World\" and \"the Outer World\" is kept open."));
		dialogs.Add(new Dialog("Renroh", "Then people's perception will be gradually corrupted by \"the Inner World\"."));
		dialogs.Add(new Dialog("Alpha", "Infested by \"the Inner World\"...",1));
		dialogs.Add(new Dialog("Renroh", "When they're completely corrupted, those once \"Denied\" things will replace their perception."));
		dialogs.Add(new Dialog("Renroh", "By then, my hypothesis can finally be truly recognized."));
		dialogs.Add(new Dialog("Alpha", "I got it now..."));
		dialogs.Add(new Dialog("Alpha", "But, what you are doing is wrong."));
		dialogs.Add(new Dialog("Alpha", "This is no difference from mind control. Can you really accept using this to gain recognitions from others? "));
		dialogs.Add(new Dialog("Renroh", "People is really stubborn and ignorant, you are no exception..."));
		dialogs.Add(new Dialog("Renroh", "It seem that you can't be convinced without the use of the power of \"the Inner World\"!",3));
		dialogs.Add(new Dialog("Alpha", "You're the one that really stubborn!"));
		
	}

	
	public void Start()
	{
		base.startStoryScene();
	}
	
	protected override IEnumerator sequencer()
	{	
		yield return StartCoroutine(cam_0.SolidBlack(1f));
		StartCoroutine(cam_0.FadeOut());

		yield return StartCoroutine(alpha.walkWithTime(wayPoints[0],2));

		dman.openDialog();
		yield return StartCoroutine(dman.display(dialogs[0],alpha.EmotionPt));
		yield return StartCoroutine(base.interactToProceed());
		yield return StartCoroutine(cam_0.shake());
		yield return StartCoroutine(dman.display(dialogs[1],alpha.EmotionPt));
		yield return StartCoroutine(base.interactToProceed());
		yield return StartCoroutine(delta.tunnelOut());

		StartCoroutine(cam_0.orbitMotion(wayPoints[0], 90, 10));
		for (int index = 2; index < 12; index++) {
			switch(dialogs[index].Speaker)
			{
			case "Alpha":
				yield return StartCoroutine(dman.display(dialogs[index],alpha.EmotionPt));
				yield return StartCoroutine(base.interactToProceed());
				break;
				
			case "Delta":
				yield return StartCoroutine(dman.display(dialogs[index],delta.EmotionPt));
				yield return StartCoroutine(base.interactToProceed());
				break;
			}
		}

		yield return StartCoroutine(alpha.tunnelIn());
		yield return StartCoroutine(dman.display(dialogs[12],delta.EmotionPt));
		yield return StartCoroutine(base.interactToProceed());
		dman.closeDialog();

		yield return StartCoroutine(cam_0.FadeIn());
		yield return StartCoroutine(cam_0.SolidBlack(1f));

		//Sence Change

		Destroy(GameObject.Find ("Delta"));
		Destroy(stage);
		atrium.SetActive(true);
		alpha.transform.position = wayPoints[1].position;
		alpha.transform.rotation = wayPoints[1].rotation;

		//Sence Change

		yield return StartCoroutine(cam_1.SolidBlack(1f));
		StartCoroutine(cam_1.FadeOut());

		StartCoroutine(cam_1.pan(new Vector3(-35, -8.5f,0), 3f));
		yield return StartCoroutine(alpha.tunnelOut());
		yield return StartCoroutine(cam_1.orbitMotion(wayPoints[1].transform, 180 , 1f));

		dman.openDialog();
		yield return StartCoroutine(dman.display(dialogs[13],alpha.EmotionPt));
		yield return StartCoroutine(base.interactToProceed());
		yield return StartCoroutine(dman.display(dialogs[14],alpha.EmotionPt));
		yield return StartCoroutine(base.interactToProceed());
		dman.closeDialog();
		StartCoroutine(alpha.rotate(180,1f));
		yield return StartCoroutine(cam_1.orbitMotion(wayPoints[1].transform, 180 , 1f));

		StartCoroutine(cam_1.pan(new Vector3(-3,0.3f,0),0.5f));
		yield return StartCoroutine(renroh.tunnelOut());
		StartCoroutine(cam_1.pan(new Vector3(3,0,0),0.5f));
		StartCoroutine(alpha.runWithTime(wayPoints[2],1f));
		yield return StartCoroutine(cam_1.pan(new Vector3(-3,-0.3f,0), 1f));
		yield return StartCoroutine(cam_1.orbitMotion(wayPoints[3],90,0.5f));

		StartCoroutine(cam_1.orbitMotion(wayPoints[3], 180, 25f));
		dman.openDialog();
		for (int index = 15; index < 43; index++) {
			switch(dialogs[index].Speaker)
			{
			case "Alpha":
				yield return StartCoroutine(dman.display(dialogs[index],alpha.EmotionPt));
				yield return StartCoroutine(base.interactToProceed());
				break;
				
			case "Renroh":
				yield return StartCoroutine(dman.display(dialogs[index],renroh.EmotionPt));
				yield return StartCoroutine(base.interactToProceed());
				break;
			}
		}
		StartCoroutine(cam_1.orbitMotion(wayPoints[3], 45, .5f));
		yield return StartCoroutine(cam_1.pan(new Vector3(0,0.3f,0), 1f));

		for (int index = 43; index < 47; index++) {
			switch(dialogs[index].Speaker)
			{
			case "Alpha":
				yield return StartCoroutine(dman.display(dialogs[index],alpha.EmotionPt));
				yield return StartCoroutine(base.interactToProceed());
				break;
				
			case "Renroh":
				yield return StartCoroutine(dman.display(dialogs[index],renroh.EmotionPt));
				yield return StartCoroutine(base.interactToProceed());
				break;
			}
		}
		StartCoroutine(cam_1.orbitMotion(wayPoints[3], 90, .25f));
		yield return StartCoroutine(dman.display(dialogs[47],alpha.EmotionPt));
		yield return StartCoroutine(base.interactToProceed());

		dman.closeDialog();

		yield return StartCoroutine(renroh.tunnelIn());
		yield return new WaitForSeconds(1);

		yield return StartCoroutine(cam_1.FadeIn());
	}
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StoryEngH : Plot {
	
	public Transform[] targets;
	private List<Dialog> dialogs;
	private DialogManager dman;
	private CinematicCamera cam;
	
	private void Awake () {
		// initialize reference to dman
		dman = GetComponent<DialogManager>();
		cam = GameObject.FindGameObjectWithTag(Tags.mainCamera).GetComponent<CinematicCamera>();
		
		dialogs = new List<Dialog>();		

		dialogs.Add(new Dialog("Alpha", "Once again, not here...",1));
		dialogs.Add(new Dialog("Alpha", "And Delta has contacted me...",1));
		dialogs.Add(new Dialog("Alpha", "I better go for the next base as soon as possible to rescue Beta.",1));
		//Theta WalkIn
		dialogs.Add(new Dialog("Theta", "Alpha, you skip class again!",3));
		dialogs.Add(new Dialog("Theta", "You will be suffering in “the Reeducation camp” soon or later."));
		dialogs.Add(new Dialog("Alpha", "No, I’m just free only..."));
		dialogs.Add(new Dialog("Theta", "Then what are you sneaking around here for?",2));
		dialogs.Add(new Dialog("Alpha", "I’m investigating..."));
		dialogs.Add(new Dialog("Theta", "Okay, what are you investigating?",2));
		dialogs.Add(new Dialog("Alpha", "Beta, of course. What else can it be?"));
		dialogs.Add(new Dialog("Theta", "Oh, sorry..."));
		dialogs.Add(new Dialog("Theta", "I’m too busy latterly that I almost forget this."));
		dialogs.Add(new Dialog("Theta", "Have you found her then?",2));
		dialogs.Add(new Dialog("Alpha", "Not yet, but almost."));
		dialogs.Add(new Dialog("Theta", "Alpha, you’re really working hard for Beta."));
		dialogs.Add(new Dialog("Alpha", "Of course. She’s my best friends after all."));
		dialogs.Add(new Dialog("Theta", "Ah..."));
		dialogs.Add(new Dialog("Theta", "Is there anything I can help?",2));
		dialogs.Add(new Dialog("Alpha", "Sure."));
		dialogs.Add(new Dialog("Alpha", "Then do you know Dr. Zeta?",2));
		dialogs.Add(new Dialog("Theta", "Dr. Zeta..."));
		dialogs.Add(new Dialog("Alpha", "No? Let it be then."));
		dialogs.Add(new Dialog("Theta", "Ya... Sorry..."));
		//alarm sounds
		dialogs.Add(new Dialog("Alpha", "Hey, your alarm is ringing. Do you need to go to lecture now?",2));
		dialogs.Add(new Dialog("Theta", "Oh no!",3));
		dialogs.Add(new Dialog("Theta", "I’ve to go now! See you."));
		//Theta Walk away
		dialogs.Add(new Dialog("Alpha", "OK, I need to work on the next base too."));

	}
	
	public void Start()
	{
		base.startStoryScene();
	}
	
	protected override IEnumerator sequencer()
	{	
		yield return StartCoroutine(cam.orbitMotion(targets[0], 0, 30));
	}
}

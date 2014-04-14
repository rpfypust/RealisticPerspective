using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StoryEngF : Plot {

	public Transform[] targets;
	private List<Dialog> dialogs;
	private DialogManager dman;
	private CinematicCamera cam;
	
	private void Awake () {
		// initialize reference to dman
		dman = GetComponent<DialogManager>();
		cam = GameObject.FindGameObjectWithTag(Tags.mainCamera).GetComponent<CinematicCamera>();
		
		dialogs = new List<Dialog>();		

		//Tunnel effect
		dialogs.Add(new Dialog("Alpha", "It seems like Beta is not here..."));
		dialogs.Add(new Dialog("Theta", "Eh... Alpha, are you just pop out from nowhere?",2));
		dialogs.Add(new Dialog("Alpha", "Er!? You must be kidding, I've been here for a while...",3));
		dialogs.Add(new Dialog("Theta", "Really?",2));
		dialogs.Add(new Dialog("Alpha", "Sure..."));
		dialogs.Add(new Dialog("Theta", "Okay, maybe I saw it wrong."));
		dialogs.Add(new Dialog("Theta", "By the way, do you have any progress in searching Beta? I'm still worrying about her..."));
		dialogs.Add(new Dialog("Alpha", "I've already have a clue. Don't worry, I'll found her soon."));
		dialogs.Add(new Dialog("Alpha", "Theta, you should rather be careful then worrying others as the campus is not safe now."));
		dialogs.Add(new Dialog("Alpha", "If someone claims he is member of \"the Reality\", you should run away immediate."));
		dialogs.Add(new Dialog("Theta", "\"The Reality\"…… Why do you know that? Does this have anything to do with Beta?",3));
		dialogs.Add(new Dialog("Alpha", "I can't say any more, I don't want to put you in danger. Just remember don't associates with \"the Reality\"."));
		dialogs.Add(new Dialog("Alpha", "I need to go now, I'll contact you if I found Beta."));
		//RunAway Camera
		dialogs.Add(new Dialog("Theta", "Alpha, wait..."));
		dialogs.Add(new Dialog("Theta", "\"the Reality\"..."));
		
	}

	public void Start()
	{
		base.startStoryScene();
	}
	
	protected override IEnumerator sequencer()
	{	
		yield return null;
	}
}

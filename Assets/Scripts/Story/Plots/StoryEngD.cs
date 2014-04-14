using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StoryEngD : Plot {
	
	public Transform[] targets;
	private List<Dialog> dialogs;
	private DialogManager dman;
	private CinematicCamera cam;
	
	private void Awake () {
		// initialize reference to dman
		dman = GetComponent<DialogManager>();
		cam = GameObject.FindGameObjectWithTag(Tags.mainCamera).GetComponent<CinematicCamera>();
		
		dialogs = new List<Dialog>();		

		//Effect tgt, sound
		dialogs.Add(new Dialog("Alpha", "Awww..."));
		dialogs.Add(new Dialog("Alpha", "What happened?",3));
		//Effect tgt, sound
		dialogs.Add(new Dialog("Shadow", "Don't panic, this is \"the Inner World\"."));
		dialogs.Add(new Dialog("Alpha", "What's going on now? How come I am here?",2));
		dialogs.Add(new Dialog("Shadow", "Wait, don't you just say that you understand the situation after my explanation."));
		dialogs.Add(new Dialog("Alpha", "No way I can understand that. Isn't that just cosplay's dialogue?",2));
		dialogs.Add(new Dialog("Shadow", "Okay. We have just passed through a \"Tunnel\". And we need to defeat \"the Denied\" then we can rescue Beta."));
		dialogs.Add(new Dialog("Alpha", "Seem like we got company, lets talk later."));
		//monster show up camera motion
		dialogs.Add(new Dialog("Alpha", "\"The Denied\", our enemy. You should defeat them quickly or else you will get killed."));
		dialogs.Add(new Dialog("Alpha", "Enemy!",3));
		dialogs.Add(new Dialog("Shadow", "Don't stand still. Move!",3));
		dialogs.Add(new Dialog("Alpha", "Yes!",3));
		dialogs.Add(new Dialog("System", "Press UP, Down, Left, Right, Jump and Walk to dodge."));
		//Battle mode without attack, 5s then paused
		//battle camera mode
		//HUD turn on
		dialogs.Add(new Dialog("Shadow", "You can't beat them if you just keep dodge. Attack!"));
		dialogs.Add(new Dialog("Alpha", "Even you say so, I don't know how to attack anyway and I got no weapons too!"));
		dialogs.Add(new Dialog("Shadow", "No, you has the ability to defeat \"the Denied\"."));
		dialogs.Add(new Dialog("Shadow", "You only need to visualize and conjure the attack, probably."));
		dialogs.Add(new Dialog("Alpha", "Probably? Please be serious!,3"));
		dialogs.Add(new Dialog("Shadow", "Just try hard to visualize the attack and conjure it!"));
		dialogs.Add(new Dialog("Alpha", "Visualize... Visualize... Attack... Attack...",1));
		dialogs.Add(new Dialog("System", "Press Attack to shot."));
		//Battle mode without attack, 5s then paused
		//battle camera mode
		//HUD turn on
		dialogs.Add(new Dialog("Alpha", "Like that?"));
		dialogs.Add(new Dialog("Shadow", "Yeah, that's right. Keep going and defeat all of them!",3));
		dialogs.Add(new Dialog("Alpha", "Don't just watch, can you help?"));
		dialogs.Add(new Dialog("Shadow", "Sorry, I don't have the ability to defeat \"the Denied\". We can only count on you."));
		dialogs.Add(new Dialog("Shadow", "Well, they are just minions. You can defeat them with ease, you can do it!"));
		dialogs.Add(new Dialog("Alpha", "I don't think it's that easy for me……Sign."));
		//Battle mode without attack, 5s then paused
		//battle camera mode
		//HUD turn on
		dialogs.Add(new Dialog("System", "Please defeat all enemies."));
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

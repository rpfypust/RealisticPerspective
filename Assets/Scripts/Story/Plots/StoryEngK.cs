using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StoryEngK : Plot {
	
	public Transform[] targets;
	private List<Dialog> dialogs;
	private DialogManager dman;
	private CinematicCamera cam;
	
	private void Awake () {
		// initialize reference to dman
		dman = GetComponent<DialogManager>();
		cam = GameObject.FindGameObjectWithTag(Tags.mainCamera).GetComponent<CinematicCamera>();
		
		dialogs = new List<Dialog>();		

		dialogs.Add(new Dialog("Alpha", "It’s wired. It’s the last base but I still can’t find Beta."));
		//Shake 
		dialogs.Add(new Dialog("Alpha", "What!?",3));
		dialogs.Add(new Dialog("Delta", "Alpha, bad news!",3));
		dialogs.Add(new Dialog("Alpha", " Delta, what happened?",2));
		dialogs.Add(new Dialog("Delta", "A large “Tunnel” appears at the atrium!",3));
		dialogs.Add(new Dialog("Delta", "It seems that the enemy headquarter is located at the atrium."));
		dialogs.Add(new Dialog("Alpha", "How’s the situation at the atrium then?",2));
		dialogs.Add(new Dialog("Delta", "I don’t have the details. But if we can’t stop the “Tunnel”, I’m afraid that..."));
		dialogs.Add(new Dialog("Alpha", "The consequence will be bad, right?"));
		dialogs.Add(new Dialog("Alpha", "Don’t worry, I’ll stop it."));
		dialogs.Add(new Dialog("Delta", "Alpha, be careful..."));
		dialogs.Add(new Dialog("Alpha", "Okay, just leave it to me. Everything will be all right."));
		dialogs.Add(new Dialog("Delta", "Alpha..."));
		//Fade IN&OUT changes sences
		dialogs.Add(new Dialog("Alpha", "It’s not looking good here..."));
		dialogs.Add(new Dialog("Alpha", "!?",3));
		//Pan + Zoom
		dialogs.Add(new Dialog("Zeta", "Now you finally come."));
		dialogs.Add(new Dialog("Alpha", "You’re...Dr. Zeta?",2));
		dialogs.Add(new Dialog("Zeta", "Correct, Alpha."));
		dialogs.Add(new Dialog("Alpha", "Why do you know my name?",2));
		dialogs.Add(new Dialog("Zeta", "Your sabotages to my bases have long been reported. How could I miss your name then?"));
		dialogs.Add(new Dialog("Alpha", "Then why didn’t you stop me?",2));
		dialogs.Add(new Dialog("Zeta", "Not necessary. Those bases are just pawns scarified to save the queen."));
		dialogs.Add(new Dialog("Alpha", "What...",3));
		dialogs.Add(new Dialog("Zeta", "Everything is under control for this moment."));
		dialogs.Add(new Dialog("Alpha", "What are you going to do?",2));
		dialogs.Add(new Dialog("Zeta", "Revenge! A Revenge to everyone!",3));
		dialogs.Add(new Dialog("Alpha", "Revenge? Why?",2));
		dialogs.Add(new Dialog("Zeta", "Everyone sneer at my hypothesis without trying to understand it!"));
		dialogs.Add(new Dialog("Zeta", "So I need to prove it to everyone that my hypothesis is correct!"));
		dialogs.Add(new Dialog("Zeta", "“The Worlds” is real!",3));
		dialogs.Add(new Dialog("Alpha", "You’ve prove that already by now. Stop involving the innocent people to this!"));
		dialogs.Add(new Dialog("Zeta", "Naive, Naive, Naive!",3));
		dialogs.Add(new Dialog("Zeta", "People are ignorant. They will fear things out of their imagination, and then “Deny” them."));
		dialogs.Add(new Dialog("Zeta", "Since ancient times, many advocators of brand new hypothesis has been neglected and persecuted."));
		dialogs.Add(new Dialog("Zeta", "Roger Bacon, Giordano Bruno, Galileo Galilei..."));
		dialogs.Add(new Dialog("Zeta", "That’s why I need to use the power of “the Inner World” to eradicate their stubborn perception."));
		dialogs.Add(new Dialog("Alpha", "Mind Control? It can’t be possible.",1));
		dialogs.Add(new Dialog("Zeta", "It’s possible. This is achievable if the “Tunnel” that bridge “the Inner World” and “the Outer World” is kept open."));
		dialogs.Add(new Dialog("Zeta", "Then people’s perception will be gradually corrupted by “the Inner World”."));
		dialogs.Add(new Dialog("Alpha", "Infested by “the Inner World”...",1));
		dialogs.Add(new Dialog("Zeta", "When they’re completely corrupted, those once “Denied” things will replace their perception."));
		dialogs.Add(new Dialog("Zeta", "By then, my hypothesis can finally be truly recognized."));
		dialogs.Add(new Dialog("Alpha", "I got it now..."));
		dialogs.Add(new Dialog("Alpha", "But, what you are doing is wrong."));
		dialogs.Add(new Dialog("Alpha", "This is no difference from mind control. Can you really accept using this to gain recognitions from others? "));
		dialogs.Add(new Dialog("Zeta", "People is really stubborn and ignorant, you are no exception..."));
		dialogs.Add(new Dialog("Zeta", "It seem that you can’t be convinced without the use of the power of “the Inner World”!",3));
		dialogs.Add(new Dialog("Alpha", "You’re the one that really stubborn!"));
		
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

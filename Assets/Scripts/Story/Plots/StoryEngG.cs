using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StoryEngG : Plot {
	
	public Transform[] targets;
	private List<Dialog> dialogs;
	private DialogManager dman;
	private CinematicCamera cam;
	
	private void Awake () {
		// initialize reference to dman
		dman = GetComponent<DialogManager>();
		cam = GameObject.FindGameObjectWithTag(Tags.mainCamera).GetComponent<CinematicCamera>();
		
		dialogs = new List<Dialog>();		

		dialogs.Add(new Dialog("Alpha", "What’s now? What do those black dolls doing?",3));
		//Delta walkiin
		dialogs.Add(new Dialog("Delta", "They are performing someone’s “denied” memory."));
		dialogs.Add(new Dialog("Alpha", "Delta!",3));
		dialogs.Add(new Dialog("Alpha", "Why are you here?",2));
		dialogs.Add(new Dialog("Delta", "I’m just investigating nearby and I saw something strange here so I come to take a look."));
		dialogs.Add(new Dialog("Delta", "Silence now, just watch."));
		dialogs.Add(new Dialog("Delta", "This memory maybe has something to do with “the Reality”."));
		dialogs.Add(new Dialog("Alpha", "OK."));
		//Panning,Zoom
		dialogs.Add(new Dialog("Zeta", "... base on the above hypothesis... "));
		dialogs.Add(new Dialog("Zeta", "... the world maybe is not just one..."));
		dialogs.Add(new Dialog("Scientist A", "Stop joking, Dr. Zeta."));
		dialogs.Add(new Dialog("Scientist A", "The world is not just only one, are you serious?"));
		dialogs.Add(new Dialog("Zeta", "This’s not joking, I do meant it."));
		dialogs.Add(new Dialog("Zeta", "Let me explain one more time..."));
		dialogs.Add(new Dialog("Scientist B", "Dr. Zeta, it’s almost time to stop day dreaming."));
		dialogs.Add(new Dialog("Scientist C", "The once genius has become such a..."));
		dialogs.Add(new Dialog("Scientist A", "No, he is still a genius now..."));
		dialogs.Add(new Dialog("Scientist A", "A genius of science fiction."));
		dialogs.Add(new Dialog("Scientist B", "Haaaaaa!"));
		//3S walkaway
		dialogs.Add(new Dialog("Zeta", "Wait... Give me one more chance please..."));
		dialogs.Add(new Dialog("Zeta", "Fail again... Once again I can’t fulfill my promise..."));
		//Memory Sence FadOut Effect
		dialogs.Add(new Dialog("Alpha", "Is it finished?",2));
		dialogs.Add(new Dialog("Delta", "Yes. And we’re lucky that its memory of insider and we got a name."));
		dialogs.Add(new Dialog("Delta", "Dr. Zeta, the proposer of “the Worlds”. I must investigate on him."));
		dialogs.Add(new Dialog("Alpha", "Okay."));
		dialogs.Add(new Dialog("Alpha", "By the way, why are you black like those dolls?",2));
		dialogs.Add(new Dialog("Delta", "Actually, everything in “the Inner World” has color in the beginning, but the longer the object stays at here, its color will fade away gradually."));
		dialogs.Add(new Dialog("Delta", "At the end, those things will become totally black..."));
		dialogs.Add(new Dialog("Delta", "Then they just disappear like those black dolls..."));
		dialogs.Add(new Dialog("Delta", "totally vanished from “the Worlds”"));
		dialogs.Add(new Dialog("Alpha", "Er... you are so black..."));
		dialogs.Add(new Dialog("Delta", "No, It's not what you think."));
		dialogs.Add(new Dialog("Delta", "It’s just my disguise so that I can do my investigation easily in “the Inner World”."));
		dialogs.Add(new Dialog("Alpha", "I see, that’s great then."));
		dialogs.Add(new Dialog("Alpha", "I just worrying you will disappear any time soon as you are that black."));
		dialogs.Add(new Dialog("Delta", "If you got time to worry others, I suggest you better work on the next enemy’s base."));
		dialogs.Add(new Dialog("Delta", "Anyway, I’ll contact you again after my investigation. See you."));
		//Delta Walkaway
		dialogs.Add(new Dialog("Alpha", "She really likes to give order..."));
		
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

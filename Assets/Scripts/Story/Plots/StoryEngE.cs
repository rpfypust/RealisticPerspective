﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StoryEndE : Plot {
	
	public Transform[] targets;
	private List<Dialog> dialogs;
	private DialogManager dman;
	private CinematicCamera cam;
	
	private void Awake () {
		// initialize reference to dman
		dman = GetComponent<DialogManager>();
		cam = GameObject.FindGameObjectWithTag(Tags.mainCamera).GetComponent<CinematicCamera>();
		
		dialogs = new List<Dialog>();		
		
		dialogs.Add(new Dialog("Shadow", "Well done."));
		dialogs.Add(new Dialog("Alpha", "It seems that you're having a good time while I'm fighting with my life..."));
		dialogs.Add(new Dialog("Shadow", "Well, I'm also working."));
		dialogs.Add(new Dialog("Shadow", "While you're dealing with \"the Denied\", I've searched this area carefully."));
		dialogs.Add(new Dialog("Alpha", "Have you find Beta?",2));
		dialogs.Add(new Dialog("Shadow", "Unfortunately, no."));
		dialogs.Add(new Dialog("Alpha", "Still..."));
		dialogs.Add(new Dialog("Shadow", "But, information about the possible location of Beta is found."));
		dialogs.Add(new Dialog("Alpha", "Really!?",3));
		dialogs.Add(new Dialog("Shadow", "Yes, the information states that \"the Reality\" has 6 basses that bridge \"the Worlds\"."));
		dialogs.Add(new Dialog("Shadow", "The 6 bases are the labs of COMP, ELEC, MECH, CIVIL, CENG and IELM, six labs of the engineering department."));
		dialogs.Add(new Dialog("Shadow", "Beta is most likely trapped in one of those."));
		dialogs.Add(new Dialog("Alpha", "Wait, what do you mean by \"the Reality\"? And how come Beta is related to this?",2));
		dialogs.Add(new Dialog("Shadow", "\"The Reality\" is a secret association lurking in the campus recently. All anomalies have something to do with them."));
		dialogs.Add(new Dialog("Shadow", "With carrot and stick, they approach UST students with ability to open \"Tunnel\". And use them to open \"Tunnels\" all over the campus."));
		dialogs.Add(new Dialog("Alpha", "So, Beta was targeted as she has the ability."));
		dialogs.Add(new Dialog("Alpha", "Then why does she has the ability?",2));
		dialogs.Add(new Dialog("Shadow", "In fact, everyone has the ability to open a \"Tunnel\"."));
		dialogs.Add(new Dialog("Shadow", "In order to open a \"Tunnel\", an intense denials towards something in \"the Outer World\" is needed."));
		dialogs.Add(new Dialog("Alpha", "Then what is being denied by Beta?",2));
		dialogs.Add(new Dialog("Shadow", "I've no ideas... Maybe you can ask her when you find her."));
		dialogs.Add(new Dialog("Shadow", "What important now is that we've to stop \"the Reality\"."));
		dialogs.Add(new Dialog("Shadow", "If we connive them now, there will be more victims like Beta."));
		dialogs.Add(new Dialog("Alpha", "I understand now. It seems like Beta is really got into a big trouble this time."));
		dialogs.Add(new Dialog("Alpha", "We must disorganize \"the Reality\" to make sure Beta is out of danger."));
		dialogs.Add(new Dialog("Shadow", "Yes, then I'll investigate \"the Reality\" and the bases are left to you. Are you okay with that, Ahpla?"));
		dialogs.Add(new Dialog("Alpha", "What should I do with those bases actually?",2));
		dialogs.Add(new Dialog("Shadow", "You just need to defeat all \"the Denied\" at those bases."));
		dialogs.Add(new Dialog("Shadow", "I'll take care of them after you've clear the bases."));
		dialogs.Add(new Dialog("Alpha", "Okay, I'll take care of those bases."));
		dialogs.Add(new Dialog("Alpha", "By the way, who are you? Why do you know Beta and me?",2));
		dialogs.Add(new Dialog("Shadow", "... I'm Delta."));
		dialogs.Add(new Dialog("Delta", "I know you because... I am acquaintance of Be-..."));
		//shake and SF
		dialogs.Add(new Dialog("Alpha", "What happened?",3));
		dialogs.Add(new Dialog("Delta", "Oh no, this place is going to collapse!",3));
		dialogs.Add(new Dialog("Delta", "You must get out now!",3));
		dialogs.Add(new Dialog("Delta", "I'll contact you if I got any news about \"the Reality\"."));
		dialogs.Add(new Dialog("Alpha", "Get out? How?",2));
		//Spin Alpha out
		dialogs.Add(new Dialog("Alpha", "Awww!",3));
		//FadeOut&In, with spinning effect sence changes
		dialogs.Add(new Dialog("Alpha", "Aww...",3));
		dialogs.Add(new Dialog("Alpha", "I’m back...",1));
		dialogs.Add(new Dialog("Alpha", "Okay, I better take action now.",1));
		
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

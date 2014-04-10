﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class StoryEngB : Plot {

	private CinematicCamera cam;
	private DialogManager dman;
	private List<Dialog> dialogs;
	private Actor alpha;
	private Actor alice;

	public Transform[] waypoints;
	
	private void Awake () {
		// initialize reference to dman
		dman = GetComponent<DialogManager>();
		cam = GameObject.FindGameObjectWithTag(Tags.mainCamera).GetComponent<CinematicCamera>();
		alpha = GameObject.Find("Alpha").GetComponent<Actor>();
		alice = GameObject.Find("Alice").GetComponent<Actor>();

		dialogs = new List<Dialog>();
		dialogs.Add(new Dialog("Boy", "Wait... I can't run any more..."));
		dialogs.Add(new Dialog("Girl", "Ah... Sorry, it seems that we've run far enough."));
		dialogs.Add(new Dialog("Boy", "Er... Why do we need to run by the way?",2));
		dialogs.Add(new Dialog("Boy", "It'll be fine if I just apologize, it's my fault anyway."));
		dialogs.Add(new Dialog("Girl", "It's not fine! Alpha.",3));
		dialogs.Add(new Dialog("Alpha", "Er... Why do you know my name?",2));
		dialogs.Add(new Dialog("Girl", "No way, you've forgot my name! It seems like you're not recovery yet.",3));
		dialogs.Add(new Dialog("Girl", "Let me use my punch to recall your memory then!"));
		dialogs.Add(new Dialog("Alpha", "Wait! I'm just joking, Alice.",3));
		dialogs.Add(new Dialog("Alpha", "Alice, I met her at orientation camp. She has skipped grades and admitted to the university as she is gifted and hard working.",1));
		dialogs.Add(new Dialog("Alice", "Stop joking around please."));
		dialogs.Add(new Dialog("Alpha", "One that hits others straight away has no right to say that."));
		dialogs.Add(new Dialog("Alice", "Ha, It seems that you recovered."));
		dialogs.Add(new Dialog("Alpha", "Yes, but the school seems to change a lot. The campus especially the engineering department is so spiritless."));
		dialogs.Add(new Dialog("Alice", "It's because of the recent introduction of \"Student Academic Reform Guideline\"."));
		dialogs.Add(new Dialog("Alpha", "Yeah, professor also mentioned that too. What's that?",2));
		dialogs.Add(new Dialog("Alice", "Apparently you know nothing about the recent changes as you are just recovered."));
		dialogs.Add(new Dialog("Alice", "Let me tell you then."));
		dialogs.Add(new Dialog("Alice", "\"Student Academic Reform Guideline\" is the new policy announced by the university."));
		dialogs.Add(new Dialog("Alice", "Simply put, its aim is to improve student academic achievement."));
		dialogs.Add(new Dialog("Alice", "However, what it's asking for is too harsh."));
		dialogs.Add(new Dialog("Alice", "Assignment has been doubled and lab have become mandatory with in-class quiz."));
		dialogs.Add(new Dialog("Alpha", "It really sounds scary..."));
		dialogs.Add(new Dialog("Alice", "Don't talk like you're nothing to do with it."));
		dialogs.Add(new Dialog("Alpha", "Sorry..."));
		dialogs.Add(new Dialog("Alpha", "Hum, What does the Chapter 1 Article 3 means then?",2));
		dialogs.Add(new Dialog("Alice", "\"Student Academic Reform Guideline\" Chapter 1 Article 3 states that professor has the right to punish inattentive students by sending them to \"Reeducation Camp\"."));
		dialogs.Add(new Dialog("Alice", "In \"Reeducation Camp\", students need to conduct multiple quizzes. And only the students with the top 3 scores of each quiz can leave..."));
		dialogs.Add(new Dialog("Alice", "There're many rumors about students that can't withstand the pressure and try to play truant but are missing after that..."));
		dialogs.Add(new Dialog("Alpha", "Oh my god, I am really at risk back then. Without your help, I must be in \"Reeducation Camp\" right now.",3));
		dialogs.Add(new Dialog("Alpha", "Thank you."));
		dialogs.Add(new Dialog("Alice", "It's okay. After all, the sudden change of the school is part of my responsibility..."));
		dialogs.Add(new Dialog("Alpha", "Eh... Responsibility?",2));
		dialogs.Add(new Dialog("Alice", "Oh, the next lecture is almost time! Late comer will have additional assignment!",3));
		dialogs.Add(new Dialog("Alice", "I must be hurry, see you next time."));
		dialogs.Add(new Dialog("Alice", "Ah, if you meet Beta, say hello to her for me please. I haven't met her since you were admitted. I'm so worrying about her."));
		dialogs.Add(new Dialog("Alpha", "Okay, you can count on me. But you better hurry now..."));
		dialogs.Add(new Dialog("Alpha", "It's great that Alice is energetic as always.",1));
		dialogs.Add(new Dialog("Alpha", "Okay, I need to investigate what's going on with Beta now.",1));
		dialogs.Add(new Dialog("Alpha", "Beta, my neighbor's daughter and my playmate since we were child, always get into troubles and let others worry.",1));
		dialogs.Add(new Dialog("Alpha", "Sign, what troubles could she possible get into even I was at hospital.",1));
	}
	
	
	public void Start()
	{
		base.startStoryScene();
	}
	
	protected override IEnumerator sequencer()
	{
		StartCoroutine(cam.FadeOut());

		dman.openDialog();

		//steps sound

		StartCoroutine(alice.run(waypoints[0]));
		yield return StartCoroutine(alpha.run(waypoints[1]));
		yield return StartCoroutine(cam.orbitMotion(waypoints[2], 55));

		yield return StartCoroutine(dman.display(dialogs[0],alpha.EmotionPt));
		yield return StartCoroutine(base.interactToProceed());
		dman.clearEmotion();

		yield return StartCoroutine(alpha.faceTo(alice.transform));
		yield return StartCoroutine(alice.faceTo(alpha.transform));

		yield return StartCoroutine(cam.zoom(1.5f, 2));

		for (int index = 1; index < 33; index++) {
			switch(dialogs[index].Speaker)
			{
			case "Boy": case "Alpha":
				yield return StartCoroutine(dman.display(dialogs[index],alpha.EmotionPt));
				yield return StartCoroutine(base.interactToProceed());
				break;
			case "Girl": case "Alice":
				yield return StartCoroutine(dman.display(dialogs[index],alice.EmotionPt));
				yield return StartCoroutine(base.interactToProceed());
				break;
			default:
				yield return StartCoroutine(dman.display(dialogs[index]));
				yield return StartCoroutine(base.interactToProceed());
				break;
			}
		}

		//clock sound

		yield return StartCoroutine(dman.display(dialogs[33],alice.EmotionPt));
		yield return StartCoroutine(base.interactToProceed());
		yield return StartCoroutine(dman.display(dialogs[34],alice.EmotionPt));
		yield return StartCoroutine(base.interactToProceed());
		dman.clearEmotion();

		StartCoroutine(cam.orbitMotion(waypoints[2], 135));

		//Alice run to class
		yield return StartCoroutine(alice.run(waypoints[3]));
		yield return StartCoroutine(alice.faceTo(alpha.transform));

		yield return StartCoroutine(dman.display(dialogs[35],alice.EmotionPt));
		yield return StartCoroutine(base.interactToProceed());
		dman.clearEmotion();

		//Alice run & disappear
		StartCoroutine(alice.alphaChange(0));
		StartCoroutine(alice.run(waypoints[4]));

		for (int index = 36; index < dialogs.Count; index++) {
				yield return StartCoroutine(dman.display(dialogs[index],alpha.EmotionPt));
				yield return StartCoroutine(base.interactToProceed());
		}

		dman.closeDialog();

		yield return StartCoroutine(cam.FadeIn());
	}
}

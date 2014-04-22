using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class StoryEngA : Plot {
	
	public Transform[] targets;
	private List<Dialog> dialogs;
	private DialogManager dman;

	private void Awake () {
		// initialize reference to dman
		dman = GetComponent<DialogManager>();

		dialogs = new List<Dialog>();		

		dialogs.Add(new Dialog("Professor", "Ridiculous! Who's producing that noise?",2));
		dialogs.Add(new Dialog("Girl", "Hey, wake up! Professor's about to get angry..."));
		dialogs.Add(new Dialog("Boy", "Zzz..."));
		dialogs.Add(new Dialog("Professor", "You! Why do you keep your eyes closed during my lecture?",2));
		dialogs.Add(new Dialog("Boy", "Zzz..."));
		dialogs.Add(new Dialog("Girl", "Hey, wake up..."));
		dialogs.Add(new Dialog("Professor", "Are you listening?",2));
		dialogs.Add(new Dialog("Girl", "Professor, he must be thinking about the sentences you mentioned."));
		dialogs.Add(new Dialog("Professor", "Then why does he keep nodding?",2));
		dialogs.Add(new Dialog("Girl", "It must mean he agrees with your every word."));
		dialogs.Add(new Dialog("Professor", "Aha... Then why is he drooling?",2));
		dialogs.Add(new Dialog("Girl", "Er... Maybe he is savoring your sentences."));
		dialogs.Add(new Dialog("Professor", "Okay. Then why is he snoring?",2));
		dialogs.Add(new Dialog("Girl", "Er..."));
		dialogs.Add(new Dialog("Professor", "Great, It seem that you have no more excuses."));
		dialogs.Add(new Dialog("Professor", "Then base on the newly released \"Student Academic Reform Guideline\" Chapter 1 Article 3, I..."));
		dialogs.Add(new Dialog("Girl", "Hey, we better run!",3));
		dialogs.Add(new Dialog("Boy", "What?",3));
		dialogs.Add(new Dialog("Professor", "Freeze!",3));
		
	}

	public void Start()
	{
		base.startStoryScene();
	}

	protected override IEnumerator sequencer()
	{
		dman.openDialog();
		// automatically display dialogs
		foreach (Dialog d in dialogs) {
			yield return StartCoroutine(dman.display(d));
			yield return StartCoroutine(dman.interactToProceed());
		}
		dman.closeDialog();
	}
}

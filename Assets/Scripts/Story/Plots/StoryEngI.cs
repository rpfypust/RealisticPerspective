using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StoryEngI : Plot {
	
	public Transform[] targets;
	private List<Dialog> dialogs;
	private DialogManager dman;
	private CinematicCamera cam;
	
	private void Awake () {
		// initialize reference to dman
		dman = GetComponent<DialogManager>();
		cam = GameObject.FindGameObjectWithTag(Tags.mainCamera).GetComponent<CinematicCamera>();
		
		dialogs = new List<Dialog>();		
		
		dialogs.Add(new Dialog("Alpha", "This is…… memory of other again?",2));
		//Memory Enter Effect
		dialogs.Add(new Dialog("Girl", "Doctor, how’s the patient’s condition?",2));
		dialogs.Add(new Dialog("Doctor", "After all rescue measures, the patient’s condition has been stabilized."));
		dialogs.Add(new Dialog("Doctor", "However, at the present stage the patient is still in coma."));
		dialogs.Add(new Dialog("Doctor", "Whether he can wake up or not depends on how strong his will is."));
		dialogs.Add(new Dialog("Girl", "What if he can’t wake up...",2));
		dialogs.Add(new Dialog("Doctor", "I’m afraid that he will remain in vegetative state..."));
		dialogs.Add(new Dialog("Girl", "..."));
		dialogs.Add(new Dialog("Alpha", "It’s over..."));
		//walk in suddenly
		dialogs.Add(new Dialog("Alpha", "Wa! Stop scaring people, ok?",3));
		dialogs.Add(new Dialog("Delta", "If you got time to peer stranger’s memory, I suggest you better work on the next enemy’s base."));
		dialogs.Add(new Dialog("Alpha", "Yes yes... Here I go..."));
		//Tunnel Out
		dialogs.Add(new Dialog("Delta", "...Time is running out..."));
		
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

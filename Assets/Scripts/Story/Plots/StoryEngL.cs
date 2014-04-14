using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StoryEngL : Plot {
	
	public Transform[] targets;
	private List<Dialog> dialogs;
	private DialogManager dman;
	private CinematicCamera cam;
	
	private void Awake () {
		// initialize reference to dman
		dman = GetComponent<DialogManager>();
		cam = GameObject.FindGameObjectWithTag(Tags.mainCamera).GetComponent<CinematicCamera>();
		
		dialogs = new List<Dialog>();		

		dialogs.Add(new Dialog("Zeta", "... You're really tough..."));
		dialogs.Add(new Dialog("Alpha", "It's enough! Stop please."));
		dialogs.Add(new Dialog("Zeta", "No! I'm not going to be \"denied\" again!",3));
		dialogs.Add(new Dialog("Zeta", "I'll show you my true power! You'll regret soon!",3));
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

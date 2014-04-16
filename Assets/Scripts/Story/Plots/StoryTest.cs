using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StoryTest : Plot {

	public Transform[] targets;
	private List<Dialog> dialogs;
	private DialogManager dman;
	private CinematicCamera cam;

	private Actor actor;

	private void Awake () {
		// initialize reference to dman
		dman = GetComponent<DialogManager>();
		//cam = GameObject.FindGameObjectWithTag(Tags.mainCamera).GetComponent<CinematicCamera>();
		actor = GameObject.Find("Actor").GetComponent<Actor>();
		dialogs = new List<Dialog>();		


		
	}
	
	public void Start()
	{
		base.startStoryScene();
	}
	
	protected override IEnumerator sequencer()
	{	
		yield return StartCoroutine(actor.tunnelIn());
	}
}

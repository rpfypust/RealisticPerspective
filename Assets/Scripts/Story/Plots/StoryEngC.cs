using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StoryEngC : Plot {
	
	public Transform[] targets;
	private List<Dialog> dialogs;
	private DialogManager dman;
	private CinematicCamera cam;
	
	private void Awake () {
		// initialize reference to dman
		dman = GetComponent<DialogManager>();
		cam = GameObject.FindGameObjectWithTag(Tags.mainCamera).GetComponent<CinematicCamera>();
		
		dialogs = new List<Dialog>();		
		
		dialogs.Add(new Dialog("Alpha", "It seems not a clue at all…… What should I do now...",1));
		//Phone Ring
		dialogs.Add(new Dialog("Phone", "I'm in emergency, meet me at the Mushroom."));
		dialogs.Add(new Dialog("Alpha", "Sign, sudden disappear and unforeseen show up, It's her style.",1));
		dialogs.Add(new Dialog("Alpha", "Emergency... I must hurry now.",1));

		dialogs.Add(new Dialog("Alpha", "Okay... Where is she?"));
		//Look around
		dialogs.Add(new Dialog("Alpha", "..."));
		dialogs.Add(new Dialog("Alpha", "What, not here..."));
		//Shadow comes out
		dialogs.Add(new Dialog("Alpha", "Oh, Who's that cosplay?",3));
		dialogs.Add(new Dialog("Shadow", "It seems that you can see me."));
		dialogs.Add(new Dialog("Alpha", "What? Of course, you are so noticeable with that costume."));
		dialogs.Add(new Dialog("Shadow", "No, except you others can't see me."));
		dialogs.Add(new Dialog("Shadow", "Indeed they can't aware my existence at all."));
		dialogs.Add(new Dialog("Alpha", "Still no clues who is she cosplaying, but she is really in character.",1));
		dialogs.Add(new Dialog("Alpha", "It's not time for cosplaying, I must find Beta now.",1));
		dialogs.Add(new Dialog("Alpha", "Sorry, I'm searching my friend. I got no time for cosplayering with you."));
		dialogs.Add(new Dialog("Shadow", "Beta. Are you searching her?",2));
		dialogs.Add(new Dialog("Alpha", "Why do you know that?",3));
		dialogs.Add(new Dialog("Alpha", "Are you her friend?",3));
		dialogs.Add(new Dialog("Alpha", "Can you tell me where she is now?",3));
		dialogs.Add(new Dialog("Shadow", "She is no longer in \"the Outer World\". She has been trapped in another side, \"the Inner World\"."));
		dialogs.Add(new Dialog("Alpha", "Are you still cosplaying? Can you take it seriously and answer my questions, please?",2));
		dialogs.Add(new Dialog("Shadow", "Now, You must pass through a \"Tunnel\" that links \"the Worlds\"."));
		dialogs.Add(new Dialog("Shadow", "Then you must defeat \"the Denied\" in \"the Inner World\" to save Beta and the whole campus."));
		dialogs.Add(new Dialog("Alpha", "It seems that normal commination can't work. I better echo with her as after all only she got information about Beta.",1));
		dialogs.Add(new Dialog("Alpha", "Okay, I understand now. Where's the \"Tunnel\" then? I'd like to meet Beta as soon as possible."));
		dialogs.Add(new Dialog("Shadow", "Very well, Let me open a \"Tunnel\" for you now."));
		dialogs.Add(new Dialog("Shadow", "... I... not... deny..."));
		dialogs.Add(new Dialog("Alpha", "What's she muttering? Spell?",1));
		dialogs.Add(new Dialog("Alpha", "Have you fini-..."));
		//Effect together
		dialogs.Add(new Dialog("Alpha", "Er... Awww!",3));
		
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

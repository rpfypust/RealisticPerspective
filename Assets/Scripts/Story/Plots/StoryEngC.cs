using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StoryEngC : Plot {
	
	private CinematicCamera cam;
	private DialogManager dman;
	private List<Dialog> dialogs;
	private SEManager sem;
	private BGMManager bgm;
	private Actor alpha;
	private Actor shadow;

	public Transform[] waypoints;

	private void Awake () {
		// initialize reference to dman
		dman = GetComponent<DialogManager>();
		cam = GameObject.FindGameObjectWithTag(Tags.mainCamera).GetComponent<CinematicCamera>();
		sem = GetComponentInChildren<SEManager>();
		bgm = GetComponentInChildren<BGMManager>();
		alpha = GameObject.Find("Alpha").GetComponent<Actor>();
		shadow = GameObject.Find("Shadow").GetComponent<Actor>();
		
		dialogs = new List<Dialog>();		
		
		dialogs.Add(new Dialog("Alpha", "It seems not a clue at all…… What should I do now...",1));
		//Phone Ring
		dialogs.Add(new Dialog("Phone", "I'm in emergency, meet me at the Mushroom."));
		dialogs.Add(new Dialog("Alpha", "Sign, sudden disappear and unforeseen show up, It's her style.",1));
		dialogs.Add(new Dialog("Alpha", "Emergency... I must hurry now.",1));

		dialogs.Add(new Dialog("Alpha", "Okay... Where is she?"));
		//Look around
		dialogs.Add(new Dialog("Alpha", "... ... ..."));
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
		dialogs.Add(new Dialog("Alpha", "It seems that normal communication can't work. I better echo with her as after all only she got information about Beta.",1));
		dialogs.Add(new Dialog("Alpha", "Okay, I understand now. Where's the \"Tunnel\" then? I'd like to meet Beta as soon as possible."));
		dialogs.Add(new Dialog("Shadow", "Very well, Let me open a \"Tunnel\" for you now."));
		dialogs.Add(new Dialog("Shadow", "... I... not... deny..."));
		dialogs.Add(new Dialog("Alpha", "What's she muttering? Spell?",1));
		dialogs.Add(new Dialog("Alpha", "Have you fini-..."));
		//Effect together
		dialogs.Add(new Dialog("Alpha", "Er... ... ... Awww!",3));
		
	}
	
	public void Start()
	{
		base.startStoryScene();
	}
	
	protected override IEnumerator sequencer()
	{	
		yield return StartCoroutine(cam.SolidBlack(1f));
		StartCoroutine(cam.FadeOut());
		StartCoroutine(shadow.alphaChange(0,1));

		StartCoroutine(alpha.runWithSpeed(waypoints[0],2));
		yield return StartCoroutine(cam.orbitMotion(waypoints[0], -30, 2));

		dman.openDialog();

		yield return StartCoroutine(dman.display(dialogs[0],alpha.EmotionPt));
		yield return StartCoroutine(dman.interactToProceed());
		sem.PlaySoundEffect(4);
		yield return StartCoroutine(dman.display(dialogs[1]));
		yield return StartCoroutine(dman.interactToProceed());
		yield return StartCoroutine(dman.display(dialogs[2],alpha.EmotionPt));
		yield return StartCoroutine(dman.interactToProceed());
		yield return StartCoroutine(dman.display(dialogs[3],alpha.EmotionPt));
		yield return StartCoroutine(dman.interactToProceed());

		StartCoroutine(alpha.runWithSpeed(waypoints[1],2));
		yield return new WaitForSeconds(1.5f);

		dman.closeDialog();
		yield return StartCoroutine(cam.FadeIn());
		yield return StartCoroutine(cam.SolidBlack(2f));


		StartCoroutine(cam.FadeOut());
		alpha.transform.position = waypoints[2].position;
		alpha.transform.rotation = waypoints[2].rotation;
		cam.transform.position = waypoints[4].position;
		cam.transform.rotation = waypoints[4].rotation;

		bgm.changeVolume(0.4f);
		bgm.LoopBGM(0);
		StartCoroutine(alpha.runWithSpeed(waypoints[3],2));
		yield return StartCoroutine(cam.transform.LinearMoveWithTime(waypoints[4].position, waypoints[5].position, 4));
		StartCoroutine(alpha.rotate(-180,2));
		yield return StartCoroutine(cam.orbitMotion(waypoints[3],-180,2));

		dman.openDialog();

		yield return StartCoroutine(dman.display(dialogs[4],alpha.EmotionPt));
		yield return StartCoroutine(dman.interactToProceed());
		StartCoroutine(alpha.rotate(-20,0.75f));
		yield return StartCoroutine(cam.orbitMotion(waypoints[3],-20,1));
		StartCoroutine(alpha.rotate(50,1.5f));
		yield return StartCoroutine(cam.orbitMotion(waypoints[3],50,1.5f));
		StartCoroutine(alpha.rotate(-25,0.75f));
		yield return StartCoroutine(cam.orbitMotion(waypoints[3],-25,0.75f));
		yield return StartCoroutine(dman.display(dialogs[5],alpha.EmotionPt));
		yield return StartCoroutine(dman.interactToProceed());
		yield return StartCoroutine(dman.display(dialogs[6],alpha.EmotionPt));
		yield return StartCoroutine(dman.interactToProceed());

		yield return StartCoroutine(dman.display(dialogs[7],alpha.EmotionPt));
		yield return StartCoroutine(alpha.faceTo(shadow.transform, 0.5f));
		StartCoroutine(cam.orbitMotion(waypoints[7], -135, 5));
		StartCoroutine(shadow.alphaChange(1, 1));
		yield return StartCoroutine(shadow.walkWithTime(waypoints[6],2));
		yield return StartCoroutine(dman.interactToProceed());
		yield return StartCoroutine(alpha.faceTo(shadow.transform, 0.5f));

		StartCoroutine(cam.orbitMotion(waypoints[7],-200,15f));
		for (int index = 8; index < 29; index++) {
			switch(dialogs[index].Speaker)
			{
			case "Alpha":
				yield return StartCoroutine(dman.display(dialogs[index],alpha.EmotionPt));
				yield return StartCoroutine(dman.interactToProceed());
				break;
				
			case "Shadow":
				yield return StartCoroutine(dman.display(dialogs[index],shadow.EmotionPt));
				yield return StartCoroutine(dman.interactToProceed());
				break;
				
			default:
				yield return StartCoroutine(dman.display(dialogs[index]));;
				yield return StartCoroutine(dman.interactToProceed());
				break;
			}
		}
		yield return StartCoroutine(dman.display(dialogs[29],alpha.EmotionPt));

		yield return StartCoroutine(alpha.tunnelIn());

		dman.closeDialog();

		yield return StartCoroutine(cam.FadeIn());

	}
}

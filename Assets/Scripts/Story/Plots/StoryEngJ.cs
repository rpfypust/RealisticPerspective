using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StoryEngJ : Plot {
	
	public Transform[] wayPoints;
	private List<Dialog> dialogs;
	private DialogManager dman;
	private CinematicCamera cam;
	private BGMManager bgm;
	private Actor alpha;
	private Actor delta;

	private GameController gamecon;

	private void Awake () {
		// initialize reference to dman
		dman = GetComponent<DialogManager>();
		cam = GameObject.FindGameObjectWithTag(Tags.mainCamera).GetComponent<CinematicCamera>();
		bgm = GetComponentInChildren<BGMManager>();
		alpha = GameObject.Find("Alpha").GetComponent<Actor>();
		delta = GameObject.Find("Delta").GetComponent<Actor>();

		gamecon = GameObject.FindGameObjectWithTag(Tags.gameController)
			.GetComponent<GameController>();

		dialogs = new List<Dialog>();		
		
		dialogs.Add(new Dialog("Alpha", "Mission accomplished."));
		//WalkIN
		dialogs.Add(new Dialog("Delta", "Well done."));
		dialogs.Add(new Dialog("Alpha", "Hey, Delta. Did you finish your investigation?",2));
		dialogs.Add(new Dialog("Delta", "Yes. And I'm going to tell you're the result."));
		dialogs.Add(new Dialog("Alpha", "Great."));
		dialogs.Add(new Dialog("Delta", "I tried to look into Dr. Zeta, and found that he is absolutely related to the conspiracy."));
		dialogs.Add(new Dialog("Delta", "Dr. Zeta was the first person that proposes the existence of \"the Inner World\" and \"the Outer World\"."));
		dialogs.Add(new Dialog("Delta", "However, his hypothesis wasn't recognized by the scholars. They didn't take the hypothesis serious and sneer at it."));
		dialogs.Add(new Dialog("Delta", "After several attempts to publish his hypothesis but all has failed, Dr. Zeta faded out from the academia."));
		dialogs.Add(new Dialog("Alpha", "Where is he now?",2));
		dialogs.Add(new Dialog("Alpha", "If we can reach him, we can ask him for help."));
		dialogs.Add(new Dialog("Delta", "Sign, you really don't keep an eye on campus's news."));
		dialogs.Add(new Dialog("Delta", "Dr. Zeta is the dean of the engineering department that taken office lately."));
		dialogs.Add(new Dialog("Alpha", "No way, such coincidence!",3));
		dialogs.Add(new Dialog("Alpha", "Then let's go find him."));
		dialogs.Add(new Dialog("Delta", "No!",3));
		dialogs.Add(new Dialog("Alpha", "Why?",2));
		dialogs.Add(new Dialog("Delta", "Haven't you heard of the \"Student Academic Reform Guideline\"?"));
		dialogs.Add(new Dialog("Alpha", "Yes, but how does it related to this?",2));
		dialogs.Add(new Dialog("Delta", "The proposer of the guideline is Dr. Zeta."));
		dialogs.Add(new Dialog("Delta", "And those missing students in \"Reeducation Camp\" has contacted with \"the Reality\" before they went missing."));
		dialogs.Add(new Dialog("Delta", "It seems that they are making use of the denials of students towards \"Reeducation Camp\" as raw materials to open \"Tunnels\" in UST."));
		dialogs.Add(new Dialog("Alpha", "This...Dr. Zeta is the conspirators behind all these..."));
		dialogs.Add(new Dialog("Delta", "Yes, so you can't reveal yourself to him."));
		dialogs.Add(new Dialog("Alpha", "What should I do then?",2));
		dialogs.Add(new Dialog("Delta", "Anyway there're one base left only. You better clear it before we deal with Dr. Zeta."));
		dialogs.Add(new Dialog("Delta", "I'll try my best to figure out how to tackle Dr. Zeta in the meantime."));
		dialogs.Add(new Dialog("Alpha", "No problem, I wish to rescue Beta first too."));
		dialogs.Add(new Dialog("Delta", "Beta...You still remember..."));
		dialogs.Add(new Dialog("Alpha", "What are you talking about? I'm only solving this incident in passing. My true target is to rescue Beta after all."));
		dialogs.Add(new Dialog("Delta", "...so arrogant..."));
		dialogs.Add(new Dialog("Alpha", "Ha, I need to go to the next base then, see you later."));
		//Thunnel Out
		dialogs.Add(new Dialog("Delta", "Alpha..."));
	}
	
	public void Start()
	{
		base.startStoryScene();
	}
	
	protected override IEnumerator sequencer()
	{	
		yield return StartCoroutine(cam.SolidBlack(1f));
		StartCoroutine(cam.FadeOut());
		bgm.changeVolume(0.3f);
		bgm.LoopBGM(0);
		yield return StartCoroutine(alpha.walkWithTime(wayPoints[1],2));

		dman.openDialog();

		yield return StartCoroutine(dman.display(dialogs[0],alpha.EmotionPt));
		yield return StartCoroutine(dman.interactToProceed());

		yield return StartCoroutine(delta.tunnelOut());

		dman.openDialog();
		StartCoroutine(cam.orbitMotion(wayPoints[0], 360, 30));
		for (int index = 1; index < 32; index++) {
			switch(dialogs[index].Speaker)
			{
			case "Alpha":
				yield return StartCoroutine(dman.display(dialogs[index],alpha.EmotionPt));
				yield return StartCoroutine(dman.interactToProceed());
				break;
				
			case "Delta":
				yield return StartCoroutine(dman.display(dialogs[index],delta.EmotionPt));
				yield return StartCoroutine(dman.interactToProceed());
				break;
			}
		}
		StartCoroutine(cam.orbitMotion(wayPoints[0], -90, 1));
		StartCoroutine(cam.pan(new Vector3(0,0.5f,0), 1));
		yield return StartCoroutine(alpha.tunnelIn());
		yield return StartCoroutine(dman.display(dialogs[32],delta.EmotionPt));
		yield return StartCoroutine(dman.interactToProceed());

		dman.closeDialog();
		gamecon.LoadLevel(SceneIndice.TRANSITION);
	}
}

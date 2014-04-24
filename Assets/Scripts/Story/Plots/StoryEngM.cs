using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StoryEngM : Plot {
	
	public Transform[] wayPoints;
	private List<Dialog> dialogs;
	private DialogManager dman;
	private CinematicCamera cam;
	private BGMManager bgm;
	private Actor alpha;
	private Actor delta;
	private Actor renroh;
	private Actor alice;
	private GameObject particle;

	private GameController gamecon;
	
	private void Awake () {
		// initialize reference to dman
		dman = GetComponent<DialogManager>();
		cam = GameObject.FindGameObjectWithTag(Tags.mainCamera).GetComponent<CinematicCamera>();
		bgm = GetComponentInChildren<BGMManager>();
		alpha = GameObject.Find("Alpha").GetComponent<Actor>();
		delta = GameObject.Find("Delta").GetComponent<Actor>();
		renroh = GameObject.Find("Renroh").GetComponent<Actor>();
		alice = GameObject.Find("Alice").GetComponent<Actor>();
		particle = GameObject.Find("VanishEffect");
		particle.SetActive(false);

		gamecon = GameObject.FindGameObjectWithTag(Tags.gameController)
			.GetComponent<GameController>();


		dialogs = new List<Dialog>();		

		dialogs.Add(new Dialog("Renroh", "...... You can't defect me...... "));
		dialogs.Add(new Dialog("Alice", "Stop!",3));
		dialogs.Add(new Dialog("Alpha", "Alice! How come you are here? It's dangerous, go away!",3));
		dialogs.Add(new Dialog("Renroh", "Alice, don't get close!"));
		dialogs.Add(new Dialog("Alice", "No! Alpha! Father!"));
		dialogs.Add(new Dialog("Alice", "Stop! Please!"));
		dialogs.Add(new Dialog("Alpha", "Father?",2));
		dialogs.Add(new Dialog("Alice", "Yes, I'm daughter of Dr. Renroh."));
		dialogs.Add(new Dialog("Alice", "For me sake, stop please, Alpha..."));
		dialogs.Add(new Dialog("Alice", "My father is not really a bad person. He did everything for me..."));
		dialogs.Add(new Dialog("Alpha", "Wait, what's the story?",2));
		dialogs.Add(new Dialog("Renroh", "Alice, stop that!",3));
		dialogs.Add(new Dialog("Renroh", "I'll definitely fulfill my promise this time, after I defeat this guy in the way..."));
		dialogs.Add(new Dialog("Renroh", "So just wait father some time..."));
		dialogs.Add(new Dialog("Alice", "Father, it's enough already..."));
		dialogs.Add(new Dialog("Alice", "Forget the promise, it's my willfulness..."));
		dialogs.Add(new Dialog("Renroh", "No, I'll not give up!",3));
		dialogs.Add(new Dialog("Renroh", "I must prove the existences of \"the Worlds\" to the world!"));
		dialogs.Add(new Dialog("Alice", "It's enough... It's enough..."));
		dialogs.Add(new Dialog("Alice", "In fact I understand that, even the promise is fulfilled..."));
		dialogs.Add(new Dialog("Alice", "Even the promise is fulfilled... Mother..."));
		dialogs.Add(new Dialog("Renroh", "Stop it!",3));
		dialogs.Add(new Dialog("Alice", "Mother also won't be back!"));
		dialogs.Add(new Dialog("Renroh", "Stop it!",3));
		dialogs.Add(new Dialog("Alice", "Because... Mother was dead already... BooHoo..."));
		dialogs.Add(new Dialog("Renroh", "Please... say no more..."));
		dialogs.Add(new Dialog("Alpha", "This..."));

		dialogs.Add(new Dialog("Delta", "Gamma, the real proposer of \"the Worlds\"."));
		dialogs.Add(new Dialog("Delta", "At the university, she met the genius Renroh."));
		dialogs.Add(new Dialog("Delta", "After graduation, they set up a research organization, \"the Reality\" and started to work on various research."));
		dialogs.Add(new Dialog("Delta", "At the same year, they got married and gave birth to a daughter, and named her Alice."));
		dialogs.Add(new Dialog("Delta", "But the morning sun never lasts a day. Right after \"the Reality\" started to focus its research on \"the Worlds\", it lost its recognition of the academia."));
		dialogs.Add(new Dialog("Delta", "All academic organizations withdraw their sponsorship for \"the Reality\" successively."));
		dialogs.Add(new Dialog("Delta", "Opportunity seldom knocks twice but misery loves company."));
		dialogs.Add(new Dialog("Delta", "Gamma caught a chronic disease due to overwork at that time, and passed away the next year..."));

		dialogs.Add(new Dialog("Renroh", "Please stop it! It's enough already..."));
		dialogs.Add(new Dialog("Renroh", "It's all world's fault! Gamma died because she received no proper treatment!"));
		dialogs.Add(new Dialog("Renroh", "If they hadn't withdrawn their sponsorship... If people had believed us..."));
		
		dialogs.Add(new Dialog("Delta", "But Renroh hadn't stopped his research. It's because of a lie..."));

		dialogs.Add(new Dialog("Alice", "No... It's not a lie..."));
		dialogs.Add(new Dialog("Alice", "It's a promise that a father made to her daughter..."));
		dialogs.Add(new Dialog("Alice", "A promise that protects his daughter from the cruel fact..."));
		dialogs.Add(new Dialog("Alice", "I'm relying on father's promise..."));
		dialogs.Add(new Dialog("Alice", "Believing that once father proves mother's ideas to the world, she will be back..."));
		dialogs.Add(new Dialog("Alice", "So that I can avoid a painful life of revenge..."));
		dialogs.Add(new Dialog("Alice", "So that I can meet you, so that I can..."));
		dialogs.Add(new Dialog("Alice", "But..."));
		dialogs.Add(new Dialog("Alice", "But... I'm really stupid..."));
		dialogs.Add(new Dialog("Alice", "I didn't even notice my pain is not gone..."));
		dialogs.Add(new Dialog("Alice", "Father... Dad has always been bore my share of pain..."));
		dialogs.Add(new Dialog("Alice", "Dad has been no relief... Hoo..."));
		dialogs.Add(new Dialog("Alice", "So... Dad is okay now..."));
		dialogs.Add(new Dialog("Alice", "You don't need to keep your promise anymore..."));
		dialogs.Add(new Dialog("Alice", "Turn back to the gentle father, okay...?"));
		
		dialogs.Add(new Dialog("Renroh", "Alice... You really grow up a lot without notice..."));
		dialogs.Add(new Dialog("Renroh", "You're even stronger then father now..."));
		dialogs.Add(new Dialog("Renroh", "Sorry... Dad can't keep my promise now..."));
		dialogs.Add(new Dialog("Renroh", "Can you forgive dad...?"));
		dialogs.Add(new Dialog("Alice", "Hoo... Of Course...! Hoo..."));
		dialogs.Add(new Dialog("Renroh", "Thank you..."));
		dialogs.Add(new Dialog("Renroh", "Okay. Alice give me some time, there's one more thing I've to do."));

		dialogs.Add(new Dialog("Alpha", "One more thing?",2));
		dialogs.Add(new Dialog("Renroh", "Yes, I'd to expose another lie..."));
		dialogs.Add(new Dialog("Alpha", "Another lie?",2));
		dialogs.Add(new Dialog("Renroh", "Delta, could you do it yourself?",2));
		dialogs.Add(new Dialog("Delta", "...... ......"));
		dialogs.Add(new Dialog("Renroh", "You couldn't... Let me do it for you then..."));
		dialogs.Add(new Dialog("Renroh", "Let me tell you a tragic story, Alpha..."));
		dialogs.Add(new Dialog("Renroh", "The story begins with a teenager who has been diagnosed to have a rare genetic disorder."));
		dialogs.Add(new Dialog("Renroh", "After the surgery, the teenager didn't regain consciousness..."));
		dialogs.Add(new Dialog("Renroh", "Not able to accept the fact, the teenager's friends, a girl approached \"the Reality\"..."));
		dialogs.Add(new Dialog("Renroh", "Through \"the Reality\", the girl realized the existence of \"the Inner World\" and its underlying power..."));

		dialogs.Add(new Dialog("Delta", "Shut up!",3));
		dialogs.Add(new Dialog("Renroh", "No! I've to carry on, your time is running out..."));
		dialogs.Add(new Dialog("Renroh", "From then on, the girl kept telling a lie..."));
		dialogs.Add(new Dialog("Renroh", "He is not in coma... He is not in coma... He is not in coma..."));
		dialogs.Add(new Dialog("Renroh", "The girl kept \"denying\" this fact......"));
		dialogs.Add(new Dialog("Renroh", "Suddenly, likes angel heard the girl's wish."));
		dialogs.Add(new Dialog("Renroh", "The teenager woke up by the power of \"the Inner World\"..."));
		dialogs.Add(new Dialog("Renroh", "But, this is not a blessing from the angel..."));
		dialogs.Add(new Dialog("Renroh", "It's the devil's mischief......"));
		dialogs.Add(new Dialog("Renroh", "Because of using the power of \"the Inner World\" and breaking the order of \"the Worlds\"..."));
		dialogs.Add(new Dialog("Renroh", "The girl has been \"denied\" by \"the Outer World\", and has been banished to \"the Inner World\"..."));
		dialogs.Add(new Dialog("Renroh", "In \"the Inner World\", the girl will gradually be forgotten by others, and eventually vanish..."));
		dialogs.Add(new Dialog("Renroh", "Alpha, do you know the name of the teenager?",2));

		dialogs.Add(new Dialog("Alpha", "... That's me..."));
		dialogs.Add(new Dialog("Renroh", "Then do you know the name of the girl?",2));
		dialogs.Add(new Dialog("Alpha", "Eh...It's weird..."));
		dialogs.Add(new Dialog("Alpha", "I obviously should know...but I just can't think of it at the moment..."));
		dialogs.Add(new Dialog("Alpha", "The... The..."));
		dialogs.Add(new Dialog("Alpha", "Beta... She's Beta..."));
		dialogs.Add(new Dialog("Renroh", "Yes... the girl is Beta."));
		dialogs.Add(new Dialog("Alpha", "Where is Beta? You must know that, let me see her!",2));
		dialogs.Add(new Dialog("Alpha", "I don't want Beta to disappear!",3));
		dialogs.Add(new Dialog("Renroh", "It seems that the existence of Beta has started to fade away before you ever met Delta..."));
		dialogs.Add(new Dialog("Renroh", "At least when you met Delta, you already can't recall Beta's face already..."));
		dialogs.Add(new Dialog("Alpha", "It can't be!",3));
		dialogs.Add(new Dialog("Alpha", "I can't forget her face..."));
		dialogs.Add(new Dialog("Renroh", "In fact, Beta is just next to you all the time..."));
		dialogs.Add(new Dialog("Renroh", "Delta is the one you're looking for..."));

		dialogs.Add(new Dialog("Beta", "Enough! Why do you tell him!",3));
		dialogs.Add(new Dialog("Beta", "I'm almost time to disappear..."));
		dialogs.Add(new Dialog("Beta", "After I've disappear, Alpha'll forget me and live on happily..."));
		dialogs.Add(new Dialog("Beta", "Why do you still need to make Alpha sad!."));
		dialogs.Add(new Dialog("Alpha", "Beta..."));
		dialogs.Add(new Dialog("Alpha", "No, Beta..."));
		dialogs.Add(new Dialog("Alpha", "Of course, I'm sad..."));
		dialogs.Add(new Dialog("Alpha", "That's because you are going to disappear but I still can't think of your face..."));
		dialogs.Add(new Dialog("Alpha", "I still can't think of your smile..."));
		dialogs.Add(new Dialog("Alpha", "And I almost forget your name..."));
		dialogs.Add(new Dialog("Alpha", "Which shouldn't be forgiven at all......"));
		dialogs.Add(new Dialog("Alpha", "But, If I just forget you without knowing this..."));
		dialogs.Add(new Dialog("Alpha", "I must be even more sadder than now..."));
		dialogs.Add(new Dialog("Beta", "Alpha..."));
		dialogs.Add(new Dialog("Beta", "Woo... Woo..."));
		dialogs.Add(new Dialog("Alpha", "Baka, don't cry..."));
		dialogs.Add(new Dialog("Beta", "..."));
		dialogs.Add(new Dialog("Alpha", "Beta, do you still remember...?",2));
		dialogs.Add(new Dialog("Alpha", "Every time you get into trouble, who is going to save you at the end?",2));
		dialogs.Add(new Dialog("Beta", "You..."));
		dialogs.Add(new Dialog("Alpha", "Correct. Then why you don't trust me this time."));
		dialogs.Add(new Dialog("Alpha", "I'm just sleeping..."));
		dialogs.Add(new Dialog("Alpha", "If you get into trouble again..."));
		dialogs.Add(new Dialog("Alpha", "I promise you, I'll be at your side."));
		dialogs.Add(new Dialog("Beta", "Promise?"));
		dialogs.Add(new Dialog("Alpha", "Yes, I promise."));
		dialogs.Add(new Dialog("Alpha", "So you've to accept the fact..."));
		dialogs.Add(new Dialog("Beta", "No, I don't want t-..."));
		dialogs.Add(new Dialog("Alpha", "Beta, sometime the reality is cruel..."));
		dialogs.Add(new Dialog("Alpha", "Cruel enough that it forces you to just \"deny\" it..."));
		dialogs.Add(new Dialog("Alpha", "But if you just keep \"denying\", nothing is going to be solved. We'll just lose more at the end..."));
		dialogs.Add(new Dialog("Alpha", "A world that without you... I won't be ever live happily..."));
		dialogs.Add(new Dialog("Alpha", "So you can't \"deny\" the reality..."));
		dialogs.Add(new Dialog("Alpha", "We've to \"accept\" the reality, so everything we did won't come to naught..."));
		dialogs.Add(new Dialog("Alpha", "We're need to \"accept\" the reality, so that we can take a step to the future."));
		dialogs.Add(new Dialog("Alpha", "Therefore, \"accept\" the reality, please?"));
		dialogs.Add(new Dialog("Beta", "Woo... Woo..."));
		dialogs.Add(new Dialog("Beta", "You really will wake up...?",2));
		dialogs.Add(new Dialog("Alpha", "Yes, of course."));
		dialogs.Add(new Dialog("Beta", "Promise?"));
		dialogs.Add(new Dialog("Alpha", "Yes, I promise."));
		dialogs.Add(new Dialog("Alpha", "Accept the reality then."));
		
		dialogs.Add(new Dialog("Beta", "I \"accept\" the fact that Alpha is still in coma..."));
		dialogs.Add(new Dialog("Beta", "But...... I \"believe\" that Alpha will wake up eventually!"));
		dialogs.Add(new Dialog("Beta", "I \"believe\" that Alpha'll be at my side everytime I got into trouble!"));
		dialogs.Add(new Dialog("Alpha", "Thank you..."));
		dialogs.Add(new Dialog("Alpha", "I need to take a nap now..."));
		dialogs.Add(new Dialog("Alpha", "Good night... Beta..."));
		dialogs.Add(new Dialog("Beta", "Good night... Alpha..."));
		dialogs.Add(new Dialog("Beta", "Woo woo... Woo woo... Alpha...!"));
	}


	public void Start()
	{
		base.startStoryScene();
	}
	
	protected override IEnumerator sequencer()
	{	
		bgm.changeVolume(0.3f);
		bgm.PlayBGM(1);
		StartCoroutine(renroh.crouch());
		yield return StartCoroutine(cam.SolidBlack(1f));
		StartCoroutine(cam.FadeOut());
		yield return StartCoroutine(renroh.tunnelOut());

		dman.openDialog();
		for (int index = 147; index < 148; index++) {

			if(index == 1) //Alice comes out
			{
				StartCoroutine(cam.pan(new Vector3(0.8f, 0.3f, 0.4f), 0.5f));
				yield return StartCoroutine(cam.rotateY(-70, 0.5f));
				StartCoroutine(cam.rotateX(20, 0.5f));
				yield return StartCoroutine(alice.runWithTime(wayPoints[0], 2.0f));

				StartCoroutine(alpha.faceTo(alice.transform, 0.5f));
				StartCoroutine(renroh.faceTo(alice.transform, 0.5f));
			}

			if(index == 11) // Alice talks with Renroh
			{
				bgm.PlayBGM(2);
				StartCoroutine(alice.faceTo(renroh.transform, 0.5f));
				StartCoroutine(renroh.faceTo(alice.transform, 0.5f));

				StartCoroutine(cam.shift(new Vector3(-22.5f, 1.3f, -95.6f), new Vector3 (0,55.2f,0)));
			}

			if(index == 26) // Delta comes out
			{
				StartCoroutine(cam.shift(new Vector3(-20.9f, 1.4f, -96.5f), new Vector3 (0, 308, 0)));
				dman.closeDialog();
			}

			if(index == 27) // Delta walks and talks
			{
				dman.openDialog();
				StartCoroutine(cam.pan(new Vector3(-4.3f, -0.3f, 2.7f),1f));
				StartCoroutine(alpha.faceTo(delta.transform, 0.5f));
				StartCoroutine(alice.faceTo(delta.transform, 0.5f));
				StartCoroutine(renroh.faceTo(delta.transform, 0.5f));
				yield return StartCoroutine(delta.tunnelOut());

				StartCoroutine(delta.walkWithTime(wayPoints[1],10f));
				StartCoroutine(cam.pan(new Vector3(4.3f, 0.3f, -2.7f),12));
			}

			if(index == 35) // Renroh interupt
			{
				StartCoroutine(renroh.faceTo(delta.transform, 0.5f));
				StartCoroutine(delta.faceTo(renroh.transform, 0.5f));
				StartCoroutine(alice.faceTo(renroh.transform, 0.5f));
				StartCoroutine(alpha.faceTo(alice.transform, 0.5f));

				StartCoroutine(cam.shift(new Vector3(-22.8f, 1.5f, -94.3f), new Vector3 (20, 145, 0)));
			}

			if(index == 39) // Alice interupt
			{
				StartCoroutine(renroh.faceTo(alice.transform, 0.5f));
				StartCoroutine(delta.faceTo(alice.transform, 0.5f));
				StartCoroutine(alice.faceTo(delta.transform, 0.5f));
				StartCoroutine(alpha.faceTo(alice.transform, 0.5f));
			}

			if(index == 40) // Alice talks with Renroh
			{
				StartCoroutine(alice.faceTo(renroh.transform, 0.5f));
				StartCoroutine(renroh.faceTo(alice.transform, 0.5f));
				
				StartCoroutine(cam.shift(new Vector3(-22.5f, 1.3f, -95.6f), new Vector3 (0,55.2f,0)));
			}

			if(index == 60) // Renroh interupt
			{
				StartCoroutine(alice.faceTo(renroh.transform, 0.5f));
				StartCoroutine(delta.faceTo(renroh.transform, 0.5f));
				StartCoroutine(alpha.faceTo(renroh.transform, 0.5f));
				StartCoroutine(renroh.faceTo(alpha.transform, 0.5f));
				
				StartCoroutine(cam.shift(new Vector3(-20.7f, 1.8f, -95.3f), new Vector3 (30,248,0)));
			}

			if(index == 64) // Renroh asks Delta
			{
				StartCoroutine(renroh.faceTo(delta.transform, 0.5f));
			}

			if(index == 67) // Renroh talks story
			{
				StartCoroutine(renroh.faceTo(alpha.transform, 0.5f));
				StartCoroutine(cam.orbitMotion(wayPoints[2], 45, 25f));
			}

			if(index == 104) // Alpha talks with Delta
			{
				StartCoroutine(alpha.faceTo(delta.transform, 0.5f));
				StartCoroutine(delta.faceTo(alpha.transform, 0.5f));
				Destroy(GameObject.Find("Renroh"));
				Destroy(GameObject.Find("Alice"));
				yield return StartCoroutine(cam.shift(new Vector3(-21.5f, 1.5f, -95.4f), new Vector3 (0,240,0)));
			}

			if(index == 117) // Alpha talks with Delta "Beta, do you still remember...?"
			{
				yield return StartCoroutine(cam.shift(new Vector3(-22.9f, 1.75f, -95.0f), new Vector3 (20,149,0)));
			}

			if(index == 128) // Alpha talks with Delta "Beta, sometime the reality is cruel..."
			{
				bgm.audio.clip = bgm.bgms[2];
				bgm.audio.Play();
				yield return StartCoroutine(cam.shift(new Vector3(-21.86f, 1.45f, -95.37f), new Vector3 (0,230,0)));
			}

			if(index == 140) // Alpha talks with Delta "Yes, I promise."
			{
				yield return StartCoroutine(cam.shift(new Vector3(-22.7f, 1.45f, -95.66f), new Vector3 (0,140,0)));
			}

			if(index == 142) // Beta Accepts
			{
				yield return StartCoroutine(cam.shift(new Vector3(-21.86f, 1.45f, -95.37f), new Vector3 (0,230,0)));
			}

			if(index == 145) // "Thank you..."
			{
				yield return StartCoroutine(cam.shift(new Vector3(-22.7f, 1.45f, -95.66f), new Vector3 (0,140,0)));
			}


			switch(dialogs[index].Speaker)
			{
			case "Alpha":
				yield return StartCoroutine(dman.display(dialogs[index],alpha.EmotionPt));
				yield return StartCoroutine(dman.interactToProceed());
				break;
				
			case "Renroh":
				yield return StartCoroutine(dman.display(dialogs[index],renroh.EmotionPt));
				yield return StartCoroutine(dman.interactToProceed());
				break;

			case "Alice":
				yield return StartCoroutine(dman.display(dialogs[index],alice.EmotionPt));
				yield return StartCoroutine(dman.interactToProceed());
				break;

			case "Beta": case "Delta":
				yield return StartCoroutine(dman.display(dialogs[index],delta.EmotionPt));
				yield return StartCoroutine(dman.interactToProceed());
				break;
			}
		}
		// Vanish
			yield return StartCoroutine(dman.display(dialogs[148],delta.EmotionPt));

			yield return StartCoroutine(cam.shift(new Vector3(-23.24f, 2.5f, -95.054f), new Vector3 (45,140,0)));
			
			Transform meshTransform = alpha.transform.FindChild("armature");
			Vector3 normalScale = Vector3.one;
			Vector3 finalScale = new Vector3(1.2f, 1.2f, 1);
			particle.SetActive(true);
			yield return new WaitForSeconds(.5f);
			yield return StartCoroutine(meshTransform.ScaleWithTime(normalScale,finalScale,0.25f));
			normalScale = finalScale;
			finalScale = new Vector3(0, 0, 1);
			yield return StartCoroutine(meshTransform.ScaleWithTime(normalScale,finalScale,.5f));
			yield return StartCoroutine(dman.interactToProceed());

			yield return StartCoroutine(dman.display(dialogs[149],delta.EmotionPt));
			yield return StartCoroutine(dman.interactToProceed());

		dman.closeDialog();

		yield return StartCoroutine(cam.FadeIn());

		yield return StartCoroutine(cam.SolidBlack(5f));

		gamecon.LoadLevel(SceneIndice.TRANSITION);
	}
}

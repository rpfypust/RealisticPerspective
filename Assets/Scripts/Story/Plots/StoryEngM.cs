using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StoryEngM : Plot {
	
	public Transform[] targets;
	private List<Dialog> dialogs;
	private DialogManager dman;
	private CinematicCamera cam;
	
	private void Awake () {
		// initialize reference to dman
		dman = GetComponent<DialogManager>();
		cam = GameObject.FindGameObjectWithTag(Tags.mainCamera).GetComponent<CinematicCamera>();
		
		dialogs = new List<Dialog>();		
		
		dialogs.Add(new Dialog("Theta", "Stop!",3));
		dialogs.Add(new Dialog("Alpha", "Theta! How come you are here? It’s dangerous, go away!",3));
		dialogs.Add(new Dialog("Zeta", "Theta, don’t get close!"));
		dialogs.Add(new Dialog("Theta", "No! Alpha! Father!"));
		dialogs.Add(new Dialog("Theta", " Stop! Please!"));
		dialogs.Add(new Dialog("Alpha", " Father?",2));
		dialogs.Add(new Dialog("Theta", "Yes, I’m daughter of Dr. Zeta."));
		dialogs.Add(new Dialog("Theta", "For me sake, stop please, Alpha..."));
		dialogs.Add(new Dialog("Theta", "My father is not really a bad person. He did everything for me..."));
		dialogs.Add(new Dialog("Alpha", "Wait, what’s the story?",2));
		dialogs.Add(new Dialog("Zeta", "Theta, stop that!",3));
		dialogs.Add(new Dialog("Zeta", "I’ll definitely fulfill my promise this time, after I defeat this guy in the way..."));
		dialogs.Add(new Dialog("Zeta", "So just wait father some time..."));
		dialogs.Add(new Dialog("Theta", "Father, it’s enough already..."));
		dialogs.Add(new Dialog("Theta", "Forget the promise, it’s my willfulness..."));
		dialogs.Add(new Dialog("Zeta", " No, I’ll not give up!",3));
		dialogs.Add(new Dialog("Zeta", " I must prove the existences of “the Worlds” to the world!"));
		dialogs.Add(new Dialog("Theta", " It’s enough... It’s enough..."));
		dialogs.Add(new Dialog("Theta", "In fact I understand that, even the promise is fulfilled..."));
		dialogs.Add(new Dialog("Theta", "Even the promise is fulfilled... Mother..."));
		dialogs.Add(new Dialog("Zeta", "Stop it!",3));
		dialogs.Add(new Dialog("Theta", "Mother also won’t be back!"));
		dialogs.Add(new Dialog("Zeta", "Stop it!",3));
		dialogs.Add(new Dialog("Theta", "Because... Mother was dead already... BooHoo..."));
		dialogs.Add(new Dialog("Zeta", "Please...say no more..."));
		dialogs.Add(new Dialog("Alpha", "This..."));

		dialogs.Add(new Dialog("Delta", "Gamma, the real proposer of “the Worlds”."));
		dialogs.Add(new Dialog("Delta", "At the university, she met the genius Zeta."));
		dialogs.Add(new Dialog("Delta", "After graduation, they set up a research organization, “the Reality” and started to work on various research."));
		dialogs.Add(new Dialog("Delta", "At the same year, they got married and gave birth to a daughter, and named her Theta."));
		dialogs.Add(new Dialog("Delta", "But the morning sun never lasts a day. Right after “the Reality” started to focus its research on “the Worlds”, it lost its recognition of the academia."));
		dialogs.Add(new Dialog("Delta", "All academic organizations withdraw their sponsorship for “the Reality” successively."));
		dialogs.Add(new Dialog("Delta", "Opportunity seldom knocks twice but misery loves company."));
		dialogs.Add(new Dialog("Delta", "Gamma caught a chronic disease due to overwork at that time, and passed away the next year..."));

		dialogs.Add(new Dialog("Zeta", "Please stop it! It’s enough already..."));
		dialogs.Add(new Dialog("Zeta", "It’s all world’s fault! Gamma died because she received no proper treatment!"));
		dialogs.Add(new Dialog("Zeta", "If they hadn’t withdrawn their sponsorship... If people had believed us..."));
		
		dialogs.Add(new Dialog("Delta", "But Zeta hadn’t stopped his research. It’s because of a lie..."));

		dialogs.Add(new Dialog("Theta", "No...It’s not a lie..."));
		dialogs.Add(new Dialog("Theta", "It’s a promise that a father made to her daughter..."));
		dialogs.Add(new Dialog("Theta", "A promise that protects his daughter from the cruel fact..."));
		dialogs.Add(new Dialog("Theta", "I’m relying on father's promise..."));
		dialogs.Add(new Dialog("Theta", "Believing that once father proves mother’s ideas to the world, she will be back..."));
		dialogs.Add(new Dialog("Theta", "So that I can avoid a painful life of revenge..."));
		dialogs.Add(new Dialog("Theta", "So that I can meet you, so that I can..."));
		dialogs.Add(new Dialog("Theta", "But..."));
		dialogs.Add(new Dialog("Theta", "But... I’m really stupid..."));
		dialogs.Add(new Dialog("Theta", "I didn’t even notice my pain is not gone..."));
		dialogs.Add(new Dialog("Theta", "Father... Dad has always been bore my share of pain..."));
		dialogs.Add(new Dialog("Theta", "Dad has been no relief... Hoo..."));
		dialogs.Add(new Dialog("Theta", "So...Dad is okay now..."));
		dialogs.Add(new Dialog("Theta", "You don’t need to keep your promise anymore..."));
		dialogs.Add(new Dialog("Theta", "Turn back to the gentle father, okay...?"));
		
		dialogs.Add(new Dialog("Zeta", "Theta...You really grow up a lot without notice..."));
		dialogs.Add(new Dialog("Zeta", "You’re even stronger then father now..."));
		dialogs.Add(new Dialog("Zeta", "Sorry...Dad can’t keep my promise now..."));
		dialogs.Add(new Dialog("Zeta", "Can you forgive dad...?"));
		dialogs.Add(new Dialog("Theta", "Hoo... Of Course...! Hoo..."));
		dialogs.Add(new Dialog("Zeta", "Thank you..."));
		dialogs.Add(new Dialog("Zeta", "Okay. Theta give me some time, there’s one more thing I’ve to do."));

		dialogs.Add(new Dialog("Alpha", "One more thing?",2));
		dialogs.Add(new Dialog("Zeta", "Yes, I’d to expose another lie..."));
		dialogs.Add(new Dialog("Alpha", "Another lie?",2));
		dialogs.Add(new Dialog("Zeta", "Delta, could you do it yourself?",2));
		dialogs.Add(new Dialog("Delta", "..."));
		dialogs.Add(new Dialog("Zeta", "You couldn't... Let me do it for you then..."));
		dialogs.Add(new Dialog("Zeta", "Let me tell you a tragic story, Alpha..."));
		dialogs.Add(new Dialog("Zeta", "The story begins with a teenager who has been diagnosed to have a rare genetic disorder."));
		dialogs.Add(new Dialog("Zeta", "After the surgery, the teenager didn’t regain consciousness..."));
		dialogs.Add(new Dialog("Zeta", "Not able to accept the fact, the teenager’s friends, a girl approached “the Reality”..."));
		dialogs.Add(new Dialog("Zeta", "Through “the Reality”, the girl realized the existence of “the Inner World” and its underlying power..."));

		dialogs.Add(new Dialog("Delta", " Shut up!",3));
		dialogs.Add(new Dialog("Zeta", "No! I’ve to carry on, your time is running out..."));
		dialogs.Add(new Dialog("Zeta", "From then on, the girl kept telling a lie..."));
		dialogs.Add(new Dialog("Zeta", "He is not in coma... He is not in coma... He is not in coma..."));
		dialogs.Add(new Dialog("Zeta", "The girl kept “denying” this fact......"));
		dialogs.Add(new Dialog("Zeta", "Suddenly, likes angel heard the girl's wish."));
		dialogs.Add(new Dialog("Zeta", "The teenager woke up by the power of “the Inner World”..."));
		dialogs.Add(new Dialog("Zeta", "But, this is not a blessing from the angel..."));
		dialogs.Add(new Dialog("Zeta", "It's the devil's mischief......"));
		dialogs.Add(new Dialog("Zeta", "Because of using the power of “the Inner World” and breaking the order of “the Worlds”..."));
		dialogs.Add(new Dialog("Zeta", "The girl has been “denied” by “the Outer World”, and has been banished to “the Inner World”..."));
		dialogs.Add(new Dialog("Zeta", "In “the Inner World”, the girl will gradually be forgotten by others, and eventually vanish..."));
		dialogs.Add(new Dialog("Zeta", "Alpha, do you know the name of the teenager?",2));

		dialogs.Add(new Dialog("Alpha", "...That’s me..."));
		dialogs.Add(new Dialog("Zeta", "Then do you know the name of the girl?",2));
		dialogs.Add(new Dialog("Alpha", "Eh...It’s weird..."));
		dialogs.Add(new Dialog("Alpha", "I obviously should know...but I just can't think of it at the moment..."));
		dialogs.Add(new Dialog("Alpha", "The...The..."));
		dialogs.Add(new Dialog("Alpha", "Beta...She’s Beta..."));
		dialogs.Add(new Dialog("Zeta", "Yes...the girl is Beta."));
		dialogs.Add(new Dialog("Alpha", "Where is Beta? You must know that, let me see her!",2));
		dialogs.Add(new Dialog("Alpha", "I don’t want Beta to disappear!",3));
		dialogs.Add(new Dialog("Zeta", "It seems that the existence of Beta has started to fade away before you ever met Delta..."));
		dialogs.Add(new Dialog("Zeta", "At least when you met Delta, you already can’t recall Beta’s face already..."));
		dialogs.Add(new Dialog("Alpha", " It can’t be!",3));
		dialogs.Add(new Dialog("Alpha", " I can’t forget her face..."));
		dialogs.Add(new Dialog("Zeta", "In fact, Beta is just next to you all the time..."));
		dialogs.Add(new Dialog("Zeta", "Delta is the one you’re looking for..."));

		dialogs.Add(new Dialog("Beta", "Enough! Why do you tell him!",3));
		dialogs.Add(new Dialog("Beta", "I’m almost time to disappear..."));
		dialogs.Add(new Dialog("Beta", "After I've disappear, Alpha'll forget me and live on happily..."));
		dialogs.Add(new Dialog("Beta", "Why do you still need to make Alpha sad!."));
		dialogs.Add(new Dialog("Alpha", "Beta..."));
		dialogs.Add(new Dialog("Alpha", "No, Beta..."));
		dialogs.Add(new Dialog("Alpha", "Of course, I’m sad..."));
		dialogs.Add(new Dialog("Alpha", "That’s because you are going to disappear but I still can’t think of your face..."));
		dialogs.Add(new Dialog("Alpha", "I still can’t think of your smile..."));
		dialogs.Add(new Dialog("Alpha", "And I almost forget your name..."));
		dialogs.Add(new Dialog("Alpha", "Which shouldn’t be forgiven at all......"));
		dialogs.Add(new Dialog("Alpha", "But, If I just forget you without knowing this..."));
		dialogs.Add(new Dialog("Alpha", "I must be even more sadder than now..."));
		dialogs.Add(new Dialog("Beta", "Alpha..."));
		dialogs.Add(new Dialog("Beta", "Woo... Woo..."));
		dialogs.Add(new Dialog("Alpha", "Baka, don’t cry..."));
		dialogs.Add(new Dialog("Beta", "..."));
		dialogs.Add(new Dialog("Alpha", "Beta, do you still remember...?",2));
		dialogs.Add(new Dialog("Alpha", "Every time you get into trouble, who is going to save you at the end?",2));
		dialogs.Add(new Dialog("Beta", "You..."));
		dialogs.Add(new Dialog("Alpha", "Correct. Then why you don’t trust me this time."));
		dialogs.Add(new Dialog("Alpha", "I’m just sleeping..."));
		dialogs.Add(new Dialog("Alpha", "If you get into trouble again..."));
		dialogs.Add(new Dialog("Alpha", "I promise you, I’ll be at your side."));
		dialogs.Add(new Dialog("Beta", "Promise?"));
		dialogs.Add(new Dialog("Alpha", "Yes, I promise."));
		dialogs.Add(new Dialog("Alpha", "So you’ve to accept the fact..."));
		dialogs.Add(new Dialog("Beta", "No, I don't want t-..."));
		dialogs.Add(new Dialog("Alpha", "Beta, sometime the reality is cruel..."));
		dialogs.Add(new Dialog("Alpha", "Cruel enough that it forces you to just “deny” it..."));
		dialogs.Add(new Dialog("Alpha", "But if you just keep “denying”, nothing is going to be solved. We’ll just lose more at the end..."));
		dialogs.Add(new Dialog("Alpha", "A world that without you... I won’t be ever live happily..."));
		dialogs.Add(new Dialog("Alpha", "So you can’t “deny” the reality..."));
		dialogs.Add(new Dialog("Alpha", "We’ve to “accept” the reality, so everything we did won’t come to naught..."));
		dialogs.Add(new Dialog("Alpha", "We’re need to “accept” the reality, so that we can take a step to the future."));
		dialogs.Add(new Dialog("Alpha", "Therefore, “accept” the reality, please?"));
		dialogs.Add(new Dialog("Beta", " Woo... Woo..."));
		dialogs.Add(new Dialog("Beta", "You really will wake up...?",2));
		dialogs.Add(new Dialog("Alpha", "Yes, of course."));
		dialogs.Add(new Dialog("Beta", "Promise?"));
		dialogs.Add(new Dialog("Alpha", "Yes, I promise."));
		dialogs.Add(new Dialog("Alpha", "Accept the reality then."));
		
		dialogs.Add(new Dialog("Beta", "I “accept” the fact that Alpha is still in coma..."));
		dialogs.Add(new Dialog("Beta", "But.....I “believe” that Alpha will wake up eventually!"));
		dialogs.Add(new Dialog("Beta", "I “believe” that Alpha'll be at my side everytime I got into trouble!"));
		dialogs.Add(new Dialog("Alpha", "Thank you..."));
		dialogs.Add(new Dialog("Alpha", "I need to take a nap now..."));
		dialogs.Add(new Dialog("Alpha", "Good night... Beta..."));
		dialogs.Add(new Dialog("Beta", "Good night... Alpha..."));
		dialogs.Add(new Dialog("Beta", "Woo woo... Woo woo..."));
		dialogs.Add(new Dialog("Beta", "Alpha...!"));

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

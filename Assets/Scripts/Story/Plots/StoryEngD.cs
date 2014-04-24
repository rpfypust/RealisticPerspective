using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StoryEngD : Plot {
	
	public Transform[] waypoints;
	private List<Dialog> dialogs;
	private DialogManager dman;
	private CinematicCamera cam;
	private HashIDs hash;
	private BGMManager bgm;
	private Actor alpha;
	private Actor shadow;
	private GameObject monster;
	private GameObject wave_0;
	private GameObject wave_1;
	private GameObject wave_2;

	private GameController gamecon;

	private void Awake () {
		// initialize reference to dman
		dman = GetComponent<DialogManager>();
		cam = GameObject.FindGameObjectWithTag(Tags.mainCamera).GetComponent<CinematicCamera>();
		bgm = GetComponentInChildren<BGMManager>();
		hash = GameObject.FindGameObjectWithTag(Tags.storyController).GetComponent<HashIDs>();
		alpha = GameObject.Find("Alpha").GetComponent<Actor>();
		shadow = GameObject.Find("Shadow").GetComponent<Actor>();
		monster = GameObject.Find("Monster");
		wave_0 = GameObject.Find("wave_0");
		wave_1 = GameObject.Find("wave_1");
		wave_2 = GameObject.Find("wave_2");
		monster.SetActive(false);
		wave_0.SetActive(false);
		wave_1.SetActive(false);
		wave_2.SetActive(false);

		gamecon = GameObject.FindGameObjectWithTag(Tags.gameController)
			.GetComponent<GameController>();

		dialogs = new List<Dialog>();		

		//Effect tgt, sound
		dialogs.Add(new Dialog("Alpha", "Awww..."));
		dialogs.Add(new Dialog("Alpha", "What happened?",3));
		//Effect tgt, sound
		dialogs.Add(new Dialog("Shadow", "Don't panic, this is \"the Inner World\"."));
		dialogs.Add(new Dialog("Alpha", "What's going on now? How come I am here?",2));
		dialogs.Add(new Dialog("Shadow", "Wait, don't you just say that you understand the situation after my explanation."));
		dialogs.Add(new Dialog("Alpha", "No way I can understand that. Isn't that just cosplay's dialogue?",2));
		dialogs.Add(new Dialog("Shadow", "Okay. We have just passed through a \"Tunnel\". And we need to defeat \"the Denied\" then we can rescue Beta."));
		dialogs.Add(new Dialog("Shadow", "Seem like we got company, lets talk later."));
		//monster show up camera motion
		dialogs.Add(new Dialog("Shadow", "\"The Denied\", our enemy. You should defeat them quickly or else you will get killed."));
		dialogs.Add(new Dialog("Alpha", "Enemy!",3));
		dialogs.Add(new Dialog("Shadow", "Don't stand still. Move!",3));
		dialogs.Add(new Dialog("Alpha", "Yes!",3));
		dialogs.Add(new Dialog("System", "Press UP, Down, Left, Right, Jump and Walk to dodge."));
		//Battle mode without attack, 5s then paused
		//battle camera mode
		//HUD turn on
		dialogs.Add(new Dialog("Shadow", "You can't beat them if you just keep dodge. Attack!"));
		dialogs.Add(new Dialog("Alpha", "Even you say so, I don't know how to attack anyway and I got no weapons too!"));
		dialogs.Add(new Dialog("Shadow", "No, you has the ability to defeat \"the Denied\"."));
		dialogs.Add(new Dialog("Shadow", "You only need to visualize and conjure the attack, probably."));
		dialogs.Add(new Dialog("Alpha", "Probably? Please be serious!",3));
		dialogs.Add(new Dialog("Shadow", "Just try hard to visualize the attack and conjure it!"));
		dialogs.Add(new Dialog("Alpha", "Visualize... Visualize... Attack... Attack...",1));
		dialogs.Add(new Dialog("System", "Press Attack to shot and Skill to open barrier."));
		//Battle mode without attack, 5s then paused
		//battle camera mode
		//HUD turn on
		dialogs.Add(new Dialog("Alpha", "Like that?"));
		dialogs.Add(new Dialog("Shadow", "Yeah, that's right. Keep going and defeat all of them!",3));
		dialogs.Add(new Dialog("Alpha", "Don't just watch, can you help?"));
		dialogs.Add(new Dialog("Shadow", "Sorry, I don't have the ability to defeat \"the Denied\". We can only count on you."));
		dialogs.Add(new Dialog("Shadow", "Well, they are just minions. You can defeat them with ease, you can do it!"));
		dialogs.Add(new Dialog("Alpha", "I don't think it's that easy for me……Sign."));
		//Battle mode without attack, 5s then paused
		//battle camera mode
		//HUD turn on
		dialogs.Add(new Dialog("System", "Please defeat all enemies."));
	}
	
	public void Start()
	{
		base.startStoryScene();
	}

	protected override IEnumerator sequencer()
	{	
		yield return StartCoroutine(cam.SolidBlack(1f));
		StartCoroutine(cam.FadeOut());
		dman.openDialog();

		StartCoroutine(alpha.tunnelOut());
		yield return new WaitForSeconds(.5f);
		yield return StartCoroutine(dman.display(dialogs[0],alpha.EmotionPt));
		yield return new WaitForSeconds(2.5f);
		yield return StartCoroutine(dman.interactToProceed());
		yield return StartCoroutine(dman.display(dialogs[1],alpha.EmotionPt));
		yield return StartCoroutine(dman.interactToProceed());
		yield return StartCoroutine(shadow.tunnelOut());
		StartCoroutine(shadow.faceTo(alpha.transform, 0.5f));
		yield return StartCoroutine(alpha.faceTo(shadow.transform, 0.5f));

		yield return StartCoroutine(cam.orbitMotion(waypoints[0],30,1));
		yield return StartCoroutine(cam.zoom(0.5f,1));

		for (int index = 2; index < 8; index++) {
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

		bgm.changeVolume(0.3f);
		bgm.PlayBGM(4);
		//spwan a slime and face and mvoe camera 
		monster.SetActive(true);
		StartCoroutine(shadow.rotate(35, 0.5f));
		yield return StartCoroutine(alpha.rotate(-100, 0.5f));
		yield return StartCoroutine(cam.orbitMotion(waypoints[0],-30,1));

		for (int index = 8; index < 13; index++) {
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

		dman.closeDialog();

		StartCoroutine(shadow.tunnelIn());
		monster.GetComponent<MonsterAI>().enabled = true;
		cam.GetComponent<StageCameraView>().enabled = true;
		alpha.GetComponent<CharControl>().enabled = true;
		alpha.GetComponent<Player>().enabled = true;
		yield return new WaitForSeconds(.1f);
		alpha.GetComponent<CharAnimation>().enabled = true;

		yield return new WaitForSeconds(5f);

		monster.GetComponent<MonsterAI>().enabled = false;
		monster.GetComponent<Slime>().enabled = false;
		monster.GetComponent<NavMeshAgent>().enabled = false;
		monster.GetComponent<Animator>().SetBool(hash.walkingBool, false);
		alpha.GetComponent<CharControl>().enabled = false;
		alpha.GetComponent<Player>().enabled = false;
		alpha.GetComponent<CharAnimation>().enabled = false;
		alpha.GetComponent<Animator>().SetBool(hash.walkingBool, false);
		alpha.GetComponent<Animator>().SetBool(hash.runningBool, false);

		yield return StartCoroutine(shadow.tunnelOut());
		StartCoroutine(alpha.faceTo(shadow.transform, 0.5f));
		yield return StartCoroutine(shadow.faceTo(alpha.transform, 0.5f));
		dman.openDialog();
		for (int index = 13; index < 21; index++) {
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
		dman.closeDialog();

		StartCoroutine(shadow.tunnelIn());
		monster.GetComponent<MonsterAI>().enabled = true;
		monster.GetComponent<Slime>().enabled = true;
		monster.GetComponent<NavMeshAgent>().enabled = true;
		monster.GetComponent<Animator>().SetBool(hash.walkingBool, true);
		alpha.GetComponent<CharControl>().enabled = true;
		alpha.GetComponent<Player>().enabled = true;
		alpha.GetComponent<CharAnimation>().enabled = true;
		alpha.GetComponent<Animator>().SetBool(hash.walkingBool, true);
		alpha.GetComponent<Animator>().SetBool(hash.runningBool, true);
		alpha.GetComponentInChildren<PlayerShooter>().enabled = true;
		alpha.GetComponentInChildren<PlayerBomb>().enabled = true;
		
		while(monster!=null)
		{
			yield return new WaitForSeconds(0.5f);
		}

		yield return new WaitForSeconds(1);
		alpha.GetComponent<CharControl>().enabled = false;
		alpha.GetComponent<Player>().enabled = false;
		alpha.GetComponent<CharAnimation>().enabled = false;
		alpha.GetComponent<Animator>().SetBool(hash.walkingBool, false);
		alpha.GetComponent<Animator>().SetBool(hash.runningBool, false);
		alpha.GetComponentInChildren<PlayerShooter>().enabled = false;
		alpha.GetComponentInChildren<PlayerBomb>().enabled = false;

		yield return StartCoroutine(shadow.tunnelOut());
		StartCoroutine(alpha.faceTo(shadow.transform, 0.5f));
		yield return StartCoroutine(shadow.faceTo(alpha.transform, 0.5f));
		dman.openDialog();
		for (int index = 21; index < 28; index++) {
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
		dman.closeDialog();

		StartCoroutine(shadow.tunnelIn());
		alpha.GetComponent<CharControl>().enabled = true;
		alpha.GetComponent<Player>().enabled = true;
		alpha.GetComponent<CharAnimation>().enabled = true;
		alpha.GetComponent<Animator>().SetBool(hash.walkingBool, true);
		alpha.GetComponent<Animator>().SetBool(hash.runningBool, true);
		alpha.GetComponentInChildren<PlayerShooter>().enabled = true;
		alpha.GetComponentInChildren<PlayerBomb>().enabled = true;

		wave_0.SetActive(true);
		yield return new WaitForSeconds(0.5f);
		while(GameObject.FindGameObjectWithTag(Tags.enemy) !=null )
		{
			yield return new WaitForSeconds(0.5f);
		}
		Destroy(wave_0);
		wave_1.SetActive(true);
		yield return new WaitForSeconds(0.5f);
		while(GameObject.FindGameObjectWithTag(Tags.enemy) !=null )
		{
			yield return new WaitForSeconds(0.5f);
		}
		Destroy(wave_1);
		wave_2.SetActive(true);
		yield return new WaitForSeconds(0.5f);
		while(GameObject.FindGameObjectWithTag(Tags.enemy) !=null )
		{
			yield return new WaitForSeconds(0.5f);
		}
		Destroy(wave_2);
//		yield return StartCoroutine(cam.FadeIn());
		
		gamecon.LoadLevel(SceneIndice.TRANSITION);
	}
}

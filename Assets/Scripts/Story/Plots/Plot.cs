using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Plot : MonoBehaviour
{

	protected GameController gamecon;
	protected DialogManager dman;
	protected List<Dialog> dialogs;
	protected CinematicCamera cam;
	protected SEManager sem;
	protected BGMManager bgm;

	protected virtual void Update()
	{
		if (Input.GetButtonDown("Interact")) {
			skip();
		}
	}

	public void startStoryScene()
	{
		StartCoroutine(sequencer());
	}

	protected abstract IEnumerator sequencer();

	protected void skip()
	{
		if(dman!=null)
			dman.closeDialog();
		if(bgm!=null)
			bgm.StopBGM();
		if(sem!=null)
			sem.PauseSE();
		StopAllCoroutines();
		gamecon.LoadLevel(SceneIndice.TRANSITION);
	}
	
}

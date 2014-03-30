using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class StoryA : Plot {

	private List<Dialog> dialogs;
	private DialogManager dman;

	private void Awake () {
		// initialize reference to dman
		dman = GetComponent<DialogManager>();

		dialogs = new List<Dialog>();
		dialogs.Add(new Dialog("Speaker", "I am the TexI am the TexI am the TexI am the TexI am the TexI am the TexI am the TexI am the TexI am the TexI am the TexI am the TexI am the TexI am the TexI am the Tex"));
		dialogs.Add(new Dialog("Speaker1", "I am the Text1"));
		dialogs.Add(new Dialog("Speaker2", "I am the Text2"));
		dialogs.Add(new Dialog("Speaker3", "I am the Text3"));
		dialogs.Add(new Dialog("Speaker4", "I am the Text4"));
	}

	public void Start()
	{
		base.startStoryScene();
	}

	protected override IEnumerator sequencer()
	{
		dman.openDialog();
		// automatically display dialogs
		foreach (Dialog d in dialogs) {
			yield return StartCoroutine(dman.display(d));
			yield return StartCoroutine(base.interactToProceed());
		}
		dman.closeDialog();
	}
}

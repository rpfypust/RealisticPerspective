using UnityEngine;
using System.Collections;

public class TestDialog : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Dialogue[] d = {new Dialogue("speaker", "I am speakerI am speakerI am speakerI am speakerI am speakerI am speakerI am speakerI am speakerI am speaker")};
		DialogueManager dm = transform.gameObject.GetComponent<DialogueManager>();
		dm.showDialogue(d);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

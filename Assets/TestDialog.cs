using UnityEngine;
using System.Collections;

public class TestDialog : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Dialog[] d = {new Dialog("speaker", "I am speakerI am speakerI am speakerI am speakerI am speakerI am speakerI am speakerI am speakerI am speaker")};
		DialogManager dm = transform.gameObject.GetComponent<DialogManager>();
		dm.showDialogue(d);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

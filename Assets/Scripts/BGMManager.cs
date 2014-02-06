using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class BGMManager : MonoBehaviour {

	/* reference to all BGMs used in game */
	public AudioClip[] bgms;

	public void PlayBGM(int index) {
		if (audio.isPlaying)
			audio.Stop();
		audio.clip = bgms[index];
		audio.Play();
	}
	
	public void StopBGM() {
		audio.Stop();
	}

	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}

	/*
	void OnGUI() {
		if (GUI.Button(new Rect(10, 10, 50, 50), "1")) {
			PlayBGM(0);
		} else if (GUI.Button(new Rect(70, 10, 50, 50), "2")) {
			PlayBGM(1);
		}
	}*/
}

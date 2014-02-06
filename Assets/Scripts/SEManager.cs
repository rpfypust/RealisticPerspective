using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class SEManager : MonoBehaviour {

	public AudioClip[] soundEffects;

	public void PlaySoundEffect(int index) {
		audio.PlayOneShot(soundEffects[index]);
	}

	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}
}

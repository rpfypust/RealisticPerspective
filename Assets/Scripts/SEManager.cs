using UnityEngine;
using System.Collections;

public class SEManager : MonoBehaviour {

	public AudioClip[] ses;
	private AudioSource[] sources;

	void Awake()
	{
		sources = new AudioSource[ses.Length];
		for (int i = 0; i < sources.Length; i++) {
			sources[i] = gameObject.AddComponent<AudioSource>();
			sources[i].clip = ses[i];
		}
	}

	public void PlaySoundEffect(int i)
	{
		sources[i].Play(); // Play starts playing regardless of isPlaying or not
	}
}

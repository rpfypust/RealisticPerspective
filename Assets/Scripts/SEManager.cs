/*StoryMode SE List
 * 0 click
 * 1 select
 * 2 vanish
 * 3 shake
 * 4 phone_virbrate
 * 5 ringbell
 */
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

    public void LoopSoundEffect(int i) // Only for long looping SE
    {
        sources[i].loop = true;
        sources[i].Play();
    }

    public void StopSoundEffect(int i) // Only for long looping SE
    {
        sources[i].Stop();
    }
}
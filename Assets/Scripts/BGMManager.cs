using UnityEngine;
using System.Collections;

public class BGMManager : MonoBehaviour {

	/* references to all BGMs */
	public AudioClip[] bgms;
	public Vector2[] pairs;

    private AudioSource source;

    private int gui;

	void Awake()
	{
		source = gameObject.AddComponent<AudioSource>();
        gui = 0;
	}

	public void LoopBGM(int index) {
		if (source.isPlaying)
			StopBGM();
		StartCoroutine(LoopCoroutine(index));
	}

	public void PlayBGM(int index) {
		if (source.isPlaying)
			StopBGM();
        source.time = 0f;
		source.clip = bgms[index];
		source.Play();
	}
	
	public void StopBGM() {
		StopAllCoroutines();
		source.Stop();
	}

	private IEnumerator LoopCoroutine(int index)
	{
        source.time = 0f;
		source.clip = bgms[index];
		source.Play();
		yield return new WaitForSeconds(pairs[index].y);
		while (true) {
			source.time = pairs[index].x;
			yield return new WaitForSeconds(pairs[index].y - pairs[index].x);
		}
	}

//	void OnGUI() {
//		if (GUI.Button(new Rect(10, 10, 50, 50), "1"))
//        {
//            LoopBGM(gui);
//            gui++;
//            gui %= bgms.Length;
//        }
//	}
	public void changeVolume(float volume) {
		source.volume = volume;
	}
}

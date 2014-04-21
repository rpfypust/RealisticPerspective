using UnityEngine;
using System.Collections;

public class BGMManager : MonoBehaviour {

	/* references to all BGMs */
	public AudioClip[] bgms;
	public Vector2[] pairs;

	public void PlayBGM(int index) {
		if (audio.isPlaying)
			StopBGM();
		StartCoroutine(LoopCoroutine(index));
	}
	
	public void StopBGM() {
		StopAllCoroutines();
		audio.Stop();
	}

	private IEnumerator LoopCoroutine(int index)
	{
		audio.clip = bgms[index];
		audio.Play();
		yield return new WaitForSeconds(pairs[index].y);
		while (true) {
			audio.time = pairs[index].x;
			yield return new WaitForSeconds(pairs[index].y - pairs[index].x);
		}
	}





//	void OnGUI() {
//		if (GUI.Button(new Rect(10, 10, 50, 50), "1"))
//			PlayBGM(0);
//		else if (GUI.Button(new Rect(10, 100, 50, 50), "2"))
//			PlayBGM(1);
//	}
}

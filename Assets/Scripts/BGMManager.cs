using UnityEngine;
using System.Collections;

public class BGMManager : MonoBehaviour {

	/* references to all BGMs */
	public AudioClip[] bgms;
    public Vector2[] pairs;
    public string[] songTitle;

    private AudioSource source;
	private bool paused;
    private int showTitleIndex;

//    private int gui;

	void Awake()
	{
		source = gameObject.AddComponent<AudioSource>();
		paused = false;
        showTitleIndex = -1;
//        gui = 0;
	}

	public void LoopBGM(int index) {
		if (source.isPlaying)
            StopBGM();
        StartCoroutine(LoopCoroutine(index));
        StartCoroutine(ShowGUI(index,6f));
	}

	public void PlayBGM(int index) {
		if (source.isPlaying)
			StopBGM();
        source.clip = bgms[index];
        source.time = 0f;
        source.Play();
        StartCoroutine(ShowGUI(index,6f));
	}

	public bool IsPlayingBGM()
	{
		return source.isPlaying;
	}

	public bool IsPaused()
	{
		return paused;
	}

	public void PauseBGM()
	{
		if (IsPlayingBGM()) {
			paused = true;
			source.Pause();
		}
	}

	public void ResumeBGM()
	{
		if (paused) {
			source.Play();
		}
	}
	
	public void StopBGM() {
		StopAllCoroutines();
		source.Stop();
	}

	private IEnumerator LoopCoroutine(int index)
	{
        source.clip = bgms[index];
        source.time = 0f;
        source.loop = true;
		source.Play();
        yield return new WaitForSeconds(pairs[index].y);
		while (true) {
			source.time = pairs[index].x;
            yield return new WaitForSeconds(pairs[index].y - pairs[index].x);
		}
	}

    private IEnumerator ShowGUI(int index, float showTime)
    {
        showTitleIndex = index;
        yield return new WaitForSeconds(showTime);
        showTitleIndex = -1;
    }

    void OnGUI() {
        if(showTitleIndex != -1){
            GUIStyle style = new GUIStyle();
            style.fontSize = 14;
            style.normal.textColor = Color.red;
            GUI.Label(new Rect(6f, 70f, 300f, 20f), ("BGM: " + songTitle[showTitleIndex]),style);
            style.normal.textColor = Color.white;
            GUI.Label(new Rect(4f, 68f, 300f, 20f), ("BGM: " + songTitle[showTitleIndex]),style);
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

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(StageCameraView))]
[RequireComponent(typeof(Letterbox))]
public class CutSceneManager : MonoBehaviour {

	public delegate void CutSceneEvent();
	public static event CutSceneEvent OnCutSceneStart;
	public static event CutSceneEvent OnCutSceneEnd;

	public const float SHORT_DELAY = 0.5f;

	public Transform target;

	private GUIManager gman;
    private StageCameraView camScript;
    private Letterbox letterbox;
	private Fader fader;

    void Awake() {
		gman = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<GUIManager>();
        camScript = GetComponent<StageCameraView>();
        letterbox = GetComponent<Letterbox>();
		fader = GetComponent<Fader>();
    }

	public void BeginCutScene() {
        // freeze any moving objects
		if (OnCutSceneStart != null)
			OnCutSceneStart();
        // disable camera script
        camScript.enabled = false;
        // enable letterbox
		gman.register(letterbox);
    }

    public IEnumerator moveCamera(Vector3 targetPosition, float duration) {
        Vector3 desiredPosition = camScript.getDesiredPosition(targetPosition);
		float startTime = Time.time;
        float speed = Vector3.Distance(transform.position, desiredPosition) / duration * Time.fixedDeltaTime;
        while (Time.time - startTime < duration) {
            transform.position = Vector3.MoveTowards(transform.position, desiredPosition, speed);
            yield return new WaitForFixedUpdate();
        }
    }

	public IEnumerator SolidBlack(float duration = 1f)
	{
		gman.register(fader);
		yield return StartCoroutine(fader.SolidBlack(duration));
		gman.unregister(fader);
	}

	public IEnumerator FadeIn(float duration = 1f)
	{
		gman.register(fader);
		yield return StartCoroutine(fader.Fade(0f, 1f, duration));
		gman.unregister(fader);
	}

	public IEnumerator FadeOut(float duration = 1f)
	{
		gman.register(fader);
		yield return StartCoroutine(fader.Fade(1f, 0f, duration));
		gman.unregister(fader);
	}

    public void EndCutScene() {
        // disable letterbox
		gman.unregister(letterbox);
        // enable camera script
        camScript.enabled = true;
        // un-freeze frozen objects
		if (OnCutSceneEnd != null)
			OnCutSceneEnd();
    }
}

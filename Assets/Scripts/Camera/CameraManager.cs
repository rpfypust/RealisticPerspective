using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {

    public Transform target;

    private StageCameraView camScript;
    private Letterbox letterbox;

    void Awake() {
        camScript = gameObject.GetComponent<StageCameraView>();
        letterbox = gameObject.GetComponent<Letterbox>();
    }

	public void BeginCutScene() {
        // freeze any moving objects
        // disable camera script
        camScript.enabled = false;
        // enable letterbox
        letterbox.enabled = true;
    }

    public IEnumerator MoveCamera(Vector3 targetPosition, float duration) {
        Vector3 desiredPosition = camScript.getDesiredPosition(targetPosition);
        int totalFrames = (int) (duration / Time.fixedDeltaTime);
        float speed = Vector3.Distance(transform.position, desiredPosition) / duration * Time.fixedDeltaTime;
        for (int i = 0; i < totalFrames; i++) {
            transform.position = Vector3.MoveTowards(transform.position, desiredPosition, speed);
            yield return new WaitForFixedUpdate();
        }
    }

    public void EndCutScene() {
        // disable letterbox
        letterbox.enabled = false;
        // enable camera script
        camScript.enabled = true;
        // un-freeze frozen objects
    }
}

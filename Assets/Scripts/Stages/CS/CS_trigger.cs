using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Animation))]
public class CS_trigger : MonoBehaviour {

    public int setToChange;
    public int doorToOpen;

    private CS_mechanics mechanicsManger;
    private CameraManager cameraManager;

    void Awake() {
        mechanicsManger = GameObject.Find("MechanicsManager").GetComponent<CS_mechanics>();
        cameraManager = GameObject.FindGameObjectWithTag(Tags.mainCamera).GetComponent<CameraManager>();
    }

    void OnTriggerEnter(Collider other) {
        StartCoroutine(HandleSwitchOn());
    }

    IEnumerator HandleSwitchOn() {
        // Enter CutScene
        cameraManager.BeginCutScene();
        
        yield return StartCoroutine(animation.WaitForFinished());
        
        // End CutScene
        cameraManager.EndCutScene();

        mechanicsManger.ChangeSetNumber(setToChange);
        StartCoroutine(mechanicsManger.OpenDoor(doorToOpen));
        collider.enabled = false;
    }
}

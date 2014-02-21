using UnityEngine;
using System.Collections;

public class CS_trigger : MonoBehaviour {

    public int setToChange;
    public int doorToOpen;

    private CS_mechanics mechanicsManger;

    void Awake() {
        mechanicsManger = transform.parent.GetComponent<CS_mechanics>();
    }

    void OnTriggerEnter(Collider other) {
        mechanicsManger.ChangeSetNumber(setToChange);
        mechanicsManger.OpenDoor(doorToOpen);
        collider.enabled = false;
    }
}

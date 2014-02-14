using UnityEngine;
using System.Collections;

public class CS_trigger : MonoBehaviour {

    public int setToChange;

    void OnTriggerEnter(Collider other) {
        transform.parent.GetComponent<CS_mechanics>().ChangeSetNumber(setToChange);
        collider.enabled = false;
    }
}

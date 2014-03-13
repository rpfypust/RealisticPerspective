using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Animation))]
public class CompSwitch : MonoBehaviour {

	public enum CompSwitchLabel {
		ONE,
		TWO,
		THREE
	};

	public delegate void CompSwitchEvent(CompSwitch cs, CompSwitchLabel cwl);
	public static event CompSwitchEvent OnCompSwitchPressed;

	public CompSwitchLabel label;
    private GameObject player;

    void Awake() {
        player = GameObject.FindGameObjectWithTag(Tags.player);
    }

    void OnTriggerEnter(Collider other) {
		if (other.gameObject == player &&
		    OnCompSwitchPressed != null) {
			OnCompSwitchPressed(this, label);
			collider.enabled = false; // prohibit this method from calling ever after
		}
	}
}

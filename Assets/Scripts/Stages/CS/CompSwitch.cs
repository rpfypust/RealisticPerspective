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
	private Layers layers;

    void Awake() {
		layers = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<Layers>();
    }

    void OnTriggerEnter(Collider other) {
		if (other.gameObject.layer == layers.player &&
		    OnCompSwitchPressed != null) {
			OnCompSwitchPressed(this, label);
			collider.enabled = false; // prohibit this method from calling ever after
		}
	}
}

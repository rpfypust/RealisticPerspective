using UnityEngine;
using System;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Animation))]
public class CompSwitch : MonoBehaviour {

	public enum CompSwitchLabel {
		ONE,
		TWO,
		THREE
	};

	public class CompSwitchEventArgs : EventArgs {
		public CompSwitchLabel label {get; private set;}
		public CompSwitchEventArgs(CompSwitchLabel l)
		{
			label = l;
		}
	}

	public static event EventHandler<CompSwitchEventArgs> OnCompSwitchPressed;

	public CompSwitchLabel label;
    private GameObject player;

    void Awake() {
        player = GameObject.FindGameObjectWithTag(Tags.player);
    }

    void OnTriggerEnter(Collider other) {
		if (other.gameObject == player &&
		    OnCompSwitchPressed != null) {
			OnCompSwitchPressed(this, new CompSwitchEventArgs(label));
			collider.enabled = false; // prohibit this method from calling ever after
		}
	}
}

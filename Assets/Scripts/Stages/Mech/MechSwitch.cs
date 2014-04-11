using UnityEngine;

public class MechSwitch : MonoBehaviour {
	public delegate void MechSwitchEventHandler();
	public event MechSwitchEventHandler OnSwitchOn;
	public event MechSwitchEventHandler OnSwitchOff;

	private bool isOn;

	void Awake()
	{
		isOn = false;
	}

	void OnTriggerStay(Collider col)
	{
		if (!isOn
		    && col.tag == Tags.mechBlock
		    && OnSwitchOn != null) {
			MechBlock b = col.GetComponent<MechBlock>();
			if (!b.IsMoving) {
				isOn = true;
				OnSwitchOn();
			}
		}
	}

	void OnTriggerExit(Collider col)
	{
		if (isOn && col.tag == Tags.mechBlock && OnSwitchOff != null) {
			isOn = false;
			OnSwitchOff();
		}
	}
}

using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Animation))]
public class ElecSwitch : MonoBehaviour {

	public enum ElecSwitchColor {
		RED,
		BLUE,
		BLACK
	};

	public delegate void ElecSwitchEvent(ElecSwitch es, ElecSwitchColor esc);
	public static event ElecSwitchEvent OnElecSwitchPressed;

	public ElecSwitchColor color;
	private SphereCollider col;
	private Layers layers;

	void Awake() {
		layers = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<Layers>();
		col = GetComponent<SphereCollider>();
	}

	public void TurnOff()
	{
		col.enabled = false;
	}

	public void TurnOn()
	{
		col.enabled = true;
	}

	void OnTriggerStay(Collider other)
	{
		if (other.gameObject.layer == layers.player
		    && Input.GetButton("Fire1")
		    && OnElecSwitchPressed != null) {
			OnElecSwitchPressed(this, color);
		}
	}
}

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
	private SphereCollider triggerCol;
	private Layers layers;

	void Awake() {
		layers = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<Layers>();
		triggerCol = GetComponent<SphereCollider>();
	}

	public IEnumerator Press()
	{
		AnimationState state = animation["Press"];
		state.speed = 1f;
		state.normalizedTime = 0f;
		yield return StartCoroutine(animation.WaitForFinished());
	}

	public IEnumerator Recover()
	{
		AnimationState state = animation["Press"];
		state.normalizedTime = 1f;
		state.speed = -1f;
		yield return StartCoroutine(animation.WaitForFinished());
	}

	public void TurnOff()
	{
		triggerCol.enabled = false;
	}
	
	public void TurnOn()
	{
		triggerCol.enabled = true;
	}

	void OnTriggerStay(Collider other)
	{
		if (other.gameObject.layer == layers.player
		    && Input.GetButtonUp("Interact")
		    && OnElecSwitchPressed != null) {
			OnElecSwitchPressed(this, color);
		}
	}
}

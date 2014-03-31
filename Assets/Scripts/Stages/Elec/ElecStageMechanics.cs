using UnityEngine;
using System.Collections;
using ElecSwitchColor = ElecSwitch.ElecSwitchColor;

public class ElecStageMechanics : MonoBehaviour {

	public GameObject[] blackDoors;
	public GameObject[] redDoors;
	public GameObject[] blueDoors;

	private CameraManager cman;

	void Awake()
	{
		cman = GameObject.FindGameObjectWithTag(Tags.mainCamera).GetComponent<CameraManager>();
	}

	void OnEnable()
	{
		ElecSwitch.OnElecSwitchPressed += SwitchHandler;
	}

	void OnDisable()
	{
		ElecSwitch.OnElecSwitchPressed -= SwitchHandler;
	}

	private void SwitchHandler(ElecSwitch elecSwitch, ElecSwitchColor color)
	{
		StartCoroutine(SwitchHandlerCoroutine(elecSwitch, color));
	}

	private IEnumerator SwitchHandlerCoroutine(ElecSwitch elecSwitch, ElecSwitchColor color)
	{
		elecSwitch.TurnOff();
		cman.BeginCutScene();
		yield return StartCoroutine(elecSwitch.animation.WaitForFinished());
		// the switch stays pressed after the first press
		// perhaps needs some way to revert to unpressed after the cutscene
		Debug.Log(color);
		yield return new WaitForSeconds(1f);
		cman.EndCutScene();
		elecSwitch.TurnOn();
	}
}

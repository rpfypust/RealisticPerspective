using UnityEngine;
using System.Collections;
using ElecSwitchColor = ElecSwitch.ElecSwitchColor;

public class ElecStageMechanics : MonoBehaviour {

	public GameObject blackDoorsParent;
	public GameObject redDoorsParent;
	public GameObject blueDoorsParent;

	private ElecDoor[] blackDoors;
	private ElecDoor[] redDoors;
	private ElecDoor[] blueDoors;

	private bool blackDoorsOpen;
	private bool redDoorsOpen;
	private bool blueDoorsOpen;

	private CutSceneManager cman;

	void Awake()
	{
		cman = GameObject.FindGameObjectWithTag(Tags.mainCamera).GetComponent<CutSceneManager>();

		blackDoors = blackDoorsParent.GetComponentsInChildren<ElecDoor>();
		blueDoors = blueDoorsParent.GetComponentsInChildren<ElecDoor>();
		redDoors = redDoorsParent.GetComponentsInChildren<ElecDoor>();

		blackDoorsOpen = false;
		redDoorsOpen = false;
		blueDoorsOpen = false;
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

		if ((ElecSwitchColor.RED == color && redDoorsOpen)
		    || (ElecSwitchColor.BLACK == color && blackDoorsOpen)
		    || (ElecSwitchColor.BLUE == color && blueDoorsOpen))
			goto EXIT_LABEL;

		cman.BeginCutScene();

		yield return StartCoroutine(elecSwitch.Press());

		switch (color) {
		case ElecSwitchColor.BLACK:
			toggleDoor(blackDoors, blackDoorsOpen = true);
			toggleDoor(blueDoors, blueDoorsOpen = false);
			toggleDoor(redDoors, redDoorsOpen = false);
			break;
		case ElecSwitchColor.BLUE:
			toggleDoor(blackDoors, blackDoorsOpen = false);
			toggleDoor(blueDoors, blueDoorsOpen = true);
			toggleDoor(redDoors, redDoorsOpen = false);
			break;
		case ElecSwitchColor.RED:
			toggleDoor(blackDoors, blackDoorsOpen = false);
			toggleDoor(blueDoors, blueDoorsOpen = false);
			toggleDoor(redDoors, redDoorsOpen = true);
			break;
		}

		yield return StartCoroutine(elecSwitch.Recover());

		cman.EndCutScene();
	EXIT_LABEL:
		elecSwitch.TurnOn();
	}

	private void toggleDoor(ElecDoor[] doors, bool open)
	{
		foreach (ElecDoor door in doors) {
			door.Toggle(open);
		}
	}
}

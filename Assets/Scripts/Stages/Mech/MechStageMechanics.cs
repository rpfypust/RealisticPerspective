using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MechStageMechanics : MonoBehaviour {

//	private List<List<Vector2>> blockPositions;

	private CameraManager cman;
	public GameObject door;
	private MechSwitch[] switches;

	private int unlocked;

	void Awake()
	{
		cman = GameObject.FindGameObjectWithTag(Tags.mainCamera).GetComponent<CameraManager>();
		switches = GetComponentsInChildren<MechSwitch>();
		unlocked = 0;

//		blockPositions = new List<List<Vector2>> {
//			new List<Vector2> {
//				new Vector2(-3f, -17f),
//				new Vector2(3f, -17f),
//				new Vector2(3f, 11f)
//			},
//			new List<Vector2> {
//				new Vector2(4f, 39f),
//				new Vector2(-4f, 39f),
//				new Vector2(4f, 31f)
//			},
//			new List<Vector2> {
//				new Vector2(-4f, 53f),
//				new Vector2(4f, 53f),
//				new Vector2(4f, 63f)
//			}
//		};
	}

	void OnEnable()
	{
		foreach(MechSwitch s in switches) {
			s.OnSwitchOn += handleSwitchOn;
			s.OnSwitchOff += handleSwitchOff;
		}
	}

	void OnDisable()
	{
		foreach(MechSwitch s in switches) {
			s.OnSwitchOn -= handleSwitchOn;
			s.OnSwitchOff -= handleSwitchOff;
		}
	}

	private void handleSwitchOn()
	{
		if (switches.Length == ++unlocked)
			StartCoroutine(handleDoorOpenCoroutine());
	}

	private void handleSwitchOff()
	{
		unlocked--;
	}

	private IEnumerator handleDoorOpenCoroutine()
	{
		cman.BeginCutScene();
		Vector3 targetBackup = cman.target.position;
		yield return new WaitForSeconds(0.5f);
		yield return StartCoroutine(cman.moveCamera(door.transform.position, 1.0f));
		yield return new WaitForSeconds(0.5f);
		Destroy(door);
		yield return new WaitForSeconds(0.5f);
		yield return StartCoroutine(cman.moveCamera(targetBackup, 1.0f));
		yield return new WaitForSeconds(0.5f);
		cman.EndCutScene();
	}
}

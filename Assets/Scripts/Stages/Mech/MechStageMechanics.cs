using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MechStageMechanics : MonoBehaviour {

	private List<List<Vector2>> blockPositions;

	private CutSceneManager cman;
	public GameObject door;
	public GameObject block;
	public int setNum;
	private MechSwitch[] switches;
	private List<Object> blocks;

	private int unlocked;

	void Awake()
	{
		cman = GameObject.FindGameObjectWithTag(Tags.mainCamera).GetComponent<CutSceneManager>();
		switches = GetComponentsInChildren<MechSwitch>();
		blocks = new List<Object>();
		unlocked = 0;

		blockPositions = new List<List<Vector2>> {
			new List<Vector2> {
				new Vector2(-3f, 17f),
				new Vector2(3f, 17f),
				new Vector2(3f, 11f)
			},
			new List<Vector2> {
				new Vector2(4f, 39f),
				new Vector2(-4f, 39f),
				new Vector2(4f, 31f)
			},
			new List<Vector2> {
				new Vector2(-4f, 53f),
				new Vector2(4f, 53f),
				new Vector2(4f, 63f)
			}
		};
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == Tags.player &&
		    unlocked != switches.Length) {
			placeBlocks();
		}
	}

	private void placeBlocks()
	{
		foreach (Object b in blocks)
			Destroy(b);
		foreach (Vector2 v in blockPositions[setNum])
			blocks.Add(Instantiate(block, v.toVector3XZ(), Quaternion.identity));
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
		if (switches.Length == ++unlocked) {
			// unregister listener once the door is unlocked
			this.enabled = false;
			StartCoroutine(handleDoorOpenCoroutine());
		}
	}

	private void handleSwitchOff()
	{
		unlocked--;
	}

	private IEnumerator handleDoorOpenCoroutine()
	{
		cman.BeginCutScene();
		Vector3 targetBackup = cman.target.position;
		yield return new WaitForSeconds(CutSceneManager.SHORT_DELAY);
		yield return StartCoroutine(cman.moveCamera(door.transform.position,
		                                            CutSceneManager.SHORT_DELAY));
		yield return new WaitForSeconds(CutSceneManager.SHORT_DELAY);
		Destroy(door);
		yield return new WaitForSeconds(CutSceneManager.SHORT_DELAY);
		yield return StartCoroutine(cman.moveCamera(targetBackup,
		                                            CutSceneManager.SHORT_DELAY));
		yield return new WaitForSeconds(CutSceneManager.SHORT_DELAY);
		cman.EndCutScene();
	}
}

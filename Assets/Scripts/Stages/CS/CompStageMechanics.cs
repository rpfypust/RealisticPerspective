using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using CompSwitchLabel = CompSwitch.CompSwitchLabel;

public class CompStageMechanics : MonoBehaviour {

	private readonly Vector2 iceRinkOrigin = new Vector2(-17f, 6f);
	private readonly Vector2 iceRinkCenter = new Vector2(-7f, 14f);
	private readonly Vector2 offset = new Vector2(1f, 1f);
	private const float unitLength = 2f;

    public GameObject[] doors;

	private CameraManager cman;
	private Object obstaclePrefab;

	public int currentSetNumber;
	private List<List<Vector2>> sets;
	private List<Object> obstacles;

    void Awake() {
		obstaclePrefab = Resources.Load("comp_block");
        cman = GameObject.FindGameObjectWithTag(Tags.mainCamera).GetComponent<CameraManager>();

		currentSetNumber = 0;

		obstacles = new List<Object>();

		sets = new List<List<Vector2>>();

		List<Vector2> set1 = new List<Vector2>();
		set1.Add(new Vector2(2, 0));
		set1.Add(new Vector2(7, 0));
		set1.Add(new Vector2(6, 1));
		set1.Add(new Vector2(1, 3));
		set1.Add(new Vector2(5, 3));
		set1.Add(new Vector2(2, 5));
		set1.Add(new Vector2(0, 6));
		set1.Add(new Vector2(6, 6));
		set1.Add(new Vector2(3, 7));
		sets.Add(set1);

		List<Vector2> set2 = new List<Vector2>();
		set2.Add(new Vector2(1, 0));
		set2.Add(new Vector2(7, 1));
		set2.Add(new Vector2(9, 2));
		set2.Add(new Vector2(2, 3));
		set2.Add(new Vector2(4, 4));
		set2.Add(new Vector2(6, 4));
		set2.Add(new Vector2(1, 5));
		set2.Add(new Vector2(7, 6));
		set2.Add(new Vector2(0, 7));
		sets.Add(set2);

		List<Vector2> set3 = new List<Vector2>();
		set3.Add(new Vector2(4, 0));
		set3.Add(new Vector2(0, 1));
		set3.Add(new Vector2(9, 4));
		set3.Add(new Vector2(3, 5));
		set3.Add(new Vector2(6, 6));
		set3.Add(new Vector2(1, 7));
		sets.Add(set3);

		List<Vector2> set4 = new List<Vector2>();
		set4.Add(new Vector2(4, 0));
		set4.Add(new Vector2(9, 0));
		set4.Add(new Vector2(8, 2));
		set4.Add(new Vector2(9, 3));
		set4.Add(new Vector2(0, 4));
		set4.Add(new Vector2(2, 5));
		set4.Add(new Vector2(4, 6));
		set4.Add(new Vector2(3, 7));
		set4.Add(new Vector2(8, 7));
		sets.Add(set4);

		InitializeObstacles();
    }

	void OnEnable()
	{
		CompSwitch.OnCompSwitchPressed += SwitchHandler;
	}

	void OnDisable()
	{
		CompSwitch.OnCompSwitchPressed -= SwitchHandler;
	}

	private Object putObstacle(Vector2 v2)
	{
		Vector3 v3 = new Vector3();
		v3.y = 0f;
		v3.x = iceRinkOrigin.x + offset.x + v2.x * unitLength;
		v3.z = iceRinkOrigin.y + offset.y + v2.y * unitLength;
		return Instantiate(obstaclePrefab, v3, Quaternion.identity);
	}

	private void clearObstacles()
	{
		if (obstacles.Count > 0) {
			foreach (Object o in obstacles)
				Destroy(o);
			obstacles.Clear();
		}
	}

    private void InitializeObstacles()
    {
		clearObstacles();
		foreach (Vector2 v in sets[currentSetNumber])
			obstacles.Add(putObstacle(v));
    }

//    public IEnumerator OpenDoor(int n) {
//        cman.BeginCutScene();
//        Vector3 targetBackup = cman.target.position;
//        // move camera to the door being opened
//        yield return StartCoroutine(cman.MoveCamera(doors[n - 1].transform.position, 1.0f));
//        Destroy(doors[n - 1]);
//        yield return new WaitForSeconds(1.0f);
//        // move camera back to original target
//        yield return StartCoroutine(cman.MoveCamera(targetBackup, 1.0f));
//        cman.EndCutScene();
//    }

	private void SwitchHandler(CompSwitch cs, CompSwitchLabel cwl)
	{
		StartCoroutine(SwitchHandlerCoroutine(cs, cwl));
	}

	private IEnumerator SwitchHandlerCoroutine(CompSwitch compSwitch, CompSwitchLabel label)
	{
		cman.BeginCutScene();
		yield return StartCoroutine(compSwitch.animation.WaitForFinished());
		Vector3 targetBackup = cman.target.position;

		GameObject door = null;
		switch (label) {
		case CompSwitchLabel.ONE:
			door = doors[0];
			break;
		case CompSwitchLabel.TWO:
			door = doors[1];
			break;
		case CompSwitchLabel.THREE:
			door = doors[2];
			break;
		}
		currentSetNumber++;

		yield return StartCoroutine(cman.moveCamera(door
		                                            .transform
		                                            .position
		                                            .toVector2XZ()
		                                            .toVector3XZ()
		                                            , 1.0f));
		Destroy(door);
		yield return new WaitForSeconds(1.0f);

		yield return StartCoroutine(cman.moveCamera(iceRinkCenter.toVector3XZ(), 1.0f));
		InitializeObstacles();
		yield return new WaitForSeconds(1.0f);
		
		yield return StartCoroutine(cman.moveCamera(targetBackup, 1.0f));
		cman.EndCutScene();
	}
}

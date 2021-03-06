using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MechStageMechanics : MonoBehaviour {

	private List<List<Vector2>> blockPositions;

	public Transform playerStartPoint;

	private CutSceneManager cman;
	private BGMManager bgm;
	private SEManager sem;
	public GameObject door;
	public GameObject block;
	public int setNum;
	private MechSwitch[] switches;
	private MechBlock[] blocks;
	private MonsterSpawning spawner;

	private MechGrid grid;
	public Vector2 gridOrigin;
	public int gridWidth;
	public int gridHeight;
	private const float unitLength = 2f;
	private readonly Vector2 offset = new Vector2(-1f, -1f);

	private int unlocked;
	private bool puzzleActivated;

	void Awake()
	{
		cman = GameObject.FindGameObjectWithTag(Tags.mainCamera).GetComponent<CutSceneManager>();
		bgm = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<BGMManager>();
		sem = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<SEManager>();

		switches = GetComponentsInChildren<MechSwitch>();
		blocks = GetComponentsInChildren<MechBlock>();
		spawner = GetComponentInChildren<MonsterSpawning>();

		unlocked = 0;
		puzzleActivated = false;


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

	void Start()
	{
		togglePuzzle(false);
		spawner.OnMonsterClear += monsterClearHandler;
		bgm.LoopBGM(3);
	}

	private void monsterClearHandler()
	{
		StartCoroutine(puzzleActivation());
	}

	private IEnumerator puzzleActivation()
	{
		cman.BeginCutScene();

		yield return StartCoroutine(cman.FadeIn());

		togglePuzzle(true);
		// set player to start point so that he will never intercept with blocks
		GameObject o = GameObject.FindGameObjectWithTag(Tags.player).transform.parent.gameObject;
		o.transform.position = playerStartPoint.position;
		o.transform.rotation = Quaternion.identity;

		StartCoroutine(cman.moveCamera(o.transform.position, 1f));
		StartCoroutine(initializeGrid());
		yield return StartCoroutine(cman.SolidBlack());
		yield return StartCoroutine(cman.FadeOut());

		cman.EndCutScene();
		puzzleActivated = true;
	}

	private void togglePuzzle(bool b)
	{
		for (int i = 0; i < blocks.Length; i++)
			blocks[i].gameObject.SetActive(b);
		for (int i = 0; i < switches.Length; i++)
			switches[i].gameObject.SetActive(b);
	}

	private IEnumerator initializeGrid()
	{
		grid = new MechGrid(gridWidth, gridHeight);
		for (int i = 0; i < blocks.Length; i++) {
			// set blocks to initial positions
			Vector3 startPos = blocks[i].transform.position;
			Vector3 endPos = blockPositions[setNum][i].toVector3XZ();
			if (startPos != endPos)
				yield return StartCoroutine(blocks[i].MoveWithinTime(endPos, 0.2f));
//			blocks[i].transform.position = blockPositions[setNum][i].toVector3XZ();
			// convert world position to grid indices
			Vector2 p = fromWorldToGrid(blocks[i].transform.position.toVector2XZ());
			int row = (int) p.x;
			int col = (int) p.y;
			grid.placeBlock(row, col);
		}
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == Tags.player
		    && puzzleActivated
		    && unlocked != switches.Length) {
			StartCoroutine(initializeGrid());
		}
	}

	private Vector2 fromWorldToGrid(Vector2 p)
	{
		p = p - gridOrigin;
		p = p + offset;
		p = p / unitLength;
		return p;
	}

	private Vector2 fromGridtoWorld(Vector2 p)
	{
		p = p * unitLength;
		p = p - offset;
		p = p + gridOrigin;
		return p;
	}

	public Vector3 queryNewPosition(Vector3 p3, MechBlock.Direction d)
	{
		Vector2 p2 = fromWorldToGrid(p3.toVector2XZ());
		int row = (int) p2.x;
		int col = (int) p2.y;
		switch (d) {
		case MechBlock.Direction.EAST:
			p2 = grid.moveBlock(row, col, MechGrid.Direction.DOWN);
			break;
		case MechBlock.Direction.NORTH:
			p2 = grid.moveBlock(row, col, MechGrid.Direction.RIGHT);
			break;
		case MechBlock.Direction.SOUTH:
			p2 = grid.moveBlock(row, col, MechGrid.Direction.LEFT);
			break;
		case MechBlock.Direction.WEST:
			p2 = grid.moveBlock(row, col, MechGrid.Direction.UP);
			break;
		}
		p2 = fromGridtoWorld(p2);
		return p2.toVector3XZ();
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
		sem.PlaySoundEffect(11);
		Destroy(door);
		yield return new WaitForSeconds(CutSceneManager.SHORT_DELAY);
		yield return StartCoroutine(cman.moveCamera(targetBackup,
		                                            CutSceneManager.SHORT_DELAY));
		yield return new WaitForSeconds(CutSceneManager.SHORT_DELAY);
		cman.EndCutScene();
	}
}

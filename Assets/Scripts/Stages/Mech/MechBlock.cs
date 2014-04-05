using UnityEngine;
using System.Collections;

public class MechBlock : MonoBehaviour {

	public enum Direction {
		NOT_APPLICABLE,
		NORTH,
		WEST,
		SOUTH,
		EAST
	}

	private CutSceneManager cman;
	private MechStageMechanics mechanics;
	private const float speed = 5f;
	public bool IsMoving {get; private set;}

	void Awake()
	{
		cman = GameObject.FindGameObjectWithTag(Tags.mainCamera).GetComponent<CutSceneManager>();
		mechanics = transform.parent.GetComponent<MechStageMechanics>();
		IsMoving = false;
	}

	void OnTriggerStay(Collider col)
	{
		if (col.tag == Tags.player
		    && Input.GetButtonUp("Interact")
		    && !IsMoving) {
			Direction dir = inferDirection(col.transform);
			if (Direction.NOT_APPLICABLE != dir) {
				Vector3 p = mechanics.queryNewPosition(transform.position, dir);
				if (p != transform.position)
					StartCoroutine(moveCoroutine(p));
			}
		}
	}

	private Direction inferDirection(Transform t)
	{
		Vector2 p = transform.position.toVector2XZ() - t.position.toVector2XZ();
		Vector2 dir = t.forward.toVector2XZ();

		if (Vector2.Angle(p, dir) > 30f)
			return Direction.NOT_APPLICABLE;

		float x = dir.x;
		float y = dir.y;
		float absX = Mathf.Abs(x);
		float absY = Mathf.Abs(y);

		if (absX > absY) {
			if (x > 0)
				return Direction.EAST;
			else
				return Direction.WEST;
		} else if (absY > absX) {
			if (y > 0)
				return Direction.NORTH;
			else
				return Direction.SOUTH;
		}

		return Direction.NOT_APPLICABLE;
	}

	private IEnumerator moveCoroutine(Vector3 dest)
	{
		IsMoving = true;
		cman.BeginCutScene();
		yield return StartCoroutine(transform.LinearMoveWithSpeed(transform.position, dest, speed));
		cman.EndCutScene();
		IsMoving = false;
	}
}

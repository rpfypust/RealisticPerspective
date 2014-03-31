using UnityEngine;

public class MechBlock : MonoBehaviour {

	private enum Direction {
		NOT_APPLICABLE,
		NORTH,
		WEST,
		SOUTH,
		EAST
	}

	private const float threshold = 1f;
	private const float speed = 5f;
	private const RigidbodyConstraints mask = ~(RigidbodyConstraints.FreezePositionX
	                                            | RigidbodyConstraints.FreezePositionZ);

	private CutSceneManager cman;

	private float timer;
	private Direction previousDir;

	void Awake()
	{
		cman = GameObject.FindGameObjectWithTag(Tags.mainCamera).GetComponent<CutSceneManager>();

		timer = 0f;
		previousDir = Direction.NOT_APPLICABLE;
	}

	void OnCollisionEnter(Collision col)
	{
		rigidbody.constraints = RigidbodyConstraints.FreezeAll;
		Vector3 p = transform.position;
		p.x = Mathf.Round(p.x);
		p.y = Mathf.Round(p.y);
		p.z = Mathf.Round(p.z);
		transform.position = p;

		cman.EndCutScene();
	}

	void OnTriggerStay(Collider col)
	{
		if (col.tag == Tags.player)
			slide(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
	}

	private Direction inferDirection(float h, float v)
	{
		if (h == 0 && v == 1f)
			return Direction.NORTH;
		if (h == 0 && v == -1f)
			return Direction.SOUTH;
		if (h == 1f && v == 0f)
			return Direction.EAST;
		if (h == -1f && v == 0f)
			return Direction.WEST;
		return Direction.NOT_APPLICABLE;
	}

	private Vector3 makeVelocity(Direction dir)
	{
		Vector3 retval = Vector3.zero;
		switch (dir) {
		case Direction.NORTH:
			retval = Vector3.forward;
			break;
		case Direction.SOUTH:
			retval = Vector3.back;
			break;
		case Direction.WEST:
			retval = Vector3.left;
			break;
		case Direction.EAST:
			retval = Vector3.right;
			break;
		}
		retval *= speed;
		return retval;
	}

	private void move(Direction dir)
	{
		cman.BeginCutScene();

		rigidbody.constraints &= mask;
		rigidbody.velocity = makeVelocity(dir);
	}

	private void slide(float h, float v)
	{
		Direction dir = inferDirection(h, v);

		if (timer > threshold) {
			move(dir);
			timer = 0f;
		} else if (Direction.NOT_APPLICABLE != previousDir && dir == previousDir)
			timer += Time.deltaTime;
		else
			timer = 0f;
		previousDir = dir;
	}
}

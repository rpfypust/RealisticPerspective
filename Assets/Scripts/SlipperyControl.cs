using UnityEngine;
using System.Collections;

public class SlipperyControl : MonoBehaviour
{
	
	public float slipperySpeed = 20.0f;
	public float turnSpeed = 10.0f;
	private Vector3 moveDirection;
	private CharacterController controller;
	
	void Awake ()
	{
		controller = transform.gameObject.GetComponent<CharacterController> ();
	}
	
	void Start ()
	{
		moveDirection = Vector3.zero;
	}
	
	void Update ()
	{
		if (moveDirection == Vector3.zero) {
			float x, z;
			x = Input.GetAxis ("Horizontal");
			z = Input.GetAxis ("Vertical");
			if (Mathf.Abs (x) > Mathf.Abs (z))
				moveDirection = new Vector3 (x, 0.0f, 0.0f);
			else
				moveDirection = new Vector3 (0.0f, 0.0f, z);
		}
		
		// Rotate to face forward
		if (moveDirection != Vector3.zero)
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (new Vector3 (moveDirection.x, 0.0f, moveDirection.z)), turnSpeed * Time.deltaTime);
		
		// This is necessary because it makes controller grounded
		controller.Move (moveDirection * slipperySpeed * Time.deltaTime);
	}
	
	void OnControllerColliderHit(ControllerColliderHit hit) {
		moveDirection = Vector3.zero;
	}
}

using UnityEngine;
using System.Collections;

public class CharControl : MonoBehaviour
{
	
	public float slowSpeed = 3.0f;
	public float walkSpeed = 5.0f;
	public float runSpeed = 10.0f;
	public float jumpSpeed = 8.0f;
	public float turnSpeed = 10.0f;
	public float gravity = 20.0f;
	private Vector3 moveDirection;
	private CharacterController controller;
	
	void Awake()
	{
		controller = transform.gameObject.GetComponent<CharacterController>();
	}
	
	void Start()
	{
		moveDirection = Vector3.zero;
	}
	
	void Update()
	{
		// Direction on the 2D surface
		Vector2 direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		
		// Rotate to face forward
		if (direction != Vector2.zero)
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(direction.x, 0.0f, direction.y)), turnSpeed * Time.deltaTime);
		
		if (controller.isGrounded) {
			moveDirection = new Vector3(direction.x, 0.0f, direction.y);
			moveDirection *= (Input.GetButton("Slow")) ? slowSpeed : walkSpeed;
			if (Input.GetButton("Jump")) {
				moveDirection.y = jumpSpeed;
			}
		}
		
		// This is necessary because it makes controller grounded
		moveDirection.y -= (gravity * Time.deltaTime);
		controller.Move(moveDirection * Time.deltaTime);
	}
}

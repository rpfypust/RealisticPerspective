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
	private float moveSpeed;
	private CharacterController controller;
	
	void Awake()
	{
		controller = transform.gameObject.GetComponent<CharacterController>();
	}
	
	void Start()
	{
		moveDirection = Vector3.zero;
		moveSpeed = 0.0f;
	}
	
	void Update() {
		moveDirection = new Vector3(Input.GetAxis("Horizontal"), moveDirection.y, Input.GetAxis("Vertical"));
		
		// Rotate to face forward
		if (!Input.GetButton ("Slow") && (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))) {
			Vector3 facingDirection = new Vector3(moveDirection.x, 0.0f, moveDirection.z);
			if (facingDirection != Vector3.zero) 
				transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(facingDirection), turnSpeed * Time.deltaTime);
		}
		
		if (controller.isGrounded) {
			moveSpeed = (Input.GetButton("Slow"))? slowSpeed : walkSpeed;
			moveDirection.y = 0.0f;
			if (Input.GetButton("Jump")) {
				moveDirection.y = jumpSpeed;
			}
		}
		
		moveDirection.x *= moveSpeed;
		moveDirection.z *= moveSpeed;
		
		// This is necessary because it makes controller grounded
		moveDirection.y -= (gravity * Time.deltaTime);
		controller.Move(moveDirection * Time.deltaTime);
	}
}

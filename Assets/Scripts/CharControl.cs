using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CharacterController))]
public class CharControl : MonoBehaviour
{
	public float turnSpeed = 20.0f;
	public float slowSpeed = 2.0f;
	public float runSpeed = 5.0f;
	public float jumpSpeed = 8.0f;
	public float gravity = 20.0f;
	private float vSpeed;
	private Animator animator;
	private CharacterController charController;
	private HashIDs hash;

	void Awake()
	{
		animator = GetComponent<Animator>();
		charController = GetComponent<CharacterController>();
		hash = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<HashIDs>();
	}

	void Start()
	{
		vSpeed = 0f;

		CameraManager.OnCutSceneStart += handleCutSceneStart;
		CameraManager.OnCutSceneEnd += handleCutSceneEnd;
	}

	void OnDestroy()
	{
		CameraManager.OnCutSceneStart -= handleCutSceneStart;
		CameraManager.OnCutSceneEnd -= handleCutSceneEnd;
	}

	void Update()
	{
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");
		bool slow = Input.GetButton("Slow");
		bool jump = Input.GetButton("Jump");
		AnimationHandle(h, v, slow);
		Rotate(h, v, slow);
		Move(h, v, slow, jump);
	}

	void Move(float h, float v, bool slow, bool jump)
	{
		if (charController.isGrounded)
		{
			vSpeed = jump ? jumpSpeed : 0f;
		}
		vSpeed -= gravity * Time.deltaTime;
		Vector3 moveDirection = new Vector3(h, 0, v);
		moveDirection = (slow ? slowSpeed : runSpeed) * moveDirection.normalized;
		moveDirection.y = vSpeed;
		charController.Move(moveDirection * Time.deltaTime);
	}

	void Rotate(float h, float v, bool slow)
	{
		if (!slow && (h != 0f || v != 0f))
		{
			Vector3 targetDirection = new Vector3(h, 0f, v);
            if (targetDirection != Vector3.zero) {
                Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
                Quaternion newRotation = Quaternion.Lerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
                transform.rotation = newRotation;
            }
		}
	}

	void AnimationHandle(float h, float v, bool slow)
	{
		if (!slow && (h != 0f || v != 0f))
		{
			animator.SetBool(hash.walkingBool, false);
			animator.SetBool(hash.runningBool, true);
		} else if (slow && (h != 0f || v != 0f))
		{
			animator.SetBool(hash.walkingBool, true);
			animator.SetBool(hash.runningBool, false);
		} else
		{
			animator.SetBool(hash.walkingBool, false);
			animator.SetBool(hash.runningBool, false);
		}
	}

	private void handleCutSceneStart()
	{
		enabled = false;
		AnimationHandle(0f, 0f, false);
	}

	private void handleCutSceneEnd()
	{
		enabled = true;
	}
}

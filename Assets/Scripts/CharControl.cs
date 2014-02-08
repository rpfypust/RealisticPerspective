using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CharacterController))]
public class CharControl : MonoBehaviour
{
	public float turnSpeed = 20.0f;
	public float slowSpeed = 2.0f;
	public float runSpeed = 5.0f;
	public float jumpSpeed = 10.0f;
	public float gravity = 9.81f;

	private float vSpeed;

	private Animator animator;
	private CharacterController charController;
	private HashIDs hash;

	void Awake() {
		animator = GetComponent<Animator>();
		charController = GetComponent<CharacterController>();
		hash = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<HashIDs>();
	}

	void Start() {
		vSpeed = 0f;
	}

	void Update() {
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");
		bool slow = Input.GetButton("Slow");
		bool jump = Input.GetButton("Jump");
		AnimationHandle(h, v, slow);
		Rotate(h, v, slow);
		Move(h, v, slow, jump);
	}

	void Move(float h, float v, bool slow, bool jump) {
		h *= slow ? slowSpeed : runSpeed;
		v *= slow ? slowSpeed : runSpeed;
		if (charController.isGrounded) {
			vSpeed = jump? jumpSpeed : 0f;
		}
		vSpeed -= gravity * Time.deltaTime;
		Vector3 moveDirection = new Vector3(h, vSpeed, v);
		charController.Move(moveDirection * Time.deltaTime);
	}

	void Rotate(float h, float v, bool slow) {
		if (!slow && (h != 0f || v != 0f)) {
			Vector3 targetDirection = new Vector3(h, 0f, v);
			Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
			Quaternion newRotation = Quaternion.Lerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
			transform.rotation = newRotation;
		}
	}

	void AnimationHandle(float h, float v, bool slow) {
		if (!slow && (h != 0f || v != 0f)) {
			animator.SetBool(hash.walkingBool, false);
			animator.SetBool(hash.runningBool, true);
		} else if (slow && (h != 0f || v != 0f)) {
			animator.SetBool(hash.walkingBool, true);
			animator.SetBool(hash.runningBool, false);
		} else {
			animator.SetBool(hash.walkingBool, false);
			animator.SetBool(hash.runningBool, false);
		}
	}
	
    /*
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
    
    void Update()
    {
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), moveDirection.y, Input.GetAxis("Vertical"));
        
        // Rotate to face forward
        if (!Input.GetButton("Slow") && (Input.GetButton("Horizontal") || Input.GetButton("Vertical")))
        {
            Vector3 facingDirection = new Vector3(moveDirection.x, 0.0f, moveDirection.z);
            if (facingDirection != Vector3.zero) 
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(facingDirection), turnSpeed * Time.deltaTime);
        }
        
        if (controller.isGrounded)
        {
            moveSpeed = (Input.GetButton("Slow")) ? slowSpeed : walkSpeed;
            moveDirection.y = 0.0f;
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }
        
        moveDirection.x *= moveSpeed;
        moveDirection.z *= moveSpeed;
        
        // This is necessary because it makes controller grounded
        moveDirection.y -= (gravity * Time.deltaTime);
        controller.Move(moveDirection * Time.deltaTime);
    }

    void OnGUI()
    {
        
        Vector2 nameSize;
        string showString = moveDirection.ToString();
        nameSize = GUI.skin.label.CalcSize(new GUIContent(showString));
        GUI.color = Color.black;
        GUI.Label(new Rect(0, nameSize.y * 5, nameSize.x, nameSize.y), showString);
    }
    */
}

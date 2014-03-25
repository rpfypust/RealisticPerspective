using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CharacterController))]
public class IceSkateControl : MonoBehaviour
{
    public float skatingSpeed = 5.0f;
    public float turnSpeed = 20.0f;
    public float gravity = 20.0f;

    private Animator animator;
    private CharacterController charController;
    private HashIDs hash;

    public Vector3 moveDirection;
    public bool isSkating;
    
    void Awake()
    {
        animator = GetComponent<Animator>();
        charController = GetComponent<CharacterController>();
        hash = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<HashIDs>();
    }
    
    void Start()
    {
        moveDirection = Vector3.zero;
        isSkating = false;
    }
    
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        AnimationHandle(h, v);
        Rotate(h, v);
        Move(h, v);
    }

    void OnControllerColliderHit(ControllerColliderHit hit) {
        if (hit.gameObject.tag == Tags.wall
		    || hit.gameObject.tag == Tags.stageObstacle
		    || hit.gameObject.tag == Tags.door) {
            moveDirection = Vector3.zero;
            isSkating = false;
        }
    }
    
    void Move(float h, float v)
    {
        if (!isSkating)
        {
            if (h == 0f && v != 0f) {
                moveDirection = v < 0? Vector3.back : Vector3.forward;
                moveDirection = skatingSpeed * moveDirection.normalized;
                isSkating = true;
            } else if (h != 0f && v == 0f) {
                moveDirection = h < 0? Vector3.left : Vector3.right;
                moveDirection = skatingSpeed * moveDirection.normalized;
                isSkating = true;
            }
        }
        if (charController.isGrounded)
        {
            moveDirection.y = 0f;
        }
        moveDirection.y -= gravity * Time.deltaTime;
        charController.Move(moveDirection * Time.deltaTime);
    }
    
    void Rotate(float h, float v)
    {
        if (h != 0f || v != 0f)
        {
            Vector3 targetDirection = new Vector3(h, 0f, v);
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            Quaternion newRotation = Quaternion.Lerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
            transform.rotation = newRotation;
        }
    }
    
    void AnimationHandle(float h, float v)
    {
        if (h != 0f || v != 0f)
        {
            animator.SetBool(hash.walkingBool, false);
            animator.SetBool(hash.runningBool, true);
        } else
        {
            animator.SetBool(hash.walkingBool, false);
            animator.SetBool(hash.runningBool, false);
        }
    }
}

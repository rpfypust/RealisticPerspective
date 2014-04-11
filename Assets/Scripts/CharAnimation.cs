using UnityEngine;
using System.Collections;

public class CharAnimation : MonoBehaviour {
	private Animator animator;
	private HashIDs hash;

	void Awake()
	{
		animator = GetComponent<Animator>();
		hash = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<HashIDs>();
	}

	void Start()
	{
		CutSceneManager.OnCutSceneStart += handleCutSceneStart;
		CutSceneManager.OnCutSceneEnd += handleCutSceneEnd;
	}
	
	void OnDestroy()
	{
		CutSceneManager.OnCutSceneStart -= handleCutSceneStart;
		CutSceneManager.OnCutSceneEnd -= handleCutSceneEnd;
	}

	private void handleCutSceneStart()
	{
		enabled = false;
		AnimationHandle(0f, 0f, false, false, true);
	}
	
	private void handleCutSceneEnd()
	{
		enabled = true;
	}

	void Update()
	{
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");
		bool slow = Input.GetButton("Slow");
		bool jump = Input.GetButtonUp("Jump");
		bool handUp = Input.GetButtonDown("Fire1");
		bool handDown = Input.GetButtonUp("Fire1");

		AnimationHandle(h, v, slow, handUp, handDown);
	}

	void AnimationHandle(float h, float v, bool slow, bool handUp, bool handDown)
	{
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

		if (handUp) {
			animator.SetBool(hash.attackingBool, true);
		} else if (handDown) {
			animator.SetBool(hash.attackingBool, false);
		}
	}
}

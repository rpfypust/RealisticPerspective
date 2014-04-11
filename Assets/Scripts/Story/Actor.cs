using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class Actor : MonoBehaviour {

	public float moveSpeed = 1f;
	public float runSpeed = 1.5f;
	public float fadeTime = 0.1f;
	public float rotateTime = 1f;
	public Transform EmotionPt;
	private HashIDs hash;

	void Awake()
	{
		hash = GameObject.FindGameObjectWithTag(Tags.storyController).GetComponent<HashIDs>();
	}

	public IEnumerator move(Transform target)
	{	
		transform.LookAt(target.position);
		GetComponent<Animator>().SetBool(hash.walkingBool,true);
		yield return StartCoroutine(transform.LinearMoveWithSpeed(transform.position, target.position, moveSpeed));
		GetComponent<Animator>().SetBool(hash.walkingBool,false);
	}

	public IEnumerator run(Transform target)
	{	
		transform.LookAt(target.position);
		GetComponent<Animator>().SetBool(hash.runningBool,true);
		yield return StartCoroutine(transform.LinearMoveWithSpeed(transform.position, target.position, runSpeed));
		GetComponent<Animator>().SetBool(hash.runningBool,false);
	}

	public IEnumerator alphaChange(float alpha)
	{	
		Color color = GetComponentInChildren< Renderer >().material.color;

		while (color.a != alpha)
		{
			color.a = Mathf.MoveTowards(color.a,alpha,.25f);
			GetComponentInChildren< Renderer >().material.color = color;
			yield return new WaitForSeconds(fadeTime);
		}
	}

	public IEnumerator faceTo(Transform target)
	{	
		Quaternion rotation = Quaternion.LookRotation(target.transform.position - transform.position);
		float elpasedTime = 0;
		while(elpasedTime < rotateTime)
		{
			transform.rotation = Quaternion.Lerp(target.transform.rotation, rotation,elpasedTime/rotateTime);
			elpasedTime += Time.deltaTime;
			yield return null;
		}
	}



}
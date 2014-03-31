using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class Actor : MonoBehaviour {

	public float moveSpeed = 1f;
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
		while(transform.position != target.position)
		{
			transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
			yield return null;
		}
		GetComponent<Animator>().SetBool(hash.walkingBool,false);
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

	public IEnumerator faceTo(GameObject target)
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
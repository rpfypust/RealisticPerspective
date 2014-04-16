using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class Actor : MonoBehaviour {

	public Transform EmotionPt;
	private HashIDs hash;
	public GameObject tunnelIcon;
	public GameObject tunnelParticle;

	void Awake()
	{
		hash = GameObject.FindGameObjectWithTag(Tags.storyController).GetComponent<HashIDs>();
	}

	public IEnumerator walkWithSpeed(Transform target, float speed)
	{	
		transform.LookAt(target.position);
		GetComponent<Animator>().SetBool(hash.walkingBool,true);
		yield return StartCoroutine(transform.LinearMoveWithSpeed(transform.position, target.position, speed));
		GetComponent<Animator>().SetBool(hash.walkingBool,false);
	}

	public IEnumerator walkWithTime(Transform target, float time)
	{	
		transform.LookAt(target.position);
		GetComponent<Animator>().SetBool(hash.walkingBool,true);
		yield return StartCoroutine(transform.LinearMoveWithSpeed(transform.position, target.position, time));
		GetComponent<Animator>().SetBool(hash.walkingBool,false);
	}

	public IEnumerator runWithSpeed(Transform target, float speed)
	{	
		transform.LookAt(target.position);
		GetComponent<Animator>().SetBool(hash.runningBool,true);
		yield return StartCoroutine(transform.LinearMoveWithSpeed(transform.position, target.position, speed));
		GetComponent<Animator>().SetBool(hash.runningBool,false);
	}

	public IEnumerator runWithTime(Transform target, float time)
	{	
		transform.LookAt(target.position);
		GetComponent<Animator>().SetBool(hash.runningBool,true);
		yield return StartCoroutine(transform.LinearMoveWithTime(transform.position, target.position, time));
		GetComponent<Animator>().SetBool(hash.runningBool,false);
	}

	public IEnumerator alphaChange(float alpha, float time)
	{	
		Color color = GetComponentInChildren< Renderer >().material.color;
		float step = (alpha - color.a) / time;
		float elpasedTime = 0;
		while(elpasedTime < time)
		{
			color.a += step * Time.fixedDeltaTime;
			GetComponentInChildren< Renderer >().material.color = color;
			elpasedTime += Time.deltaTime;
			yield return new WaitForFixedUpdate();
		}
	}

	public IEnumerator faceTo(Transform target, float time)
	{	
		Quaternion rotation = Quaternion.LookRotation(target.transform.position - transform.position);
		float step = rotation.eulerAngles.y / time;
		float elpasedTime = 0;
		while(elpasedTime < time)
		{
			transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, step*Time.fixedDeltaTime);
			elpasedTime += Time.deltaTime;
			yield return new WaitForFixedUpdate();
		}
	}

	public IEnumerator rotate(float angle, float time)
	{	
		float step =  angle / time;
		float elapsedTime = 0;
		
		while (elapsedTime <= time) {
			transform.Rotate(0, step*Time.fixedDeltaTime, 0);
			elapsedTime += Time.fixedDeltaTime;
			yield return new WaitForFixedUpdate();
		}
	}

	public IEnumerator tunnelIn()
	{	

		GameObject icon = (GameObject) Instantiate(tunnelIcon, EmotionPt.position , Quaternion.identity);
		Vector3 normalScale = Vector3.one;
		Vector3 finalScale = new Vector3(0, 1, 0);

		StartCoroutine(icon.transform.LinearMoveWithTime(icon.transform.position, transform.position, 1.5f));
		float elapsedTime = 0;
		while (elapsedTime <= 1.5f) {
			icon.transform.Rotate(0, 720*Time.fixedDeltaTime, 0);
			elapsedTime += Time.fixedDeltaTime;
			yield return new WaitForFixedUpdate();
		}
		GameObject particle = (GameObject) Instantiate(tunnelParticle, transform.position , Quaternion.Euler(new Vector3(-90,0,0)));
		yield return new WaitForSeconds(1.5f);
		StartCoroutine(transform.ScaleWithTime(normalScale,finalScale,0.1f));
		yield return null;

	}


}
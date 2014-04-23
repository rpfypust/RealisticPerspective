using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class Actor : MonoBehaviour {

	public Transform EmotionPt;
	private HashIDs hash;
	public GameObject tunnelIcon;
	public GameObject tunnelParticle;
	public GameObject vanishParticle;
	private SEManager sem;

	void Awake()
	{
		hash = GameObject.FindGameObjectWithTag(Tags.storyController).GetComponent<HashIDs>();
		sem = GameObject.FindGameObjectWithTag(Tags.storyController).GetComponentInChildren<SEManager>();
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
		yield return StartCoroutine(transform.LinearMoveWithTime(transform.position, target.position, time));
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
		float step = Mathf.Abs(rotation.eulerAngles.y - transform.rotation.eulerAngles.y) / time;

		float elpasedTime = 0;
		while(elpasedTime <= time)
		{
			transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, step * Time.fixedDeltaTime * 2.0f);
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
		Transform meshTransform = transform.FindChild("armature");
		Vector3 normalScale = Vector3.one;
		Vector3 finalScale = new Vector3(0, 0, 1);
		Vector3 dest = transform.position;
		dest.y += 0.01f;

		StartCoroutine(icon.transform.LinearMoveWithTime(icon.transform.position, dest, 1.5f));
		float elapsedTime = 0;
		while (elapsedTime <= 1.5f) {
			icon.transform.Rotate(0, 720*Time.fixedDeltaTime, 0);
			elapsedTime += Time.fixedDeltaTime;
			yield return new WaitForFixedUpdate();
		}
		sem.PlaySoundEffect(2);
		GameObject particle = (GameObject) Instantiate(tunnelParticle, transform.position , Quaternion.Euler(new Vector3(-90,0,0)));
		yield return new WaitForSeconds(1.5f);
		yield return StartCoroutine(meshTransform.ScaleWithTime(normalScale,finalScale,0.1f));
		meshTransform.localScale = new Vector3(0, 0, 0);

		particle.GetComponent<ParticleSystem>().loop = false;
		yield return new WaitForSeconds(1.5f);
		Destroy(icon);
		Destroy(particle);

		yield return null;

	}

	public IEnumerator tunnelOut()
	{	
		
		GameObject icon = (GameObject) Instantiate(tunnelIcon, EmotionPt.position , Quaternion.identity);
		Vector3  normalScale = new Vector3(0, 0, 1);
		Vector3 finalScale = Vector3.one;
		Transform meshTransform = transform.FindChild("armature");
		meshTransform.localScale = new Vector3(0, 0, 0);
		Vector3 dest = transform.position;
		dest.y += 0.01f;
		StartCoroutine(icon.transform.LinearMoveWithTime(icon.transform.position, dest, 1.5f));
		float elapsedTime = 0;
		while (elapsedTime <= 1.5f) {
			icon.transform.Rotate(0, 720 * Time.fixedDeltaTime, 0);
			elapsedTime += Time.fixedDeltaTime;
			yield return new WaitForFixedUpdate();
		}
		sem.PlaySoundEffect(2);
		GameObject particle = (GameObject) Instantiate(tunnelParticle, transform.position , Quaternion.Euler(new Vector3(-90,0,0)));
		yield return new WaitForSeconds(1.5f);
		yield return StartCoroutine(meshTransform.ScaleWithTime(normalScale,finalScale,0.1f));

		particle.GetComponent<ParticleSystem>().loop = false;
		yield return new WaitForSeconds(1.5f);
		Destroy(icon);
		Destroy(particle);

		yield return null;
		
	}

	public IEnumerator vanish()
	{	

		Transform meshTransform = transform.FindChild("armature");
		Vector3 normalScale = Vector3.one;
		Vector3 finalScale = new Vector3(0.7f, 0.7f, 1);
		Vector3 pos = transform.position;
		pos.y += 0.7f;
		sem.PlaySoundEffect(2);
		GameObject particle = (GameObject) Instantiate(vanishParticle, pos , Quaternion.Euler(new Vector3(-90,0,0)));
		yield return StartCoroutine(meshTransform.ScaleWithTime(normalScale,finalScale,0.6f));
		normalScale = finalScale;
		finalScale = new Vector3(0, 0, 0);
		StartCoroutine(meshTransform.ScaleWithTime(normalScale,finalScale,0.2f));
		StartCoroutine(this.transform.LinearMoveWithTime(transform.position,pos,0.2f));

		yield return new WaitForSeconds(2);
		meshTransform.localScale = new Vector3(0, 0, 0);

		Destroy(particle);
		yield return null;
	}

	public IEnumerator crouch()
	{	
		GetComponent<Animator>().SetBool(hash.crouchingBool,true);
		yield return null;
	}

	public IEnumerator Uncrouch()
	{	
		GetComponent<Animator>().SetBool(hash.crouchingBool,false);
		yield return null;
	}

}
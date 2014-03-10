using UnityEngine;
using System.Collections;

public abstract class Motion : MonoBehaviour {

	public void startMoving()
	{
		StartCoroutine("moveCoroutine");
	}

	public void stopMoving()
	{
		StopCoroutine("moveCoroutine");
	}

	protected abstract IEnumerator moveCoroutine();
}

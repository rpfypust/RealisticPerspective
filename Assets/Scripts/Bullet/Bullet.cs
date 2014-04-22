using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public float damage = 1.0f;

	/*private void Start()
	{
		CutSceneManager.OnCutSceneStart += OnCutSceneStartHandler;
		CutSceneManager.OnCutSceneEnd += OnCutSceneEndHandler;
	}

	private void OnDestroy()
	{
		CutSceneManager.OnCutSceneStart -= OnCutSceneStartHandler;
		CutSceneManager.OnCutSceneEnd -= OnCutSceneEndHandler;
	}

	private void OnCutSceneStartHandler()
	{
		collider.enabled = false;
	}

	private void OnCutSceneEndHandler()
	{
		collider.enabled = true;
	}*/

	public virtual void dealDamage(Character c) {
		c.takeDamage(damage);
	}
}

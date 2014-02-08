using UnityEngine;
using System.Collections;

public class Suiside : MonoBehaviour
{
	public float DestroyTime = 16.0f;
	void Awake () 
	{
		Destroy(gameObject, DestroyTime);
	}
}
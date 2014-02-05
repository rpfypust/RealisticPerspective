using UnityEngine;
using System.Collections;

public class Suiside : MonoBehaviour
{
	public int DestroyTime = 8;
	void Awake () 
	{
		Destroy(gameObject, DestroyTime);
	}
}
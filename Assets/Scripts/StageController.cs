using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TimeCounter))]
public sealed class StageController : MonoBehaviour {
	private TimeCounter counter;

	private void Awake()
	{
		counter = GetComponent<TimeCounter>();
	}

	private void Start()
	{
		counter.startTimer();
	}

	private void OnDestroy()
	{
		counter.stopTimer();
	}
}

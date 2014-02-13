using UnityEngine;
using System.Collections;

public class A01_WhileTrue_Boss : MonoBehaviour
{
	//bullet information
	public Vector3 center;
	public float r;
	public float round;
	public float moveTime = 8.0f;
	public float fadeTime = 1.0f;
	public float startTime = Time.time;
	public Vector3 oriPos;
	public bool isFinished = false;
	private float lastTime = 0.0f;
	private float deltaTime = 0.0f;
	public float currentAngular = 0.0f;
	private float deltaAngular = 0.0f;
	private Vector3 newPos;
    
    void Awake()
	{
		startTime = Time.time;
		newPos = Vector3.zero;
		oriPos.x = transform.position.x;
		oriPos.z = transform.position.z;
		isFinished = false;
	}
	
	void FixedUpdate()
	{
		float cTime = Time.time - startTime;
		deltaTime = cTime - lastTime;
		if (!isFinished)
		{
			if (cTime >= moveTime)
			{
				isFinished = true;
			} else
			{
				//moving
                float ang=2*Mathf.PI*round/(moveTime-fadeTime);
                if(cTime<fadeTime){
                    deltaAngular=ang*cTime/fadeTime*deltaTime;
                }else if(cTime<moveTime-fadeTime){
					deltaAngular=ang*deltaTime;
				}else{
					deltaAngular=ang*(moveTime-cTime)/fadeTime*deltaTime;
				}
				currentAngular+=deltaAngular;
				newPos = new Vector3(r*Mathf.Sin (currentAngular),0,r*Mathf.Cos (currentAngular));
				rigidbody.MovePosition(center + newPos);
			}
		}
		lastTime = cTime;
	}
	
}
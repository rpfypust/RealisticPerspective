using UnityEngine;
using System.Collections;

public class PH1_Phoenix_Rotate : MonoBehaviour
{
	public float startTime = Time.time;
    public Vector3 StageRefPoint;
    public float angularSpeed;
	private int j = 0;
    private float lastTime = 0.0f;
    private float deltaTime = 0.0f;
    
    void FixedUpdate()
    {
        float cTime = Time.time - startTime;
        deltaTime = cTime - lastTime;

        transform.RotateAround(StageRefPoint,Vector3.up,angularSpeed * deltaTime);

	    lastTime = cTime;
    }
}
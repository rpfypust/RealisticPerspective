using UnityEngine;
using System.Collections;

public class BulletLinearMove : MonoBehaviour
{
    
    public float startTime = Time.time;
    private float lastTime = 0.0f;
    private float deltaTime = 0.0f;
    private GameObject target;
	public Vector3 velocity;

    void FixedUpdate()
    {
        float cTime = Time.time - startTime;
        deltaTime = cTime - lastTime;

		transform.position += velocity * deltaTime;

        lastTime = cTime;
    }
}
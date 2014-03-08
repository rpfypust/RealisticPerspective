using UnityEngine;
using System.Collections;

public class UniformMotionWithinTime : MonoBehaviour
{
    //bullet information
    public float x;
    public float y;
    public float z;
    public float moveTime = 2.0f;
    public float startTime = Time.time;
    public Vector3 oriPos;
    public bool isFinished = false;
    private float lastTime = 0.0f;
    private float deltaTime = 0.0f;
    private Vector3 speed;
    
    void Awake()
    {
        startTime = Time.time;
        speed = Vector3.zero;
        oriPos.x = transform.position.x;
        oriPos.y = transform.position.y;
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
                speed = new Vector3((x - oriPos.x) / moveTime, (y - oriPos.y) / moveTime, (z - oriPos.z) / moveTime);
                rigidbody.MovePosition(rigidbody.position + speed * deltaTime);
            }
        }
        lastTime = cTime;
    }
    
}
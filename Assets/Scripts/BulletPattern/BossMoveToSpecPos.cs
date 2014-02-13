using UnityEngine;
using System.Collections;

public class BossMoveToSpecPos : MonoBehaviour
{
    //bullet information
    public float x;
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
                float ratio = 4.0f / moveTime / moveTime * (moveTime / 2.0f - Mathf.Abs(cTime - moveTime / 2.0f));
                speed = new Vector3((x - oriPos.x) * ratio, 0, (z - oriPos.z) * ratio);
                rigidbody.MovePosition(rigidbody.position + speed * deltaTime);
            }
        }
        lastTime = cTime;
    }
    
}
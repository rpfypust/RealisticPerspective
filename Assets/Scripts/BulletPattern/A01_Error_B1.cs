using UnityEngine;
using System.Collections;

public class A01_Error_B1 : MonoBehaviour
{
    public float startTime = Time.time;
    public float finalPositionX = 0.0f;
    public float finalPositionZ = 0.0f;
    public float lastFor = 2.0f;
    public Vector3 oriPos;
    public float lastTime = 0.0f;
    public float deltaTime = 0.0f;

    void FixedUpdate ()
    {
        float cTime = Time.time - startTime;
        deltaTime = cTime - lastTime;

        if(cTime<=lastFor){
            float ratio = 2.0f /lastFor/lastFor*(lastFor-cTime);
            Vector3 speed = new Vector3 (finalPositionX*ratio, 0, finalPositionZ*ratio);
            rigidbody.MovePosition (rigidbody.position + speed * deltaTime);
        }
        
        lastTime = cTime;
    }
}
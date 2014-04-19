using UnityEngine;
using System.Collections;

public class PH1_6_Snake : MonoBehaviour
{
    public float startTime = Time.time;
    public Vector3 velo;
    public Vector3 oscili;
    public Vector3 oriPos;
    public float period;
    public float phase;
    private float lastTime = 0.0f;
    private float deltaTime = 0.0f;

    void FixedUpdate()
    {
        float cTime = Time.time - startTime;
        deltaTime = cTime - lastTime;

        rigidbody.MovePosition(oriPos + velo * cTime + oscili * Mathf.Sin(cTime/period * 2f * Mathf.PI + phase));

        lastTime = cTime;
    }
}
using UnityEngine;
using System.Collections;

public class CS1_Antivirus_B2 : MonoBehaviour
{
    public float startTime = Time.time;
    public float vx = 0.0f;
    public float vz = 0.0f;
    public Vector3 oriPos;
    public float changeTime = 1.0f;
    private float lastTime = 0.0f;
    private float deltaTime = 0.0f;
    private GameObject target;
    private Vector3 speed;
    private bool changed = false;
    
    void FixedUpdate ()
    {
        float cTime = Time.time - startTime;
        deltaTime = cTime - lastTime;
        
        speed = new Vector3(vx, 0, vz);

        if((cTime>changeTime)&&(!changed)){
            target = GameObject.FindWithTag("Player");
            speed = (target.transform.position - rigidbody.position).normalized * speed.magnitude * 1.5f;
            vx = speed.x;
            vz = speed.z;
            changed = true;
        }
        
        rigidbody.MovePosition(rigidbody.position + speed * deltaTime);
        
        lastTime = cTime;
    }
}
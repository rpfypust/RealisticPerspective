using UnityEngine;
using System.Collections;

public class A01_Error_B2 : MonoBehaviour
{
    public float startTime = Time.time;
    public float vx = 0.0f;
    public float vz = 0.0f;
    public Vector3 oriPos;
    public float lastTime = 0.0f;
    public float deltaTime = 0.0f;
    private GameObject target;
    private Vector3 speed;
    
    void FixedUpdate ()
    {
        speed = new Vector3(vx, 0, vz);
        float cTime = Time.time - startTime;
        deltaTime = cTime - lastTime;
        
        rigidbody.MovePosition(rigidbody.position + speed * deltaTime);
        
        lastTime = cTime;
    }

    void OnTriggerEnter(Collider collider){
        if(collider.gameObject.name=="BulletSet_Error"){
            Destroy(gameObject);
        }
    }
}
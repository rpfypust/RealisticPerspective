using UnityEngine;
using System.Collections;

public class A01_B2 : MonoBehaviour
{
    
    public float startTime = Time.time;
    public float vx = 0.0f;
    public float vz = 0.0f;
    public Vector3 oriPos;
    public float lastTime = 0.0f;
    public float deltaTime = 0.0f;
    private GameObject target;
    private Vector3 speed;
    private bool alreadyCollided = false;

    void FixedUpdate()
    {
        speed = new Vector3(vx, 0, vz);
        float cTime = Time.time - startTime;
        deltaTime = cTime - lastTime;

        rigidbody.MovePosition(rigidbody.position + speed * deltaTime);

        lastTime = cTime;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Tag_Wall")
        {
            if (alreadyCollided)
            {
                GameObject.Destroy(gameObject,0.0f);
            } else
            {
                target = GameObject.FindWithTag("Player");
                speed = (target.transform.position - rigidbody.position).normalized * speed.magnitude * 1.5f;
                vx = speed.x;
                vz = speed.z;
                alreadyCollided = true;
            }
        }
    }
}
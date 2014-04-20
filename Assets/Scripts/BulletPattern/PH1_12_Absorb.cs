using UnityEngine;
using System.Collections;

public class PH1_12_Absorb : MonoBehaviour
{
    public float startTime = Time.time;
    public Vector3 dest;
    public Vector3 oriPos;
    public float radius;
    public float moveTime;
    private float lastTime = 0.0f;
    private float deltaTime = 0.0f;
    private GameObject BulletX; //bullets are using this to be created

    void FixedUpdate()
    {
        float cTime = Time.time - startTime;
        deltaTime = cTime - lastTime;
        float angle = cTime / moveTime * Mathf.PI;
        float height = radius * Mathf.Sin(angle);

        rigidbody.MovePosition(oriPos + (dest - oriPos) * cTime / moveTime + new Vector3(0f, height, 0f));

        if (cTime > moveTime)
        {
            GameObject.Destroy(gameObject);
        }

        lastTime = cTime;
    }
}
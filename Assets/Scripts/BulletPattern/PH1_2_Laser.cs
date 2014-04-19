using UnityEngine;
using System.Collections;

public class PH1_2_Laser : MonoBehaviour
{
    
    public float startTime = Time.time;
    public float angle;
    public float maxLength;
    public float duration;
    private float lastTime = 0.0f;
    private float deltaTime = 0.0f;
    private int j = 0;
    
    void FixedUpdate()
    {
        float cTime = Time.time - startTime;
        deltaTime = cTime - lastTime;

        float ratio = 1f - 2f * Mathf.Abs(duration / 2f - cTime) / duration;
        transform.localScale = new Vector3(1f, 1f, maxLength * ratio);
        transform.Rotate(0.0f, angle * deltaTime / duration, 0.0f);

        lastTime = cTime;
        j++;
        if(cTime > duration) {
            GameObject.Destroy(gameObject);
        }
    }
}
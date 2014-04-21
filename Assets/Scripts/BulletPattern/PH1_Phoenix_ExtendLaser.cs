using UnityEngine;
using System.Collections;

public class PH1_Phoenix_ExtendLaser : MonoBehaviour
{
    
    public float startTime = Time.time;
    public float maxLength;
    public float duration;
    private float lastTime = 0.0f;
    private float deltaTime = 0.0f;
    
    void FixedUpdate()
    {
        float cTime = Time.time - startTime;
        deltaTime = cTime - lastTime;

        float ratio = cTime / duration;
        transform.localScale = new Vector3(0.25f, 0.25f, maxLength * ratio);

        lastTime = cTime;
        if(cTime > duration) {
            GameObject.Destroy(gameObject.GetComponent<PH1_Phoenix_ExtendLaser>());
        }
    }
}
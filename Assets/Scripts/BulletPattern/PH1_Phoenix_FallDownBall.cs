using UnityEngine;
using System.Collections;

public class PH1_Phoenix_FallDownBall : MonoBehaviour
{
    public float startTime = Time.time;
    public Vector3 dest;
    public Vector3 oriPos;
    public float moveTime;
    private float lastTime = 0.0f;
    private float deltaTime = 0.0f;
    private SEManager sem;
    
    void Awake()
    {
        sem = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<SEManager>();
    }

    void FixedUpdate()
    {
        float cTime = Time.time - startTime;
        deltaTime = cTime - lastTime;

		float ratio = cTime * cTime / moveTime / moveTime;
        transform.position = oriPos + ratio * (dest-oriPos);

		if(cTime>moveTime){
            transform.position = new Vector3(transform.position.x,0f,transform.position.z);
            sem.PlaySoundEffect(9);
            GameObject.Destroy(gameObject.GetComponent<PH1_Phoenix_FallDownBall>());
		}

        lastTime = cTime;
    }
}
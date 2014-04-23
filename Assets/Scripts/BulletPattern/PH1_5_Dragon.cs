using UnityEngine;
using System.Collections;

public class PH1_5_Dragon : MonoBehaviour
{
    public GameObject BulletBlue;
    public float startTime = Time.time;
    public Vector3 dest;
    public Vector3 oriPos;
    public float radius;
    public float moveTime;
    private float angle;
    private float lastTime = 0.0f;
    private float deltaTime = 0.0f;
	private GameObject BulletX; //bullets are using this to be created
	private SEManager sem;
	
	void Awake()
	{
		sem = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<SEManager>();
	}

    void FixedUpdate()
    {
        float cTime = Time.time - startTime;
        deltaTime = cTime - lastTime;
        angle = cTime / moveTime * Mathf.PI;
        float height = radius * Mathf.Sin(angle);

        rigidbody.MovePosition(oriPos + (dest - oriPos) * cTime / moveTime + new Vector3(0f, height, 0f));

        if (cTime > moveTime)
        {
            
            for (int i=0; i<2; i++)
            {
                angle = Random.value * 2.0f * Mathf.PI;
                float speed = Random.value * 7.0f + 6.0f;
                BulletX = (GameObject)Instantiate(BulletBlue, transform.position, transform.rotation);
                BulletX.rigidbody.velocity = new Vector3(speed * Mathf.Sin(angle), 0.0f, speed * Mathf.Cos(angle));
                Destroy(BulletX.gameObject, 8.0f);
                BulletX.rigidbody.useGravity = false;
			}
			sem.PlaySoundEffect(2);
            GameObject.Destroy(gameObject);
        }

        lastTime = cTime;
    }
}
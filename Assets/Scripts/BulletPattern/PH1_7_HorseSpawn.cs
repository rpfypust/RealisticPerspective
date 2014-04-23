using UnityEngine;
using System.Collections;

public class PH1_7_HorseSpawn : MonoBehaviour
{
	public GameObject BulletOrange;
	public float startTime = Time.time;
	public float angle;
	public float speed;
	private int j = 0;
	private float lastTime = 0.0f;
	private float deltaTime = 0.0f;
	private GameObject BulletX; //bullets are using this to be created
	private int[,] pattern = {
        {0,0,0,0,1},
        {1,1,1,1,1},
        {0,1,1,0,0},
        {0,1,1,0,0},
        {1,1,1,0,0}
    };

	void FixedUpdate()
	{
		float cTime = Time.time - startTime;
		deltaTime = cTime - lastTime;
        
		if ((cTime - lastTime) > 0.03f)
		{
			for (int j=0; j<5; j++)
			{
				for (int i=0; i<5; i++)
				{
					if (pattern [j, i] == 1)
					{
						Vector3 spawn = new Vector3(0f, i * 0.5f, 0f) - 0.5f * j * new Vector3(Mathf.Sin(angle), 0.0f, Mathf.Cos(angle));
						BulletX = (GameObject)Instantiate(BulletOrange, transform.position + spawn, transform.rotation);
						BulletX.rigidbody.velocity = speed * new Vector3(Mathf.Sin(angle), 0.0f, Mathf.Cos(angle));
						Destroy(BulletX.gameObject, 6.0f);
						BulletX.rigidbody.useGravity = false;
					}
				}
			}
			/*lastTime = cTime;
            j++;
            if (j == 5)
            {
                GameObject.Destroy(gameObject);
            }*/
			GameObject.Destroy(gameObject);
		}
	}
}
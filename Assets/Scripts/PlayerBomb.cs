using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SphereCollider))]
public class PlayerBomb : MonoBehaviour {

	private Player player;
	private SphereCollider bombTrigger;
	private GameObject bombObject;
	bool isOn;
	public float growthDuration;
	public float duration;

	void Awake()
	{
		player = transform.parent.GetComponent<Player>();
		bombTrigger = GetComponent<SphereCollider>();
		bombObject = transform.FindChild("bomb_effect").gameObject;
		isOn = false;
	}

	void Update()
	{
		bool bomb = Input.GetButtonDown("Fire2");

		if (bomb && !isOn && player.MagicPoint >= 10.0f) {
			player.MagicPoint -= 10.0f;
			StartCoroutine(ReleaseBomb());
		}                           
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == Tags.enemyBullet) {
			Destroy(other.gameObject);
		}
	}

	private IEnumerator ReleaseBomb()
	{
		isOn = true;
		bombTrigger.enabled = true;

		float maxRadius = bombTrigger.radius;
		float step = maxRadius / growthDuration * Time.fixedDeltaTime;

		bombTrigger.radius = 0.0f;
		bombObject.SetActive(true);
		float startTime = Time.time;
		while (Time.time - startTime <= growthDuration) {
			bombTrigger.radius += step;
			bombObject.transform.localScale = new Vector3(2f, 1.5f, 2f) * bombTrigger.radius;
			bombObject.transform.rotation = Quaternion.identity;
			yield return new WaitForFixedUpdate();
		}
		bombTrigger.radius = maxRadius;
		while (Time.time - startTime <= duration) {
			bombObject.transform.rotation = Quaternion.identity;
			yield return new WaitForFixedUpdate();
		}

		bombObject.SetActive(false);
		bombTrigger.enabled = false;
		isOn = false;
	}
}

using UnityEngine;
using System.Collections;

public class PlayerShooter : MonoBehaviour {
	
	public GameObject bullet;
	public float bulletSpeed = 10.0f;
	private float nextShootTime = 0.0f;
	
	void FixedUpdate () {
		if (Input.GetButton("Fire1") && Time.time > nextShootTime) {
			GameObject a = (GameObject) Instantiate(bullet, transform.position, transform.rotation);
			a.rigidbody.velocity = transform.forward.normalized * bulletSpeed;
			nextShootTime = 0.1f + Time.time;
		}
	}
}

using UnityEngine;
using System.Collections;

public class PlayerShooter : MonoBehaviour
{

    public GameObject bullet; //prefab
    public float bulletSpeed = 15.0f;
    public float shootInterval = 0.1f;
    private float nextShootTime = 0.0f;

    void FixedUpdate()
    {
        if (Input.GetButton("Fire1") && Time.time > nextShootTime)
        {
            GameObject a = (GameObject)Instantiate(bullet, transform.position, transform.rotation);

            //how bullet move
            a.gameObject.AddComponent("PlayerBullet_Homing");
            a.gameObject.GetComponent<PlayerBullet_Homing>().bulletSpeed = bulletSpeed;

            //Rotate the direction
            Vector3 temp = new Vector3();
            temp.y = transform.forward.normalized.y;
            temp.x = transform.forward.normalized.x * Mathf.Cos(30 / 180.0f * Mathf.PI) - transform.forward.normalized.z * Mathf.Sin(30 / 180.0f * Mathf.PI);
            temp.z = transform.forward.normalized.z * Mathf.Sin(30 / 180.0f * Mathf.PI) + transform.forward.normalized.z * Mathf.Cos(30 / 180.0f * Mathf.PI);

            a.gameObject.GetComponent<PlayerBullet_Homing>().direction = temp.normalized;

            //how bullet damage
            a.gameObject.AddComponent("BulletInfo");
            a.gameObject.GetComponent<BulletInfo>().Damage = 1.0f;


            //Create another direction bullet
            GameObject b = (GameObject)Instantiate(bullet, transform.position, transform.rotation);

            //how bullet move
            b.gameObject.AddComponent("PlayerBullet_Homing");
            b.gameObject.GetComponent<PlayerBullet_Homing>().bulletSpeed = bulletSpeed;
            
            //Rotate the direction
            temp = new Vector3();
            temp.y = transform.forward.normalized.y;
            temp.x = transform.forward.normalized.x * Mathf.Cos(330 / 180.0f * Mathf.PI) - transform.forward.normalized.z * Mathf.Sin(330 / 180.0f * Mathf.PI);
            temp.z = transform.forward.normalized.z * Mathf.Sin(330 / 180.0f * Mathf.PI) + transform.forward.normalized.z * Mathf.Cos(330 / 180.0f * Mathf.PI);
            
            b.gameObject.GetComponent<PlayerBullet_Homing>().direction = temp.normalized;
            
            //how bullet damage
            b.gameObject.AddComponent("BulletInfo");
            b.gameObject.GetComponent<BulletInfo>().Damage = 1.0f;

            nextShootTime = shootInterval + Time.time;
        }
    }
}


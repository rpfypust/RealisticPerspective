using UnityEngine;
using System.Collections;

public class PlayerShooter : MonoBehaviour
{
    public GameObject bullet_normal;
    public GameObject bullet_homing;
    public float bulletSpeed = 30.0f;
    public float shootInterval_normal = 0.05f;
    public float shootInterval_homing = 0.2f;
    private float nextShootTime_normal = 0.0f;
    private float nextShootTime_homing = 0.0f;
    private GameObject bulletX;
    private Vector3 temp;
    private float tempF;

    void FixedUpdate()
    {
        if (Input.GetButton("Fire1") && Time.time > nextShootTime_normal)
        {
            for (int i=-1; i<=1; i+=2)
            { 
                temp = transform.forward.normalized;
                tempF = temp.x;
                temp.x = -temp.z;
                temp.z = tempF;

                bulletX = (GameObject)Instantiate(bullet_normal, transform.position + 0.3f * temp * i, transform.rotation);
                bulletX.gameObject.rigidbody.velocity = bulletSpeed * transform.forward.normalized;
                bulletX.gameObject.AddComponent("BulletInfo");
                bulletX.gameObject.GetComponent<BulletInfo>().Damage = 1.0f;

                bulletX = (GameObject)Instantiate(bullet_normal, transform.position + 0.3f * temp * i, transform.rotation);
                temp = transform.forward.normalized;
                temp.x = temp.x * Mathf.Cos(i * 2f / 180.0f * Mathf.PI) - temp.z * Mathf.Sin(i * 2f / 180.0f * Mathf.PI);
                temp.z = temp.x * Mathf.Sin(i * 2f / 180.0f * Mathf.PI) + temp.z * Mathf.Cos(i * 2f / 180.0f * Mathf.PI);
                bulletX.gameObject.rigidbody.velocity = bulletSpeed * temp;
                bulletX.gameObject.AddComponent("BulletInfo");
                bulletX.gameObject.GetComponent<BulletInfo>().Damage = 1.0f;
            }

            nextShootTime_normal = shootInterval_normal + Time.time;
        }
        if (Input.GetButton("Fire1") && Time.time > nextShootTime_homing)
        {
            
            for (int i=-1; i<=1; i+=2)
            { 
                bulletX = (GameObject)Instantiate(bullet_homing, transform.position, transform.rotation);
                bulletX.gameObject.AddComponent("PlayerBullet_Homing");
                bulletX.gameObject.GetComponent<PlayerBullet_Homing>().bulletSpeed = bulletSpeed / 2.0f;
                temp = transform.forward.normalized;
                temp.x = temp.x * Mathf.Cos(i * 30 / 180.0f * Mathf.PI) - temp.z * Mathf.Sin(i * 30 / 180.0f * Mathf.PI);
                temp.z = temp.x * Mathf.Sin(i * 30 / 180.0f * Mathf.PI) + temp.z * Mathf.Cos(i * 30 / 180.0f * Mathf.PI);
                
                bulletX.gameObject.GetComponent<PlayerBullet_Homing>().direction = temp.normalized;
                bulletX.gameObject.AddComponent("BulletInfo");
                bulletX.gameObject.GetComponent<BulletInfo>().Damage = 1.0f;
            }
            
            nextShootTime_homing = shootInterval_homing + Time.time;
        }
    }
}


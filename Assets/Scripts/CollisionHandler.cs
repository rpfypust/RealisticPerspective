using UnityEngine;
using System.Collections;

public class CollisionHandler : MonoBehaviour
{
    public string TagName; //Only trigger with which type of bullet
    
    void OnCollisionEnter(Collision collision)
    {
        if (!transform.gameObject.GetComponent<Status>().isInvicible)
        {
            if (collision.gameObject.tag == TagName)
            {
                //get damage
                float damage = collision.gameObject.GetComponent<BulletInfo>().Damage;
                transform.gameObject.GetComponent<Status>().HealthPoint -= damage;
        
                if (transform.gameObject.GetComponent<Status>().HealthPoint <= 0)
                {
                    transform.gameObject.GetComponent<Status>().HealthPoint = 0;
                    Destroy(transform.gameObject);
                    //handling death
                }
                Destroy(collision.gameObject);
            }
        }
        //}
    }
}


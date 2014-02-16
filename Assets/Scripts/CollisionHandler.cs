using UnityEngine;
using System.Collections;

public class CollisionHandler : MonoBehaviour
{
    public string TagName; //Only trigger with which type of bullet
    private Status status;

    void Awake()
    {
        status = transform.parent.gameObject.GetComponent<Status>();
    }
    
    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == TagName)
        {
            if (!status.isInvicible)
            {
                //get damage
                float damage = collision.gameObject.GetComponent<BulletInfo>().Damage;
                status.HealthPoint -= damage;
        
                if (status.HealthPoint <= 0)
                {
                    status.HealthPoint = 0;
                    Destroy(gameObject);
                    //handling death
                }
            }
            Destroy(collision.gameObject);
        }
        
    }
}


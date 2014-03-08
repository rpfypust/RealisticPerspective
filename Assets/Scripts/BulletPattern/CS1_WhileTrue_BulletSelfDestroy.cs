using UnityEngine;
using System.Collections;

public class CS1_WhileTrue_BulletSelfDestroy : MonoBehaviour
{
    private int count = 0;
    public int destroyColTime = 2;
    public GameObject boss;
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Tag_Wall")
        {
            count++;
            if (count >= destroyColTime)
            {
                boss.GetComponent<CS1_WhileTrue>().l++;
                GameObject.Destroy(gameObject);
            }
        }
    }
}
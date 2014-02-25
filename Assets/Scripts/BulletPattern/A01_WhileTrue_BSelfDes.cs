using UnityEngine;
using System.Collections;

public class A01_WhileTrue_BSelfDes : MonoBehaviour
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
                boss.GetComponent<Boss_Test>().l++;
                GameObject.Destroy(gameObject);
            }
        }
    }
}
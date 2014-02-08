using UnityEngine;
using System.Collections;

public class A01_BS_Error : MonoBehaviour
{

    public float startTime = Time.time;
    public float velocity = 2.0f;
    public Vector3 oriPos;
    public float lastTime = 0.0f;
    public float deltaTime = 0.0f;
    public bool canStartMoving = false;
    public bool isPassedPlayer = false;
    public GameObject boss;
    private int j = 0;
    private GameObject target;
    private Vector3 speed = Vector3.zero;

    void FixedUpdate()
    {
        float cTime = Time.time - startTime;
        deltaTime = cTime - lastTime;

        if (canStartMoving)
        {
            if (!isPassedPlayer)
            {
                target = GameObject.FindWithTag("Player");
                speed = (target.transform.position - transform.position).normalized * velocity;
                speed.y=0.0f;

            }
            if(speed.magnitude==0){
                target = GameObject.FindWithTag("Player");
                speed = (target.transform.position - transform.position).normalized * velocity;
                speed.y=0.0f;
            }
            
            transform.position = transform.position + speed * deltaTime;
        }

        lastTime = cTime;
    }

    void OnTriggerExit(Collider collider){
        if(collider.gameObject.name=="Boss_Test"){ //Tell boss this area already leave boss
            boss.GetComponent<Boss_Test>().k=94;
        }else if(collider.gameObject.tag=="Tag_Wall"){ // Tell boss this area already leave the stage
            boss.GetComponent<Boss_Test>().k=95;
            Destroy(gameObject,2.0f);
        }
    }

    void OnTriggerEnter(Collider collider){
        if(collider.gameObject.tag=="Player"){
            isPassedPlayer=true;
        }
    }
}


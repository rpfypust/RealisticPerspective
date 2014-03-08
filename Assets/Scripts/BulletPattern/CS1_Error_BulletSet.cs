using UnityEngine;
using System.Collections;

public class CS1_Error_BulletSet : MonoBehaviour
{

    public float startTime = Time.time;
    public float velocity = 2.0f;
    public Vector3 oriPos;
	private float lastTime = 0.0f;
	private float deltaTime = 0.0f;
    public bool canStartMoving = false;
    public bool isPassedPlayer = false;
    public GameObject boss;
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
        if((collider.transform.parent)&&(collider.transform.parent.gameObject.name=="Boss_CS")){ //Tell boss this area already leave boss
            boss.GetComponent<CS1_Error>().step=94;
        }else if(collider.gameObject.tag=="Tag_Wall"){ // Tell boss this area already leave the stage
            boss.GetComponent<CS1_Error>().step=95;
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider collider){
        if(collider.gameObject.tag=="Player"){
            isPassedPlayer=true;
        }
    }
}


using UnityEngine;
using System.Collections;

public class Boss_Phoenix_CameraZoomOut : MonoBehaviour
{
    //bullet information
    public float distance = 16.0f;
    public float height = 36.0f;
    public float focusZSlippage = 1.0f;
    private float Odistance;
    private float Oheight;
    private float OfocusZSlippage;
    public float startTime = Time.time;
    public float moveTime = 4.0f;
    private float lastTime = 0.0f;
    private float deltaTime = 0.0f;
    private Vector3 speed;
    
    void Awake()
    {
        startTime = Time.time;
        speed = Vector3.zero;
        Odistance = gameObject.GetComponent<CharFollow>().distance;
        Oheight = gameObject.GetComponent<CharFollow>().height;
        OfocusZSlippage = gameObject.GetComponent<CharFollow>().focusZSlippage;
    }

    void FixedUpdate()
    {
        float cTime = Time.time - startTime;
        deltaTime = cTime - lastTime;
        if (cTime >= moveTime)
        {
            Destroy(gameObject.GetComponent<Boss_Phoenix_CameraZoomOut>());
        } else
        {
            float ratio = 4.0f / moveTime / moveTime * (moveTime / 2.0f - Mathf.Abs(cTime - moveTime / 2.0f));
            gameObject.GetComponent<CharFollow>().distance += (distance - Odistance) * ratio * deltaTime;
            gameObject.GetComponent<CharFollow>().height += (height - Oheight) * ratio * deltaTime;
            gameObject.GetComponent<CharFollow>().focusZSlippage += (focusZSlippage - OfocusZSlippage) * ratio * deltaTime;
        }
        lastTime = cTime;
    }
    
}
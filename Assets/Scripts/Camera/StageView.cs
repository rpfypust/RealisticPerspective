using UnityEngine;
using System.Collections;

public class StageView : MonoBehaviour {

    public Transform target;

    [Range(10, 15)]
    public float distance = 11f;

    [Range(0f, Mathf.PI / 2)]
    public float theta = 0.7853982f; // 45 degrees

    public float damp = 4f;

    public float zSlippage = 0f;

    public void SetTarget(Transform t) {
        target = t;
    }

    void Start() {
        float desiredX = transform.position.x;
        float desiredZ = transform.position.z + distance * Mathf.Cos(theta);
        float desiredY = transform.position.y - distance * Mathf.Sin(theta);
        transform.LookAt(new Vector3(desiredX, desiredY, desiredZ));
    }
	
	void LateUpdate() {
        if (!target)
            return;
        float desiredX = target.position.x;
        float desiredZ = target.position.z - distance * Mathf.Cos(theta) + zSlippage;
        float desiredY = target.position.y + distance * Mathf.Sin(theta);

        Vector3 desiredPosition = new Vector3(desiredX, desiredY, desiredZ);
        transform.position = Vector3.Lerp(transform.position, desiredPosition, damp * Time.deltaTime);
	}
}

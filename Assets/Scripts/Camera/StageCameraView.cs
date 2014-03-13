using UnityEngine;

public class StageCameraView : MonoBehaviour {

    [Range(0, 15)]
    public float distance = 11f;

    [Range(0f, Mathf.PI / 2)]
    public float theta = 0.7853982f; // 45 degrees

    public float damp = 4f;

    public float zSlippage = 0f;

	private CameraManager cman;

	void Awake()
	{
		cman = GameObject.FindGameObjectWithTag(Tags.mainCamera).GetComponent<CameraManager>();
	}

    void Start() {
        float desiredX = transform.position.x;
        float desiredZ = transform.position.z + distance * Mathf.Cos(theta);
        float desiredY = transform.position.y - distance * Mathf.Sin(theta);
        transform.LookAt(new Vector3(desiredX, desiredY, desiredZ));
    }
	
	void LateUpdate() {
        transform.position = Vector3.Lerp(transform.position, getDesiredPosition(cman.target.position), damp * Time.deltaTime);
	}

    public Vector3 getDesiredPosition(Vector3 p) {
        float desiredX = p.x;
        float desiredZ = p.z - distance * Mathf.Cos(theta) + zSlippage;
        float desiredY = p.y + distance * Mathf.Sin(theta);
        
        return new Vector3(desiredX, desiredY, desiredZ);
    }
}

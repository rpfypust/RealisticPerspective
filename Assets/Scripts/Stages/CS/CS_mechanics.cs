using UnityEngine;
using System.Collections;

public class CS_mechanics : MonoBehaviour
{

    public Vector2 iceRinkOrigin;
    public int iceRinkWidth;
    public int iceRinkHeight;
    public int unitLength;
    public GameObject obstacle;
    public GameObject[] doors;
    public Vector2[] obstacleSet1;
    public Vector2[] obstacleSet2;
    public Vector2[] obstacleSet3;
    public Vector2[] obstacleSet4;

    private Vector2[] currentSet;
    private int currentSetNumber;
    private ArrayList obstacles;

    private CameraManager cameraManger;

    void Awake() {
        cameraManger = GameObject.FindGameObjectWithTag(Tags.mainCamera).GetComponent<CameraManager>();
    }
    
    void Start()
    {
        obstacles = new ArrayList();
        ChangeSetNumber(1);
    }

    void InitializeObstacles()
    {
        if (obstacles.Count > 0)
        {
            foreach (GameObject o in obstacles)
            {
                Destroy(o);
            }
            obstacles.Clear();
        }
        switch (currentSetNumber)
        {
            case 1:
                currentSet = obstacleSet1;
                break;
            case 2:
                currentSet = obstacleSet2;
                break;
            case 3:
                currentSet = obstacleSet3;
                break;
            case 4:
                currentSet = obstacleSet4;
                break;
        }
        for (int i = 0; i < currentSet.Length; i++)
        {
            obstacles.Add(GameObject.Instantiate(obstacle, 
                                   new Vector3(iceRinkOrigin.x + currentSet [i].x * unitLength, 0f, iceRinkOrigin.y + currentSet [i].y * unitLength), 
                                   Quaternion.identity));
        }
    }

    public void ChangeSetNumber(int n) {
        currentSetNumber = n;
        InitializeObstacles();
    }

    public IEnumerator OpenDoor(int n) {
        cameraManger.BeginCutScene();
        Vector3 targetBackup = cameraManger.target.position;
        // move camera to the door being opened
        yield return StartCoroutine(cameraManger.MoveCamera(doors[n - 1].transform.position, 1.0f));
        Destroy(doors[n - 1]);
        yield return new WaitForSeconds(1.0f);
        // move camera back to original target
        yield return StartCoroutine(cameraManger.MoveCamera(targetBackup, 1.0f));
        cameraManger.EndCutScene();
    }
}

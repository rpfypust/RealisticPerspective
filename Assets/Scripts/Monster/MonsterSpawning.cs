using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
public class MonsterSpawning : MonoBehaviour {
    public int maxNumMonsters = 1;
    public GameObject monsterPrefab;

	private BoxCollider collider;
	public Rect spawningRect;
    private Layers layers;
    private ArrayList monsters;

	void Awake() {
		collider = GetComponent<BoxCollider>();
		layers = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<Layers>();
	}
    
    void Start() {
        monsters = new ArrayList(maxNumMonsters);
		spawningRect = calculateBoundingRect();
    }

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.layer == layers.player) {
			spawn();
		}
	}

	void OnTriggerExit(Collider other) {
        if (other.gameObject.layer == layers.player) {
			destoryAll();
        } else if (other.gameObject.layer == layers.enemy) {
            Debug.Log("monster exits");
        }
	}
    
    private Vector3 randomPosition() {
		return Util.randomInsideRect(spawningRect).toVector3XZ();
	}
    
    private Quaternion randomOrientation() {
        return Quaternion.AngleAxis(Random.Range(0f, 359f), Vector3.up);
	}

	public void spawn() {
		if (monsters.Count < monsters.Capacity) {
			monsters.Add(MonsterFactory.createMonster(monsterPrefab, randomPosition(), randomOrientation(), spawningRect));
		}
	}

	public void destoryAll() {
		foreach (GameObject m in monsters) {
			Destroy(m);
		}
		monsters.Clear();
	}

	private Rect calculateBoundingRect() {
		float x = transform.position.x + collider.center.x - collider.size.x / 2;
		float y = transform.position.z + collider.center.z - collider.size.z / 2;
		float width = collider.size.x;
		float height = collider.size.z;
		return new Rect(x, y, width, height);
	}
}

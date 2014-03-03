using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SphereCollider))]
public class MonsterSpawning : MonoBehaviour {
    public int maxNumMonsters = 1;
    public float spawningRadius = 1f;
    public GameObject monster;

    private Layers layers;
    private ArrayList monsters;

	void Awake() {
		layers = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<Layers>();
	}
    
    void Start() {
        monsters = new ArrayList(maxNumMonsters);
    }

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.layer == layers.player) {
			// player enters the spawning area
            Debug.Log("player enters");
			spawn();
		}
	}

	void OnTriggerExit(Collider other) {
        if (other.gameObject.layer == layers.player) {
            // player exits the spawning area
            Debug.Log("player exits");
			destoryAll();
        } else if (other.gameObject.layer == layers.enemy) {
            Debug.Log("monster exits");
        }
	}
    
    private Vector3 randomPosition() {
        Vector2 p = Random.insideUnitCircle * spawningRadius;
        return transform.TransformPoint(new Vector3(p.x, 0f, p.y));
	}
    
    private Quaternion randomOrientation() {
        Quaternion q = Quaternion.AngleAxis(Random.Range(0f, 359f), Vector3.up);
        return q;
	}

	public bool spawn() {
		if (monsters.Count < monsters.Capacity) {
			monsters.Add(Instantiate(monster, randomPosition(), randomOrientation()));
			return true;
		}
		return false;
	}

	public void destoryAll() {
		foreach (GameObject m in monsters) {
			Destroy(m);
		}
		monsters.Clear();
	}
}

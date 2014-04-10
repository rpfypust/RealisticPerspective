using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(BoxCollider))]
public class MonsterSpawning : MonoBehaviour {

	public delegate void MonsterClearHandler();
	public event MonsterClearHandler OnMonsterClear;

    public int maxNumMonsters;
    public GameObject monsterPrefab;

	protected BoxCollider boxCollider;
	protected Rect spawningRect;

	protected List<GameObject> monsters;

	protected void Awake() {
		boxCollider = GetComponent<BoxCollider>();

		monsters = new List<GameObject>();
		spawningRect = calculateBoundingRect();
	}

	protected void OnTriggerEnter(Collider other) {
		if (other.tag == Tags.player) {
			spawn();
		}
	}

	protected void OnTriggerExit(Collider other)
	{
		if (other.tag == Tags.player)
			destroyAllMonsters();
	}

	protected void destroyAllMonsters()
	{
		foreach (GameObject o in monsters) {
			o.GetComponent<Monster>().OnMonsterDie -= OnMonsterDiedHandler;
			Destroy(o);
		}
		monsters.Clear();
	}
    
    protected Vector3 randomPosition() {
		return Util.randomInsideRect(spawningRect).toVector3XZ();
	}
    
    protected Quaternion randomOrientation() {
        return Quaternion.AngleAxis(Random.Range(0f, 359f), Vector3.up);
	}

	public virtual void spawn() {
		while (monsters.Count < maxNumMonsters) {
			GameObject obj = MonsterFactory.createMonster(monsterPrefab,
			                                              randomPosition(),
			                                              randomOrientation(),
			                                              spawningRect);
			Monster monster = obj.GetComponent<Monster>();
			monster.OnMonsterDie += OnMonsterDiedHandler;
			monsters.Add(obj);
		}
	}

	protected void OnMonsterDiedHandler(Monster m)
	{
		m.OnMonsterDie -= OnMonsterDiedHandler;
		maxNumMonsters--;
		if (!monsters.Remove(m.gameObject))
			Debug.Log("monster not found!");
		if (monsters.Count == 0 && OnMonsterClear != null)
			OnMonsterClear();
	}

	protected Rect calculateBoundingRect() {
		float x = transform.position.x + boxCollider.center.x - boxCollider.size.x / 2;
		float y = transform.position.z + boxCollider.center.z - boxCollider.size.z / 2;
		float width = boxCollider.size.x;
		float height = boxCollider.size.z;
		return new Rect(x, y, width, height);
	}
}

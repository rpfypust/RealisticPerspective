using UnityEngine;
using System.Collections;

public class FixedSpawning : MonsterSpawning {
	public Transform[] points;

	public override void spawn() {
		for (int i = 0; i < maxNumMonsters; i++) {
			GameObject obj = MonsterFactory.createMonster(monsterPrefab,
			                                            points[i].position,
			                                            Quaternion.identity,
			                                            spawningRect);
			Monster monster = obj.GetComponent<Monster>();
			monster.OnMonsterDie += OnMonsterDiedHandler;
			monsters.Add(obj);
		}
	}
}

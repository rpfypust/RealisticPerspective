using UnityEngine;
using System.Collections;

public static class MonsterFactory {
	public static GameObject createMonster(GameObject monsterType, Vector3 position, Quaternion rotation, Rect spawingRect) {
		GameObject baby = (GameObject) Object.Instantiate(monsterType, position, rotation);
		MonsterAI monsterAI = baby.GetComponent<MonsterAI>();
		monsterAI.movementBounds = spawingRect;
		return baby;
	}
}

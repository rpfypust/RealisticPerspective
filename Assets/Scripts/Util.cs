using UnityEngine;
using System.Collections;

public static class Util {

	public static Vector2 randomInsideRect(Rect r) {
		return new Vector2(Random.Range(r.xMin, r.xMax),
		                   Random.Range(r.yMin, r.yMax));
	}

	public static int countDigits(int number) {
		int digits = 0;
		while (number > 0) {
			number /= 10;
			digits++;
		}
		return digits;
	}

    public static void removeAllBulletsbyTag(string tagName){
        foreach(GameObject bullet in GameObject.FindGameObjectsWithTag(tagName)){
            GameObject.Destroy(bullet);
        }
    }
}

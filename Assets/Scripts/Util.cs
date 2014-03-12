using UnityEngine;
using System.Collections;

public static class Util {

	public static Vector2 randomInsideRect(Rect r) {
		return new Vector2(Random.Range(r.xMin, r.xMax),
		                   Random.Range(r.yMin, r.yMax));
	}

	public static int solveQuadratic(float a, float b, float c, out float r1, out float r2)
	{
		r1 = r2 = 0.0f; // C# does not allow out arguments left uninitialized before return
		float discriminant = b * b - 4 * a * c;
		if (discriminant < 0f)
			return -1;
		r1 = (-b + Mathf.Sqrt(discriminant)) / a / 2.0f;
		r2 = (-b - Mathf.Sqrt(discriminant)) / a / 2.0f;
		if (r1 != r2)
			return 1;
		return 0;
	}

    public static void removeAllBulletsbyTag(string tagName){
        foreach(GameObject bullet in GameObject.FindGameObjectsWithTag(tagName)){
            GameObject.Destroy(bullet);
        }
    }
}

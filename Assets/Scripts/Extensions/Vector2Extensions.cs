using UnityEngine;
using System.Collections;

public static class Vector2Extensions {
	/*
	 * map the x and y component of a 2D vector
	 * to the x and z component of a 3D vector
	 * respectively with y component of the 
	 * 3D vector set to 0
	 */
	public static Vector3 toVector3XZ(this Vector2 v2) {
		return new Vector3(v2.x, 0f, v2.y);
	}

	/*
	 * rotate this 2D vector counter-clockwise
	 * through an angle of theta radians
	 * about the origin
	 */
	public static Vector2 rotateBy(this Vector2 v2, float theta) {
		float x = v2.x;
		float y = v2.y;
		float cos = Mathf.Cos(theta);
		float sin = Mathf.Sin(theta);
		return new Vector2(x * cos - y * sin, x * sin + y * cos);
	}
}

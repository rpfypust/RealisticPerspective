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
}

using UnityEngine;
using System.Collections;

public static class Vector3Extensions {
	public static Vector2 toVector2XZ(this Vector3 v3)
	{
		return new Vector2(v3.x, v3.z);
	}
}

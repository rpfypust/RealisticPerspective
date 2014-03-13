using UnityEngine;
using System.Collections;

public static class BulletFactory {

	public static UniformMotion CreateUniformMotionBullet(Vector3 p, Vector3 v, float life)
	{
		GameObject obj = (GameObject) Object.Instantiate(Resources.Load<GameObject>(ResourcePath.UNIFORM_MOTION_BULLET),
		                                                 p,
		                                                 Quaternion.identity);
		obj.GetComponent<Suiside>().DestroyTime = life;
		UniformMotion um = obj.GetComponent<UniformMotion>();
		um.setVelocity(v);
		return um;
	}
}

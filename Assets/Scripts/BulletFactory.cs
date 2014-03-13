using UnityEngine;
using System.Collections;

public static class BulletFactory {

	private const string UNIFORM_MOTION_BULLET_PATH = "uniform_motion_bullet";

	public static UniformMotion CreateUniformMotionBullet(Vector3 p, Vector3 v, float life)
	{
		GameObject obj = (GameObject) Object.Instantiate(Resources.Load<GameObject>(UNIFORM_MOTION_BULLET_PATH),
		                                                 p,
		                                                 Quaternion.identity);
		obj.GetComponent<Suiside>().DestroyTime = life;
		UniformMotion um = obj.GetComponent<UniformMotion>();
		um.setVelocity(v);
		return um;
	}
}

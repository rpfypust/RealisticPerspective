using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/* GUIManager is reasponsible for managing
 * IDrawable objects. A Player, for example,
 * may implement the IDrawable interface
 * and register itself to draw its status
 * on the GUI
 */
public class GUIManager : MonoBehaviour {
	public const float width = 1920.0f;
	public const float height = 1080.0f;

	private Matrix4x4 m;
	private List<IDrawable> list = new List<IDrawable>();

	void Awake() {
		float widthRatio = Screen.width / width;
		float heightRatio = Screen.height / height;
		float scaleFactor = (widthRatio > heightRatio) ? heightRatio : widthRatio;
		m = Matrix4x4.TRS(Vector3.zero, 
		                  Quaternion.identity, 
		                  new Vector3(scaleFactor, scaleFactor, 1.0f));
	}

	private int priority(IDrawable idrawable)
	{
		if (idrawable.GetType() == typeof(Player)
		    || idrawable.GetType() == typeof(DummyBoss)
		    || idrawable.GetType() == typeof(Boss)) {
			return 0;
		} else if (idrawable.GetType() == typeof(HUD)) {
			return 1;
		} else if (idrawable.GetType() == typeof(Fader)) {
			return 2;
		} else {
			return 3;
		}
	}

	public bool register(IDrawable component) {
		if (!isRegistered(component)) {
			list.Add(component);
			list.Sort((x, y) => priority(x).CompareTo(priority(y)));
			return true;
		}
		return false;
	}

	public bool unregister(IDrawable component) {
		if (isRegistered(component)) {
			list.Remove(component);
			return true;
		}
		return false;
	}

	public bool isRegistered(IDrawable component) {
		return (list.Contains(component));
	}

	void OnGUI() {
		Matrix4x4 backup = GUI.matrix;
		GUI.matrix = m;
		foreach (IDrawable item in list) {
			item.DrawOnGUI();
		}
		GUI.matrix = backup;
	}
}

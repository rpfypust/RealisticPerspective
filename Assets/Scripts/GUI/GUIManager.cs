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
	public static float width = 1920.0f;
	public static float height = 1080.0f;

	Matrix4x4 m;
	private List<IDrawable> list = new List<IDrawable>();

	void Start() {
		float widthRatio = Screen.width / width;
		float heightRatio = Screen.height / height;
		float scaleFactor = (widthRatio > heightRatio) ? heightRatio : widthRatio;
		m = Matrix4x4.TRS(Vector3.zero, 
		                  Quaternion.identity, 
		                  new Vector3(scaleFactor, scaleFactor, 1.0f));
	}

	public bool register(IDrawable component) {
		if (!isRegistered(component)) {
			list.Add(component);
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

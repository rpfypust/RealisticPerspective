using UnityEngine;
using System.Collections;

public class Layers : MonoBehaviour {
    public int player;

    void Awake() {
        player = LayerMask.NameToLayer("11_Player");
    }
}

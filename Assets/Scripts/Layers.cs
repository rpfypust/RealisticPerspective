using UnityEngine;
using System.Collections;

public class Layers : MonoBehaviour {
    public int player;
    public int enemy;

    void Awake() {
        player = LayerMask.NameToLayer("11_Player");
        enemy = LayerMask.NameToLayer("10_Enemy");
    }
}

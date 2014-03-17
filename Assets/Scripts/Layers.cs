using UnityEngine;
using System.Collections;

public class Layers : MonoBehaviour {
    public int player;
    public int enemy;
	public int playerBullet;
	public int playerCollidableBullet;
	public int playerHitArea;
	public int enemyBullet;
	public int enemyCollidableBullet;

    void Awake() {
        player = LayerMask.NameToLayer("11_Player");
        enemy = LayerMask.NameToLayer("10_Enemy");
		playerBullet = LayerMask.NameToLayer("16_Player Bullets");
		playerHitArea = LayerMask.NameToLayer("12_Player Hit Area");
		enemyBullet = LayerMask.NameToLayer("14_Enemy Bullets");
		playerCollidableBullet = LayerMask.NameToLayer("17_Player Collidable Bullets");
		enemyCollidableBullet = LayerMask.NameToLayer("15_Enemy Collidable Bullets");
    }
}

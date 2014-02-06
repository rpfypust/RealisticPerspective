/* _01_CharacterMoveControl.js ----------------------------- By Henry Hsieh */

/* 變數宣告 */
//走路速度、跑步速度、跳躍速度、重力值、旋轉速度 : 浮點數值
//主角移動方向 : 3維數值(x, y, z)(隱匿宣告)

var TagName : String = "Tag_Bullet";
var cam : Camera;

static var getHit : int = 0;

function Start() 
{
	getHit = 0;
    Physics.IgnoreLayerCollision(14,14);
    Physics.IgnoreLayerCollision(14,8);
    Physics.IgnoreLayerCollision(14,11);
}

function OnCollisionEnter(collision : Collision)
{
	if(collision.gameObject.tag == TagName)
	{
		getHit++;
		Destroy(collision.gameObject);
	}
}

function OnGUI()
{

	var worldPosition : Vector3;
	worldPosition = Vector3(transform.position.x , transform.position.y ,transform.position.z);
	var position : Vector2;
	position = cam.WorldToScreenPoint(worldPosition);
	position = Vector2(position.x, Screen.height - position.y);

	var nameSize : Vector2;
	nameSize = GUI.skin.label.CalcSize(GUIContent(getHit.ToString()));
	GUI.color  = Color.red;
	GUI.Label(Rect(position.x - (nameSize.x/2),position.y - nameSize.y ,nameSize.x,nameSize.y), getHit.ToString());

}
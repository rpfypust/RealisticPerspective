/* _01_CharacterMoveControl.js ----------------------------- By Henry Hsieh */

/* 變數宣告 */
//走路速度、跑步速度、跳躍速度、重力值、旋轉速度 : 浮點數值
//主角移動方向 : 3維數值(x, y, z)(隱匿宣告)

var WalkSpeed : float = 5.0;
var RunSpeed : float = 10.0;
var SlowSpeed : float = 3.0;
var JumpSpeed : float = 8.0;
var Gravity : float = 20.0;
private var MoveDirection : Vector3 = Vector3.zero;
var cam : Camera;

/* 功能 : 持續執行 */
function Update() 
{
	//宣告主角控制器為自身的控制器元件。   
     var playerController : CharacterController = GetComponent(CharacterController);
   
   //如果主角在地面時
    if (playerController.isGrounded) 
    {
        //主角移動方向的Z軸數值，由輸入設定中的垂直鍵(WS鍵或上下鍵)來進行輸入。
        //主角移動方向由自身座標轉換為世界座標(維持旋轉後的控制方向正確)。
        //主角移動方向的量乘以行走速度。
        MoveDirection = Vector3(Input.GetAxis ("Horizontal"), 0,Input.GetAxis("Vertical"));
        
        //如果按下跑步鍵 --> 移動方向的量乘以跑步速度。
       /*if(Input.GetButton("Run"))
       {
       		MoveDirection *= RunSpeed;
       } */
       if(Input.GetButton("Slow"))
       {
       	MoveDirection *= SlowSpeed;
       }else{
       	
        MoveDirection *= WalkSpeed;
        
        //面向，smooth地轉面向的方向
        if(MoveDirection != Vector3(0,0,0)){
        	transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation(MoveDirection), 10 * Time.deltaTime);
        }
        //如果按下跳躍鍵 --> 主角移動方向的Y軸等於跳躍速度。
        if (Input.GetButton ("Jump")) 
        {
            MoveDirection.y = JumpSpeed;
        }
        
       }
    }

    //主角移動方向的Y軸數值，每秒持續減去重力值。
    MoveDirection.y -= Gravity * Time.deltaTime;
    
	//每秒持續移動主角 。
    playerController.Move(MoveDirection * Time.deltaTime);
    
}

function OnGUI()
{

	var worldPosition : Vector3;
	worldPosition = Vector3(transform.position.x , transform.position.y ,transform.position.z);
	var position : Vector2;
	position = cam.WorldToScreenPoint(worldPosition);
	position = Vector2(position.x, Screen.height - position.y);

	var nameSize : Vector2;
	nameSize = GUI.skin.label.CalcSize(GUIContent("test"));
	GUI.color  = Color.blue;
	GUI.Label(Rect(position.x - (nameSize.x/2),position.y ,nameSize.x,nameSize.y), "test");

}

/* 附加腳本時自動生成CharacterController元件 */
@script RequireComponent(CharacterController)
/* _02_CharacterAnimControl.js ----------------------------- By Henry Hsieh */

/* 變數宣告 */
//走路動畫速度、跑步動畫速度、跳躍動畫速度、跳躍混合速度、攻擊混合時間 : 浮點數值
var WalkAnimSpeed : float = 1.0;
var RunAnimSpeed : float = 1.0;
var JumpAnimSpeed : float =1.0;
var JumpBlendSpeed : float =1.0;
var AttackBlendTime : float =0.05;

/* 功能 : 遊戲初始化 */
//設定所有動畫的播放模式為重複 --> 設定攻擊動畫播放模式為單次 -->
//設定攻擊動畫的播放層次為1 --> 所有動畫預設為停止
function Start() 
{
    animation.wrapMode	=	WrapMode.Loop;
    animation["5_Attack"].wrapMode = WrapMode.Once;
    animation["5_Attack"].layer = 1;
    animation.Stop();
}

/* 功能 : 持續執行 */
function Update () 
{
	//如果輸入設定中的水平鍵(AD鍵或左右鍵)或是垂直鍵(WS鍵或上下鍵)數值大於絕對值0.2時(角色移動時)
    if ((Mathf.Abs(Input.GetAxis("Vertical")) > 0.2) || (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.2)) 
    {
        //如果按下跑步鍵時
        if(Input.GetButton("Run")) 
        {
            //漸變播放跑步動畫 --> 設定跑步動畫速度 -->
            //如果垂直鍵(WS鍵或上下鍵)的數值小於0.2(後退) -->設定跑步動畫的速度為負值
            animation.CrossFade("3_Run");
            animation["3_Run"].speed = RunAnimSpeed;
            if(Input.GetAxis("Vertical") < -0.2)
            {
            	animation["3_Run"].speed = -RunAnimSpeed;
            }
        }
        
        //如果不是按下跑步鍵時
        else
        {
            //漸變播放走路動畫 --> 設定走路動畫速度 -->
            //如果垂直鍵(WS鍵或上下鍵)的數值小於0.2(後退) -->設定走路動畫的速度為負值
            animation.CrossFade("2_Walk");
            animation["2_Walk"].speed = WalkAnimSpeed;
            if(Input.GetAxis("Vertical") < -0.2)
            {
            	animation["2_Walk"].speed =-WalkAnimSpeed;
            }
        }
    }
    
    //如果輸入設定中的水平鍵(AD鍵或左右鍵)或是垂直鍵(WS鍵或上下鍵)數值沒有大於絕對值0.2時(角色停止時)
    else
    {
        //漸變播放待機動畫
        animation.CrossFade("1_Idle");
    }
    
	//如果按下開火鍵時(Ctrl或滑鼠左鍵)
    if (Input.GetButtonDown("Fire1"))
    { 
        //漸變播放攻擊動畫，並設定攻擊動畫為立即播放，不須等待前一次動畫播放完畢
        animation.CrossFadeQueued("5_Attack", AttackBlendTime ,QueueMode.PlayNow);
    }

	//如果按下跳躍鍵時 --> 漸變播放跳躍動畫 --> 設定跳躍動畫的速度
	if(Input.GetButton("Jump"))
	{
		animation.CrossFade("4_Jump", JumpBlendSpeed);
		animation["4_Jump"].speed = JumpAnimSpeed;
	}

}
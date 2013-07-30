/* _08_Func_ThrowAxe.js -------------------------------- By Henry Hsieh */

/*變數宣告*/
//斧頭的來源 : 帶有Rigidbody元件的物件
//投射的 z 軸及 y 軸速度值 : 整數值
//投射聲 : 聲音檔
var Bullet : Rigidbody;
var PowerZ: int = 10;
var ThrowerSound : AudioClip;

/* 功能 : 持續執行 (投射) */
//如果發射狀態為(是) --> 當我們按下開火鍵(Fire1)時 -->於腳本附加的物件上動態產生一把斧頭 -->
 //給予方向及力量將其投射出去 --> 避開斧頭與自身的物理碰撞現象 --> 播放投射聲音。
function Update () 
{
	//if(_11_Trigger_MagicStage.FireStatus == true)
	//{
		if(Time.frameCount%1==0)
		{
			var temp = Mathf.Sin(Time.frameCount/40.0);
			var angle = temp*720.0/180.0*Mathf.PI;
			
			var AxeA : Rigidbody = Instantiate(Bullet, transform.position, transform.rotation);
			AxeA.velocity = transform.TransformDirection( Vector3(PowerZ*Mathf.Cos(angle), 0, PowerZ*Mathf.Sin(angle)) );
			AxeA.useGravity = false;
    		AxeA.detectCollisions = false;
    		var AxeB : Rigidbody = Instantiate(Bullet, transform.position, transform.rotation);
			AxeB.velocity = transform.TransformDirection( Vector3(-PowerZ*Mathf.Cos(angle), 0, -PowerZ*Mathf.Sin(angle)) );
			AxeB.useGravity = false;
    		AxeB.detectCollisions = false;
			//audio.PlayOneShot(ThrowerSound);
		}
	//}
}

/*附加腳本時自動生成AudioSource元件*/
@script RequireComponent(AudioSource)
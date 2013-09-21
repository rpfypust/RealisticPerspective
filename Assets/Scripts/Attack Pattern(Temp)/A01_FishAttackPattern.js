/* _08_Func_ThrowAxe.js -------------------------------- By Henry Hsieh */

/*變數宣告*/
//斧頭的來源 : 帶有Rigidbody元件的物件
//投射的 z 軸及 y 軸速度值 : 整數值
//投射聲 : 聲音檔
var Bullet : Rigidbody;
var PowerZ = 10.0;
var ThrowerSound : AudioClip;
var startTime = 0.0;
var lastTime = 0.0;
var j = 0;

/* 功能 : 持續執行 (投射) */
//如果發射狀態為(是) --> 當我們按下開火鍵(Fire1)時 -->於腳本附加的物件上動態產生一把斧頭 -->
 //給予方向及力量將其投射出去 --> 避開斧頭與自身的物理碰撞現象 --> 播放投射聲音。
function Awake(){
	startTime = Time.time;
	j = 0;
}
function FixedUpdate () 
{
	//if(_11_Trigger_MagicStage.FireStatus == true)
	//{
	
		if((Time.time-lastTime)>1/20.0)
		{
			var temp = Mathf.Sin(Time.frameCount/50.0);
			var angle = (temp*1640.0 +90.0)/180.0*Mathf.PI;
			var result = PowerZ;
			var BulletX : Rigidbody;
			for(i=0;i<6;i++){
				angle = Mathf.PI/36.0*(i*6+j) + j/100.0;
				BulletX = Instantiate(Bullet, transform.position, transform.rotation);
				BulletX.gameObject.AddComponent("A01_B1");
				BulletX.gameObject.GetComponent("A01_B1").startTime = Time.time;
				BulletX.gameObject.GetComponent("A01_B1").vx = result * Mathf.Cos(angle);
				BulletX.gameObject.GetComponent("A01_B1").vz = result * Mathf.Sin(angle);
				BulletX.gameObject.GetComponent("A01_B1").oriPos = transform.position;
				BulletX.useGravity = false;
				j++;
			}
			lastTime = Time.time;
    		//AxeA.detectCollisions = false;
    		
			//audio.PlayOneShot(ThrowerSound);
		}
	//}
}

/*附加腳本時自動生成AudioSource元件*/
@script RequireComponent(AudioSource)
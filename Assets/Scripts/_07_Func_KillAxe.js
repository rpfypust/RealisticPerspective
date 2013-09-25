/* _07_Func_KillAxe.js ------------------------------------------- By Henry Hsieh */

/*變數宣告*/
//消除時間 : 整數值
var DestroyTime : int = 8;

/*功能 : 持續執行*/
//當時間等於消除時間時，把自已(斧頭)消除掉。
function Awake () 
{
	Destroy(gameObject, DestroyTime);
}
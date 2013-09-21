var startTime = Time.time;
var vx = 0.0;
var vz = 0.0;
var oriPos : Vector3;
var lastTime = 0.0;
var deltaTime = 0.0;

function FixedUpdate () {
	var speed : Vector3 = Vector3 (vx, 0, vz);
	var cTime = Time.time-startTime;
	deltaTime = cTime - lastTime;
	if (cTime<1){
		//rigidbody.MovePosition(oriPos + speed*(cTime - cTime * cTime /2.0));
		rigidbody.MovePosition(rigidbody.position + speed * deltaTime * (1-cTime)/1.0);
	}else if (cTime<1.5){
	}else if (cTime<2.5){
		var temp = cTime-1.5;
		//rigidbody.MovePosition(oriPos + speed*(0.5 + temp * temp /2.0));
		rigidbody.MovePosition(rigidbody.position + speed * deltaTime * (cTime-1.5)/1.0);
	}else{
		//rigidbody.MovePosition(oriPos + speed*(1 + cTime - 2.5));
		rigidbody.MovePosition(rigidbody.position + speed * deltaTime);
	}
	lastTime = cTime;
}
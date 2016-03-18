#pragma strict

var FPS : Camera;
var TPS : Camera;

private var SwitchCamera : boolean = false;

function Start ()
{
  FPS.GetComponent.<Camera>().enabled = true;
  TPS.GetComponent.<Camera>().enabled = false;
}

function Update ()
{
   if(Input.GetKeyDown(KeyCode.Return)){
		SwitchCamera = !SwitchCamera;
		FPS.GetComponent.<Camera>().enabled = SwitchCamera;
		TPS.GetComponent.<Camera>().enabled = !SwitchCamera;
   }
}
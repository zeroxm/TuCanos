#pragma strict

var posicaoX: float;
var posicaoY: float;
var altura:   float;
var largura:  float;

var skin: GUISkin;

var controlePause: boolean;

function Start () {
	controlePause = true;
	largura = 300;
	altura = 60;
	posicaoX = Screen.width/2 - largura/2;
    posicaoY = Screen.height/2 - altura/2;
}

function Update () {
	if(Input.GetKeyDown(KeyCode.Escape)){
		if (controlePause){
			Time.timeScale = 0;
			controlePause = false;
		} else {
		    Time.timeScale = 1;
			controlePause = true;
		}
	}
}

function OnGUI(){
  
    GUI.skin = skin;
    
    if (!controlePause){
    	GUI.Box(Rect(0,0,Screen.width,Screen.height),"");
    
		if(GUI.Button(Rect(posicaoX,posicaoY + 25,largura,altura),"Start")){
			Time.timeScale = 1;
			controlePause = true;
		}
	
		if(GUI.Button(Rect(posicaoX,posicaoY + 100,largura,altura),"Exit")){
			Application.Quit();
		}
	}	
}
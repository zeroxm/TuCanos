#pragma strict

var posicaoX: float;
var posicaoY: float;
var altura:   float;
var largura:  float;

var skin: GUISkin;

function Start () {
	largura = 300;
	altura = 55;
	posicaoX = Screen.width/2 - largura/2;
    posicaoY = Screen.height/2 - altura/2;
}

function Update () {

}

function OnGUI(){

    GUI.skin = skin;
    
	if(GUI.Button(Rect(posicaoX,posicaoY + 20,largura,altura),"1p Game")){
		Application.LoadLevel("Level_01");
	}
	
	if(GUI.Button(Rect(posicaoX,posicaoY + 80,largura,altura),"2p Coop")){
		Application.LoadLevel("Level_01");
	}
	
	if(GUI.Button(Rect(posicaoX,posicaoY + 140,largura,altura),"Time Atack")){
		Application.LoadLevel("Level_01");
	}
	
	if(GUI.Button(Rect(posicaoX,posicaoY + 200,largura,altura),"Exit")){
		Application.Quit();
	}
}
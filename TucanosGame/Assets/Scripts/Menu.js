#pragma strict

var posicaoX: float;
var posicaoY: float;
var altura:   float;
var largura:  float;

var skin: GUISkin;

function Start () {
	largura = 300;
	altura = 60;
	posicaoX = Screen.width/2 - largura/2;
    posicaoY = Screen.height/2 - altura/2;
}

function Update () {

}

function OnGUI(){

    GUI.skin = skin;
    
	if(GUI.Button(Rect(posicaoX,posicaoY + 25,largura,altura),"Start")){
		Application.LoadLevel("Level_01");
	}
	
	if(GUI.Button(Rect(posicaoX,posicaoY + 100,largura,altura),"Exit")){
		Application.Quit();
	}
}
#pragma strict

var posicaoX: float;
var posicaoY: float;
var altura:   float;
var largura:  float;

var textoScore: UI.Text;

var skin: GUISkin;

function Start () {
	largura = 100;
	altura = 20;
	posicaoX = Screen.width/2 - largura/2;
    posicaoY = Screen.height/2 - altura/2;
}

function Update () {

}

function OnGUI(){

    GUI.skin = skin;
    
	if(GUI.Button(Rect(posicaoX,posicaoY,largura,altura),"Recomeçar")){
		Application.LoadLevel("MenuPrincipal");
	}
	
	if(GUI.Button(Rect(posicaoX,posicaoY + 25,largura,altura),"Sair")){
		Application.Quit();
	}
}
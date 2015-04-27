using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

	float posicaoX;
	float posicaoY;
	float altura;
	float largura;

	public GUISkin skin;

	bool controlePause;


	// Use this for initialization
	void Start () {
		controlePause = true;
		largura = 300;
		altura = 55;
		posicaoX = Screen.width/2 - largura/2;
		posicaoY = Screen.height/2 - altura/2;
	}
	
	// Update is called once per frame
	void Update () {
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


	void OnGUI(){
		GUI.skin = skin;

		if (!controlePause){
			GUI.Box(new Rect(0,0,Screen.width,Screen.height),"");
		if(GUI.Button(new Rect(posicaoX,posicaoY + 10,largura,altura),"Start")){
			Time.timeScale = 1;
			controlePause = true;
		}
		if(GUI.Button(new Rect(posicaoX,posicaoY + 75,largura,altura),"Restart")){
				Time.timeScale = 1;
				Application.LoadLevel(Application.loadedLevelName);
				//Application.restart();
		}
		if(GUI.Button(new Rect(posicaoX,posicaoY + 140,largura,altura),"Exit")){
				Application.LoadLevel("MenuTitulo");
			//Application.Quit();
		}
	}	
}

	public bool isPaused(){
		return !controlePause;
	}
}
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CreditzController : MonoBehaviour {

	Text[] text;
	int currentText;
	int textBefore;
	string[] titulos = new string[]{"",	"Programadores", "Design Grafico","Roteiro","Audio","Beta Testers","Inspiraçoes","Agradecimentos Especiais"};
	string[] conteudos = new string[]{"",	"Andre Xavier Martinez\nLuiz Correira Bohn Neto\nVictor Arruda Ganciar",
										"Andre Xavier Martinez\nCamila Rodrigues",
										"Andre Xavier Martinez\nLuiz Correira Bohn Neto\nVictor Arruda Ganciar",
										"Andre Xavier Martinez\nRodrigo da Silva Cardoso",
										"Rodrigo da Silva Cardoso\nAlvaro Silvestre\nEstela de Oliveira Guimaraes",
										"No more Heros 2 - Desperate Struggle\nMario Bros.\nNintendo - Sega",
										"UFABC GAMES\nMae\nAlynne Perricci Silva\nAdamarys Regina Freire\nEstela de Oliveira Guimaraes\nGeraldo Alkmin"};
	Animator creditsAnimator;

	// Use this for initialization
	void Start () {
		text = this.GetComponentsInChildren<Text> ();
		currentText = 0;
		creditsAnimator = this.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (creditsAnimator.GetCurrentAnimatorStateInfo (0).IsName ("CreditzLoop")) {
			textBefore= currentText;
		}
		text[0].text = titulos[currentText];
		text[1].text = conteudos[currentText];
		if (creditsAnimator.GetCurrentAnimatorStateInfo (0).IsName ("CreditzNext")&&currentText==textBefore) {
			currentText++;
		if(currentText >= titulos.Length)
				Application.LoadLevel("MenuTitulo");
		}


	}
}

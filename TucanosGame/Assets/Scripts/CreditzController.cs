using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CreditzController : MonoBehaviour {

	Text[] text;
	int currentText;
	int textBefore;
	string[] titulos = new string[]{"",	"Programadores", "Design Grafico","Roteiro","Audio","Animacoes","Beta Testers","Inspiracoes","Creditos Musicais","Creditos Musicais","Creditos Musicais","Agradecimentos Especiais"};
	string[] conteudos = new string[]{"",	"\nAndre Xavier Martinez\nLuiz Correira Bohn Neto\nVictor Arruda Ganciar",
										"\nAndre Xavier Martinez\nCamila Rodrigues",
										"\nAndre Xavier Martinez\nLuiz Correira Bohn Neto\nVictor Arruda Ganciar",
										"\nAndre Xavier Martinez\nRodrigo da Silva Cardoso",
										"\nAndre Xavier Martinez\nCamila Rodrigues\nVictor Arruda Ganciar",
										"\nRodrigo da Silva Cardoso\nAlvaro Silvestre\nEstela de Oliveira Guimaraes",
										"\nNo more Heros 2 - Desperate Struggle\nMario Bros.\nNintendo - Sega",
										"\nLay The Pipe - Type A\nLay The Pipe - Type B\nGo Straight - Streets of Rage 2\nBig Blue - F-Zero",
										"\nDragon Road - Sonic Unleashed\nRooftop Run - Sonic Generations\nExplorer - Collumns 3",
										"\nStage Clear - Super Mario World\nDonut Plains - Super Mario World\nEnding Credits - Sonic 3",
										"\nUFABC GAMES\nNossas Maes, Pais e Familias\nAlynne Perricci Silva\nAdamarys Regina Freire\nGeraldo Alkmin"};
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

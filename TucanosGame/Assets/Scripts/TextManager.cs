using UnityEngine;
using System.Collections;

public class TextManager : MonoBehaviour {

	string[] dialog;
	// Use this for initialization
	void Start () {
		if (Application.loadedLevelName.Equals("Intermission_00", System.StringComparison.OrdinalIgnoreCase)) {
			dialog = new string[]{"Buenos dias! \nGovernador Walkman!", 
				"Bom Dia Sr. Fontanero, que bom que voce veio, ouvi falar muito de voce, seus feitos sao lendarios",
				"Si, gracias, pero, o que esta havendo? \n\nAlgum problema com o abastecimento de agua da ciudad?",
				"Oh, nao, nao falta agua em Sao Paulo. Nao vai faltar agua em Sao Paulo.",
				"Que bueno, entao pra que me chamou?",
				"Nao vai faltar agua porque voce vai consertar o encanamento",
				"Oh...",
				"Hoje, nos perdemos cerca de 30% do que nos enviamos para a populaçao por causa de vazamentos na rede",
				"     30% ! \nIsso e basicamente um terço de tudo que voces mandam.",
				"Temos que fazer algo sobre isso, se nao pode virar uma calamidade",
				"Deixa comigo governador Walkman, mas avise las personas para economizar agua enquanto yo conserto",
				"Errr... entao... sobre isso...",
				"Sem enrrolacao, se estamos em um momento de crise, todos tem que fazer a sua parte para ajudar",
				"Bom, ok, comece daqui mesmo que eu ja começo pedindo para reduzirem co consumo de agua no palacio",
				"Ok, ja vou começar entao!"
			};
		}
		if (Application.loadedLevelName.Equals("Intermission_02", System.StringComparison.OrdinalIgnoreCase)) {
			dialog = new string[]{"Hola! \nAqui es el barrio de la Liberdad?", 
				"Oh, Hai!\nVoce eh o senhor Fontanero-San, ne?",
				"Si, soy yo! \nVim consertar o encanamento",
				"Que bom! Essa calçada tava ficando imunda, ne?\nJa vou pegar a mangueira",
				"Oh no no!! Nao use mangueira, 15 minutos com ela aberta sao quase 150 litros!",
				"Mas e tao mais facil, ne...",
				"Se precisar use um balde para o enxaguar, ou a agua que sobra depois de lavar a roupa",
				"Ok, e melhor do que nao ter agua, ne?",
				"Donde fica la entrada para los canos?",
				"Ahh, ali atras, e so seguir em frente, ne?",
				"Gracias, me voy"
			};
		}
		if (Application.loadedLevelName.Equals("Intermission_01", System.StringComparison.OrdinalIgnoreCase)) {
			dialog = new string[]{"Buenos dias!", 
				"Buon Giorno!",
				"Me parece europeo, tu eres espanhol?",
				"No, no, io sou italiano",
				"Ahh si, bueno, vim resolver lo problema com los encanamentos,",
				"Ahh que bene, meu carro estava ficando imundo! Ja faz uma semana que nao lavo ele",
				"Oh, no, no!\nEm epocas de pouca agua nao podemos gastar tanto assim, lavar o carro so uma vez por mes",
				"Mas a Ferrari fica tao bonita depois de uma lavagem...",
				"Nada disso! Ela bebe gasolina, no agua.\nE quando for lavar, faça isso usando um balde",
				"Mas da mais trabalho",
				"Una mangueira aberta durante a lavagem de um carro gasta 600 Litros, isso e o que uma pessoa precisa para viver por 1 semana!",
				"Ok, ok, isso e muita coisa",
				"Que bom que voce entende, bueno, por onde yo começo?",
				"Ahh, logo aqui atras fica a entrada para os encanamentos",
				"Gracias, bueno, me boy!"
			};
		}
		if (Application.loadedLevelName.Equals("Intermission_03", System.StringComparison.OrdinalIgnoreCase)) {
			dialog = new string[]{"Buenas tardes!", 
				"Boa tarde!",
				"Yo vim para consertar los encanamentos.",
				"Ahh, sim, eu ouvi falar, 30% com vazamentos, que loucura",
				"Tu no pareces muito afetado por isso",
				"Ahh sim, de onde eu venho nos ja sofremos com escasses de agua, entao, a gente aprende desde cedo a economizar e usar bem",
				"Entendo, sinto mucho por isso",
				"Ahh nao precisa, poderia acontecer em qualquer lugar do mundo, e ja acontece em outros pontos do pais",
				"Eh verdade, lo problema eh que quando se tem mucho de algo, so se preocupa com sua falta quando ja esta acabando",
				"E mesmo pequenas perdas de recursos podem causar grandes problemas a longo prazo",
				"Una mangueira aberta durante a lavagem de um carro gasta 600 Litros, isso e o que uma pessoa precisa para viver por 1 semana!",
				"Ok, ok, isso e muita coisa",
				"Que bom que voce entende, bueno, por onde yo começo?",
				"Ahh, logo aqui atras fica a entrada para os encanamentos",
				"Gracias, bueno, me boy!"
			};
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

		public string[] getDialog(){
			return this.dialog;
		}
}

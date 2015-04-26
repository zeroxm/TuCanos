using UnityEngine;
using System.Collections;

public class TextManager : MonoBehaviour {

	string[] dialog;
	// Use this for initialization
	void Start () {
		if (Application.loadedLevelName.Equals("Intermission_02", System.StringComparison.OrdinalIgnoreCase)) {
			dialog = new string[]{"Hola! \n Aqui es el barrio de la Liberdad?", "Oh, Hai, voce eh o Fontanero-San?"};
	
	}

	}
	
	// Update is called once per frame
	void Update () {
	
	}

		public string[] getDialog(){
			return this.dialog;
		}
}

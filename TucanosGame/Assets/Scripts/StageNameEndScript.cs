using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StageNameEndScript : MonoBehaviour {
	Text text;
	// Use this for initialization
	void Start () {
		text = this.GetComponent<Text> ();
		text.text = Application.loadedLevelName+" - Completo!";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

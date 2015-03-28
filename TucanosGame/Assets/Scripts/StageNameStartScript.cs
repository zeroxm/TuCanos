using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StageNameStartScript : MonoBehaviour {
	Text text;
	// Use this for initialization
	void Start () {
		text = this.GetComponent<Text> ();
		text.text = Application.loadedLevelName+" - Start!";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NextStageManager : MonoBehaviour {

	string nextStage;
	// Use this for initialization
	void Start () {
		nextStage = Application.loadedLevelName;
		if (nextStage.Equals ("Level_01")) {
			nextStage = "Level_02";
		}
		else if (nextStage.Equals ("Level_02")) {
			nextStage = "MenuPrincipal";
		}
		else if (nextStage.Equals ("Level_03")) {
			nextStage = "Level_04";
		}
		else if (nextStage.Equals ("MenuPrincipal")) {
			nextStage = "Level_01";
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public string getNextStage(){
		return nextStage;
	}
}

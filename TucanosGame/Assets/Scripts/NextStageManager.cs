using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NextStageManager : MonoBehaviour {

	string nextStage;
	// Use this for initialization
	void Start () {
		nextStage = Application.loadedLevelName;
		if (nextStage.Equals ("Intermission_00")) {
			nextStage = "Level_01";
		}
		else if (nextStage.Equals ("Level_01")) {
			nextStage = "Level_02";
		}
		else if (nextStage.Equals ("Level_02")) {
			nextStage = "Intermission_01";
		}
		else if (nextStage.Equals ("Intermission_01")) {
			nextStage = "Level_03";
		}
		else if (nextStage.Equals ("Level_03")) {
			nextStage = "Level_04";
		}
		else if (nextStage.Equals ("Level_04")) {
			nextStage = "Intermission_02";
		}
		else if (nextStage.Equals ("Intermission_02")) {
			nextStage = "Level_05";
		}
		else if (nextStage.Equals ("Level_05")) {
			nextStage = "Level_06";
		}
		else if (nextStage.Equals ("Level_06")) {
			nextStage = "Intermission_03";
		}
		else if (nextStage.Equals ("Intermission_03")) {
			nextStage = "Level_07";
		}
		else if (nextStage.Equals ("Level_07")) {
			nextStage = "Level_08";
		}
		else if (nextStage.Equals ("Level_08")) {
			nextStage = "EndGame";
		}
		else if (nextStage.Equals ("EndGame")) {
			nextStage = "Creditz";
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public string getNextStage(){
		return nextStage;
	}
}

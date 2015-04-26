using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	int bluePipes;
	int greenPipes;
	int timeDecay;
	int perfect;
	Text text;
	string nextStage;
	string totalScore;

	// Use this for initialization
	void Start () {
		nextStage = Application.loadedLevelName;
		if (nextStage.Equals ("Level_01")||(nextStage.Equals ("Level_02"))) {
			perfect = 30;
		}
		else if (nextStage.Equals ("Level_03")||(nextStage.Equals ("Level_04"))) {
			perfect = 40;
		}
		else if (nextStage.Equals ("Level_05")||(nextStage.Equals ("Level_06"))) {
			perfect = 50;
		}
		else if (nextStage.Equals ("Level_07")||(nextStage.Equals ("Level_08"))) {
			perfect = 70;
		}
		bluePipes = 0;
		greenPipes = -2;
		timeDecay = 0;
		text = GetComponent <Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		totalScore = greenPipes+"x 1000 \n"+bluePipes+" x 500 \n"+timeDecay+" x 50 x -1\nTotal - "+(greenPipes*1000+bluePipes*500-timeDecay*50);
		if (greenPipes + bluePipes == perfect) {
			totalScore += "\nPERFECT!!";
		}
		text.text = totalScore;
	
	}

	public void addBlue(){
		bluePipes++;
	}

	public void addGreen(){
		greenPipes++;
	}

	public void setTimeDecay(int time){
		timeDecay = time;
	}
}

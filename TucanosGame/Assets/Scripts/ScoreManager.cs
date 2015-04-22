using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	int bluePipes;
	int greenPipes;
	int timeDecay;
	Text text;

	// Use this for initialization
	void Start () {
		bluePipes = 0;
		greenPipes = -2;
		timeDecay = 0;
		text = GetComponent <Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		text.text = greenPipes+"x 1000 \n"+bluePipes+" x 500 \n"+timeDecay+" x 50 x -1\n\nTotal - "+(greenPipes*1000+bluePipes*500-timeDecay*50);
	
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

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AnimationMonitor : MonoBehaviour {

	public GameObject speechBubble;
	Animator mainAnimator;
	TextManager tm;
	string[] dialog;
	bool isTalking;
	bool dialogOver;
	bool isEndgame;
	public bool isFontaneiro;
	Animator speechAnimator;
	int currentText;
	Text bubbleText;
	NextStageManager nextStage;


	// Use this for initialization
	void Start () {
		mainAnimator = this.GetComponent<Animator> ();
		tm = this.GetComponent<TextManager> ();
		dialog = tm.getDialog ();
		dialogOver = false;
		isFontaneiro = true;
		speechAnimator = speechBubble.GetComponent<Animator> ();
		currentText = 0;
		speechAnimator.SetBool ("isFontanero", isFontaneiro);
		bubbleText = speechBubble.GetComponentInChildren<Text>();
		nextStage = this.GetComponent<NextStageManager> ();
		isEndgame = Application.loadedLevelName.Equals ("EndGame");

	}
	
	// Update is called once per frame
	void Update () {
		if (!dialogOver &&(mainAnimator.GetCurrentAnimatorStateInfo (0).IsName ("Intermission00_talk") || mainAnimator.GetCurrentAnimatorStateInfo (0).IsName ("Intermission01_talk") || mainAnimator.GetCurrentAnimatorStateInfo (0).IsName ("Intermission02_talk") || mainAnimator.GetCurrentAnimatorStateInfo (0).IsName ("Intermission03_talk"))) {
			isTalking = true;
			bubbleText.text = dialog [currentText];
		}
		if (isTalking && !dialogOver && Input.GetButtonDown ("Jump")) {
			currentText++;
			nextText();
		}
		if(dialogOver)
			if(isEndgame)
			mainAnimator.SetTrigger("endGameWalkAway");
			else
			mainAnimator.SetTrigger("dialogOver");
		if (Input.GetButtonDown ("Fire1") || (mainAnimator.GetCurrentAnimatorStateInfo (0).IsName ("Intermission00_nextLevel") || mainAnimator.GetCurrentAnimatorStateInfo (0).IsName ("Intermission01_nextLevel") || mainAnimator.GetCurrentAnimatorStateInfo (0).IsName ("Intermission02_nextLevel") || mainAnimator.GetCurrentAnimatorStateInfo (0).IsName ("Intermission03_nextLevel")))
			Application.LoadLevel(nextStage.getNextStage());

	}

	void nextText(){
		if (dialog.Length == currentText) {
			bubbleText.text = "";
			dialogOver = true;
		} else {
			isFontaneiro = !isFontaneiro;
			speechAnimator.SetBool ("isFontanero", isFontaneiro);
			bubbleText.text = dialog [currentText];
		}



	}




	
}

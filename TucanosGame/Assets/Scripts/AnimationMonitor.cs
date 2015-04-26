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
	public bool isFontaneiro;
	Animator speechAnimator;
	int currentText;
	Text bubbleText;

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
			mainAnimator.SetTrigger("dialogOver");
	}

	void nextText(){
		if (dialog.Length == currentText) {
			dialogOver = true;
		} else {
			isFontaneiro = !isFontaneiro;
			speechAnimator.SetBool ("isFontanero", isFontaneiro);
			bubbleText.text = dialog [currentText];
		}



	}




	
}

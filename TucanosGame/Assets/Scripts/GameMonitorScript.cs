using UnityEngine;
using System.Collections;

public class GameMonitorScript : MonoBehaviour {

	public int xConvertionFactor;
	public int zConvertionFactor;
	public int horizontalSize;
	public int verticalSize;
	public PlayerMovement playerMovement;
	public ScoreManager scoreManager;
	public TimerManager timerManager;
	public Animator hudAnimator;
	const int empty = 0;
	const int start = 1;
	const int verticalPipe = 2;
	const int horizontalPipe = 3;
	const int upRightCorner = 4;
	const int rightDownCorner = 5;
	const int downleftCorner = 6 ;
	const int leftUpCorner = 7;
	const int verticalEnd = 8;
	const int horizontalEnd = 9;
	const int upRightEnd = 10;
	const int rightDownEnd = 11;
	const int downleftEnd = 12;
	const int leftUpEnd = 13;
	MatrixManager mm;	
	AudioSource[] audioSources; 
	NextStageManager nextStage;
	int[,] numbers;
	bool winner;

		// Use this for initialization
	void Start () {
		winner = false;
		mm = this.GetComponent<MatrixManager> ();
		numbers = mm.getMatrix ();
		audioSources = this.GetComponents<AudioSource> ();
		nextStage = this.GetComponent<NextStageManager> ();
	}
	
	// Update is called once per frame
	void Update () {
			if (hudAnimator.GetCurrentAnimatorStateInfo (0).IsName ("GameFinishWin")) 
			winner = true;
			if (winner && hudAnimator.GetCurrentAnimatorStateInfo (0).IsName ("GameFinishWinWaitScreen") && Input.GetButtonDown ("Jump")) {
			hudAnimator.SetTrigger ("NextStage");
			}
			if (winner && hudAnimator.GetCurrentAnimatorStateInfo (0).IsName ("GameFadeOut")) {	
				//Something to add while the game fades out
			}
			if (hudAnimator.GetCurrentAnimatorStateInfo (0).IsName ("GameFinishLoseWaitScreen") && Input.GetButtonDown ("Jump")) {
			Application.LoadLevel(Application.loadedLevelName);
			}
			if (hudAnimator.GetCurrentAnimatorStateInfo (0).IsName ("NextStage")) 
			Application.LoadLevel(nextStage.getNextStage());
	}

	public void setPipe(Vector3 position, int pipeType){
		numbers[zConvertionFactor-Mathf.RoundToInt(position.z),Mathf.RoundToInt(position.x)-xConvertionFactor]=pipeType;
		didIWin ();
	}

	public void getPipe(Vector3 position){
		numbers[zConvertionFactor-Mathf.RoundToInt(position.z),Mathf.RoundToInt(position.x)-xConvertionFactor]=empty;
	}

	public void didIWin(){
		int cursorZ = 0;
		int cursorX = 0;
		bool canWalk = true;
		cursorZ++;
		if(canIGoDown(cursorZ,cursorX)){
			goDown (cursorZ, cursorX);
		}
	}


	void goDown(int cursorZ, int cursorX){
		if (numbers [cursorZ, cursorX] == verticalEnd 
		    || numbers [cursorZ, cursorX] == upRightEnd
		    || numbers [cursorZ, cursorX] == leftUpEnd) {
			startGameWinningProcess();
		} else if (numbers [cursorZ, cursorX] == verticalPipe) {
			cursorZ++;
			if (canIGoDown (cursorZ, cursorX))
				goDown (cursorZ, cursorX);
		} else if (numbers [cursorZ, cursorX] == upRightCorner) {
			cursorX++;
			if (canIGoRight (cursorZ, cursorX))
				goRight (cursorZ, cursorX);
		} else if (numbers [cursorZ, cursorX] == leftUpCorner) {
			cursorX--;
			if (canIGoLeft (cursorZ, cursorX))
				goLeft (cursorZ, cursorX);
		}
	}

	void goUp(int cursorZ, int cursorX){
		if (numbers [cursorZ, cursorX] == verticalEnd 
		    || numbers [cursorZ, cursorX] == rightDownEnd
		    || numbers [cursorZ, cursorX] == downleftEnd) {
			startGameWinningProcess();
		} else if (numbers [cursorZ, cursorX] == verticalPipe) {
			cursorZ--;
			if (canIGoUp (cursorZ, cursorX))
				goUp (cursorZ, cursorX);
		} else if (numbers [cursorZ, cursorX] == rightDownCorner) {
			cursorX++;
			if (canIGoRight (cursorZ, cursorX))
				goRight (cursorZ, cursorX);
		} else if (numbers [cursorZ, cursorX] == downleftCorner) {
			cursorX--;
			if (canIGoLeft (cursorZ, cursorX))
				goLeft (cursorZ, cursorX);
		}
	}

	void goLeft(int cursorZ, int cursorX){
		if (numbers [cursorZ, cursorX] == horizontalEnd
		    || numbers [cursorZ, cursorX] == upRightEnd
		    || numbers [cursorZ, cursorX] == rightDownEnd) {
			startGameWinningProcess();
		} else if (numbers [cursorZ, cursorX] == horizontalPipe) {
			cursorX--;
			if (canIGoLeft(cursorZ, cursorX))
				goLeft(cursorZ, cursorX);
		} else if (numbers [cursorZ, cursorX] == rightDownCorner) {
			cursorZ++;
			if (canIGoDown (cursorZ, cursorX))
				goDown(cursorZ, cursorX);
		} else if (numbers [cursorZ, cursorX] == upRightCorner) {
			cursorZ--;
			if (canIGoUp (cursorZ, cursorX))
				goUp (cursorZ, cursorX);
		}
	}

	void goRight(int cursorZ, int cursorX){
		if (numbers [cursorZ, cursorX] == horizontalEnd
		    || numbers [cursorZ, cursorX] == downleftEnd
		    || numbers [cursorZ, cursorX] == leftUpEnd) {
			startGameWinningProcess();
		} else if (numbers [cursorZ, cursorX] == horizontalPipe) {
			cursorX++;
			if (canIGoRight(cursorZ, cursorX))
				goRight(cursorZ, cursorX);
		} else if (numbers [cursorZ, cursorX] == downleftCorner) {
			cursorZ++;
			if (canIGoDown (cursorZ, cursorX))
				goDown(cursorZ, cursorX);
		} else if (numbers [cursorZ, cursorX] == leftUpCorner) {
			cursorZ--;
			if (canIGoUp (cursorZ, cursorX))
				goUp (cursorZ, cursorX);
		}
	}

	public bool canIGoDown(int cursorZ, int cursorX){
		if (cursorX < 0 || cursorZ < 0 || cursorX > (horizontalSize-1) || cursorZ > (verticalSize-1)) {
			return false;
		}
		if (numbers [cursorZ, cursorX]==verticalPipe 
		    || numbers [cursorZ, cursorX]==upRightCorner
		    || numbers [cursorZ, cursorX]==leftUpCorner
		    || numbers [cursorZ, cursorX]==verticalEnd
		    || numbers [cursorZ, cursorX] == upRightEnd
		    || numbers [cursorZ, cursorX] == leftUpEnd
		    || numbers [cursorZ, cursorX] == start) {
			return true;
		}
		else
			return false;
	}

	public bool canIGoUp(int cursorZ, int cursorX){
		if (cursorX < 0 || cursorZ < 0 || cursorX > (horizontalSize-1) || cursorZ > (verticalSize-1)) {
			return false;
		}
		if (numbers [cursorZ, cursorX]==verticalPipe 
		    || numbers [cursorZ, cursorX]==downleftCorner
		    || numbers [cursorZ, cursorX]==rightDownCorner
		    || numbers [cursorZ, cursorX]==verticalEnd
		    || numbers [cursorZ, cursorX] == rightDownEnd
		    || numbers [cursorZ, cursorX] == downleftEnd) {
			return true;
		}
		else
			return false;
	}

	public bool canIGoLeft(int cursorZ, int cursorX){
		if (cursorX < 0 || cursorZ < 0 || cursorX > (horizontalSize-1) || cursorZ > (verticalSize-1)) {
			return false;
		}
		if (numbers [cursorZ, cursorX]==horizontalPipe 
		    || numbers [cursorZ, cursorX]==rightDownCorner
		    || numbers [cursorZ, cursorX]==upRightCorner
		    || numbers [cursorZ, cursorX] == horizontalEnd
		    || numbers [cursorZ, cursorX] == upRightEnd
		    || numbers [cursorZ, cursorX] == rightDownEnd) {
			return true;
		}
		else
			return false;
	}

	public bool canIGoRight(int cursorZ, int cursorX){

		if (cursorX < 0 || cursorZ < 0 || cursorX > (horizontalSize-1) || cursorZ > (verticalSize-1)) {
			return false;
		}
		if (numbers [cursorZ, cursorX]==horizontalPipe 
		    || numbers [cursorZ, cursorX]==leftUpCorner
		    || numbers [cursorZ, cursorX]==downleftCorner
		    || numbers [cursorZ, cursorX] == horizontalEnd
		    || numbers [cursorZ, cursorX] == downleftEnd
		    || numbers [cursorZ, cursorX] == leftUpEnd) {
			return true;
		}
		else
			return false;
	}

	public int getPipeAt(int x, int z){
		return numbers [z, x];
	}

	void startGameWinningProcess()
	{
		playerMovement.disable ();
		audioSources [0].Stop ();
		scoreManager.setTimeDecay(timerManager.stop ());
		audioSources [1].Play ();
		hudAnimator.SetTrigger ("Win");
	}

	public void gameLoseProcess(){
		playerMovement.disable ();
		audioSources [0].Stop ();
		timerManager.stop ();
		audioSources [3].Play ();
		hudAnimator.SetTrigger ("Lose");
	}

	public bool isWinner(){
		return winner;
	}

	public void addBlue(){
		scoreManager.addBlue ();
	}

	public void addGreen(){
		scoreManager.addGreen ();
	}
}

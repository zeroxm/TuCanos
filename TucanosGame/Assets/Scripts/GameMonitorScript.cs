﻿using UnityEngine;
using System.Collections;

public class GameMonitorScript : MonoBehaviour {

	public int xConvertionFactor;
	public int zConvertionFactor;
	bool winner=false;
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



	public int[,] numbers = new int[10, 6] { 	{1, 0, 0, 0, 6, 8},
										{2, 0, 0, 0, 2, 0},
										{0, 0, 2, 0, 0, 0},
										{2, 0, 2, 0, 2, 0},
										{2, 0, 2, 0, 4, 7},
										{0, 0, 2, 0, 0, 0},
										{0, 0, 0, 0, 0, 0},
										{0, 0, 0, 0, 0, 0},
										{2, 0, 0, 0, 0, 0},
										{4, 3, 0, 0, 0, 0}};
	 



		// Use this for initialization
	void Start () {
			
	}
	
	// Update is called once per frame
	void Update () {

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
		if (numbers [cursorZ, cursorX] == verticalEnd) {
			winner = true;
			Debug.Log (winner);
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
		if (numbers [cursorZ, cursorX] == verticalEnd) {
			winner = true;
			Debug.Log (winner);
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
		if (numbers [cursorZ, cursorX] == verticalEnd) {
			winner = true;
			Debug.Log (winner);
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
		if (numbers [cursorZ, cursorX] == verticalEnd) {
			winner = true;
			Debug.Log (winner);
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

	bool canIGoDown(int cursorZ, int cursorX){
		if (cursorX < 0 || cursorZ < 0 || cursorX > 5 || cursorZ > 9) {
			return false;
		}
		if (numbers [cursorZ, cursorX]==verticalPipe 
		    || numbers [cursorZ, cursorX]==upRightCorner
		    || numbers [cursorZ, cursorX]==leftUpCorner
		    || numbers [cursorZ, cursorX]==verticalEnd) {
			return true;
		}
		else
			return false;
	}

	bool canIGoUp(int cursorZ, int cursorX){
		if (cursorX < 0 || cursorZ < 0 || cursorX > 5 || cursorZ > 9) {
			return false;
		}
		if (numbers [cursorZ, cursorX]==verticalPipe 
		    || numbers [cursorZ, cursorX]==downleftCorner
		    || numbers [cursorZ, cursorX]==rightDownCorner
		    || numbers [cursorZ, cursorX]==verticalEnd) {
			return true;
		}
		else
			return false;
	}

	bool canIGoLeft(int cursorZ, int cursorX){
		if (cursorX < 0 || cursorZ < 0 || cursorX > 5 || cursorZ > 9) {
			return false;
		}
		if (numbers [cursorZ, cursorX]==horizontalPipe 
		    || numbers [cursorZ, cursorX]==rightDownCorner
		    || numbers [cursorZ, cursorX]==upRightCorner
		    || numbers [cursorZ, cursorX]==verticalEnd) {
			return true;
		}
		else
			return false;
	}

	bool canIGoRight(int cursorZ, int cursorX){
		if (cursorX < 0 || cursorZ < 0 || cursorX > 5 || cursorZ > 9) {
			return false;
		}
		if (numbers [cursorZ, cursorX]==horizontalPipe 
		    || numbers [cursorZ, cursorX]==leftUpCorner
		    || numbers [cursorZ, cursorX]==downleftCorner
		    || numbers [cursorZ, cursorX]==verticalEnd) {
			return true;
		}
		else
			return false;
	}
}

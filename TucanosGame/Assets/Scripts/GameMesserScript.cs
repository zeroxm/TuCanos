using UnityEngine;
using System.Collections;

public class GameMesserScript : MonoBehaviour {

	public TimerManager timeManager;
	public GameObject water;
	public GameMonitorScript gms;
	public bool movingHorizontally;
	public bool goingDown;
	public bool goingLeft;
	public int currentTime = 0;
	public int currentPipe;
	public int index; // 1 - for the first half     2 - for the other half
	public int xConvertionFactor;
	public int zConvertionFactor;
	public int cursorX=0;
	public int cursorZ=0;
	public int timeInt;

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



	// Use this for initialization
	void Start () {
		index = 1;
		gms = this.GetComponent<GameMonitorScript> ();
		xConvertionFactor = gms.xConvertionFactor;
		zConvertionFactor = gms.zConvertionFactor;
		movingHorizontally = false;
		goingDown = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (((int)timeManager.getCurrentTime()) % 4 == 0 && currentTime!=(int)timeManager.getCurrentTime()) 
		{
			currentTime = (int)timeManager.getCurrentTime();
			spawnWaterElement();
		}
	
	}

	void spawnWaterElement(){
		currentPipe = gms.getPipeAt (cursorX, cursorZ);
		if (index == 1) {
			if (!movingHorizontally) {
				if (goingDown) {
					if(gms.canIGoDown(cursorZ,cursorX)){
						Instantiate (water,new Vector3(xConvertionFactor+cursorX,2f,zConvertionFactor-cursorZ+0.25f), new Quaternion (90,0,0,90));
						index =2;
					}
					else {
						Debug.Log("YouLose");
					}

				} else {
					if(gms.canIGoUp(cursorZ,cursorX)){
						Instantiate (water,new Vector3(xConvertionFactor+cursorX,2f,zConvertionFactor-cursorZ-0.25f), new Quaternion (90,0,0,90));
						index =2;
					}
					else{
						Debug.Log("YouLose");
					}

				}
			} else {
				if (goingLeft) {
					if(gms.canIGoLeft(cursorZ,cursorX)){
						Instantiate (water,new Vector3(xConvertionFactor+cursorX+0.25f,2f,zConvertionFactor-cursorZ), new Quaternion (90,90,0,0));
						index =2;
					}
					else{
						Debug.Log("YouLose");
					}
				}
				else{
					if(gms.canIGoRight(cursorZ,cursorX)){
						Instantiate (water,new Vector3(xConvertionFactor+cursorX-0.25f,2f,zConvertionFactor-cursorZ), new Quaternion (90,90,0,0));
						index =2;
					}
					else{
						Debug.Log("YouLose");
					}
				}
			}
		} else {
			if (!movingHorizontally) {
				if (goingDown) {
					if(currentPipe==verticalPipe || currentPipe==start){
						Instantiate (water,new Vector3(xConvertionFactor+cursorX,2f,zConvertionFactor-cursorZ-0.25f), new Quaternion (90,0,0,90));
						cursorZ++;
						index =1;
						movingHorizontally=false;
						goingDown=true;
					}
					if(currentPipe==upRightCorner){
						Instantiate (water,new Vector3(xConvertionFactor+cursorX+0.25f,2f,zConvertionFactor-cursorZ), new Quaternion (90,90,0,0));
						cursorX++;
						index =1;
						movingHorizontally=true;
						goingLeft = false;
					}
					if(currentPipe==leftUpCorner){
						Instantiate (water,new Vector3(xConvertionFactor+cursorX-0.25f,2f,zConvertionFactor-cursorZ), new Quaternion (90,90,0,0));
						cursorX--;
						index =1;
						movingHorizontally=true;
						goingLeft =true;
					}
										
				} else {					
					if(currentPipe==verticalPipe){
						Instantiate (water,new Vector3(xConvertionFactor+cursorX,2f,zConvertionFactor-cursorZ+0.25f), new Quaternion (90,0,0,90));
						cursorZ--;
						index =1;
						movingHorizontally=false;
						goingDown=false;
					}
					if(currentPipe==rightDownCorner){
						Instantiate (water,new Vector3(xConvertionFactor+cursorX+0.25f,2f,zConvertionFactor-cursorZ), new Quaternion (90,90,0,0));
						cursorX++;
						index =1;
						movingHorizontally=true;
						goingLeft=false;
					}
					if(currentPipe==downleftCorner){
						Instantiate (water,new Vector3(xConvertionFactor+cursorX-0.25f,2f,zConvertionFactor-cursorZ), new Quaternion (90,90,0,0));
						cursorX--;
						index =1;
						movingHorizontally=true;
						goingLeft = true;
					}
				}
			} else {
				if (goingLeft) {
					if(currentPipe==horizontalPipe){
						Instantiate (water,new Vector3(xConvertionFactor+cursorX-0.25f,2f,zConvertionFactor-cursorZ), new Quaternion (90,90,0,0));
						cursorX--;
						index =1;
						movingHorizontally=true;
						goingLeft =true;
					}
					if(currentPipe==upRightCorner){
						Instantiate (water,new Vector3(xConvertionFactor+cursorX,2f,zConvertionFactor-cursorZ+0.25f), new Quaternion (90,0,0,90));
						cursorZ--;
						index =1;
						movingHorizontally=false;
						goingDown = false;

					}
					if(currentPipe==rightDownCorner){
						Instantiate (water,new Vector3(xConvertionFactor+cursorX,2f,zConvertionFactor-cursorZ-0.25f), new Quaternion (90,0,0,90));
						cursorZ++;
						index =1;
						movingHorizontally=false;
						goingDown = true;
					}
				}
				else{
					if(currentPipe==horizontalPipe){
						Instantiate (water,new Vector3(xConvertionFactor+cursorX+0.25f,2f,zConvertionFactor-cursorZ), new Quaternion (90,90,0,0));
						cursorX++;
						index =1;
						movingHorizontally=true;
						goingLeft = false;						
					}
					if(currentPipe==leftUpCorner){
						Instantiate (water,new Vector3(xConvertionFactor+cursorX,2f,zConvertionFactor-cursorZ+0.25f), new Quaternion (90,0,0,90));
						cursorZ--;
						index =1;
						movingHorizontally=false;
						goingDown = false;
					}
					if(currentPipe==downleftCorner){
						Instantiate (water,new Vector3(xConvertionFactor+cursorX,2f,zConvertionFactor-cursorZ-0.25f), new Quaternion (90,0,0,90));
						cursorZ++;
						index =1;
						movingHorizontally=false;
						goingDown = true;
					}
				}
			}
		}

	}


}

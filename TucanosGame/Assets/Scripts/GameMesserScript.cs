using UnityEngine;
using System.Collections;

public class GameMesserScript : MonoBehaviour {
	
	public TimerManager timeManager;
	public GameObject water;
	public GameObject trollcano;
	GameObject waterPound;
	public GameMonitorScript gms;
	Ray shootRay;
	RaycastHit shootHit;
	PipeMovement pipeMovement;
	bool movingHorizontally;
	bool goingDown;
	bool goingLeft;
	int currentTime = 0;
	int currentPipe;
	int index; // 1 - for the first half     2 - for the other half
	int xConvertionFactor;
	int zConvertionFactor;
	int cursorX=0;
	int cursorZ=0;
	int timeInt;
	
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
		timeInt = 4;
	}
	
	// Update is called once per frame
	void Update () {
		if (gms.isWinner())
			spawnWaterElement();
		if (((int)timeManager.getCurrentTime()) % timeInt == 0 && currentTime!=(int)timeManager.getCurrentTime()) 
		{
			currentTime = (int)timeManager.getCurrentTime();
			spawnWaterElement();
			if(currentTime%40 ==0){
				spawnTrollcano();
			}
		}
		
	}

	void spawnTrollcano(){
		Vector3 position = GameObject.FindGameObjectWithTag ("MainCamera").transform.position;
		Quaternion rotation = Quaternion.Euler (30f, 0, 0);
		Instantiate (trollcano,new Vector3(position.x-10, 4.7f,position.z+12), rotation);
		}
	
	void spawnWaterElement(){
		currentPipe = gms.getPipeAt (cursorX, cursorZ);
		if (index == 1) {
			if (!movingHorizontally) {
				if (goingDown) {
					if(gms.canIGoDown(cursorZ,cursorX)){
						Instantiate (water,new Vector3(xConvertionFactor+cursorX,2f,zConvertionFactor-cursorZ+0.25f), new Quaternion (90,0,0,90));
						this.transform.position= new Vector3(xConvertionFactor+cursorX,8f,zConvertionFactor-cursorZ);
						shootParalyzingBean();
						index =2;
					}
					else {
						startGameLoseProcess(cursorX, cursorZ);
					}
					
				} else {
					if(gms.canIGoUp(cursorZ,cursorX)){
						Instantiate (water,new Vector3(xConvertionFactor+cursorX,2f,zConvertionFactor-cursorZ-0.25f), new Quaternion (90,0,0,90));
						this.transform.position= new Vector3(xConvertionFactor+cursorX,8f,zConvertionFactor-cursorZ);
						shootParalyzingBean();
						index =2;
					}
					else{
						startGameLoseProcess(cursorX, cursorZ);
					}
				}
			} else {
				if (goingLeft) {
					if(gms.canIGoLeft(cursorZ,cursorX)){
						Instantiate (water,new Vector3(xConvertionFactor+cursorX+0.25f,2f,zConvertionFactor-cursorZ), new Quaternion (90,90,0,0));
						this.transform.position= new Vector3(xConvertionFactor+cursorX,8f,zConvertionFactor-cursorZ);
						shootParalyzingBean();
						index =2;
					}
					else{
						startGameLoseProcess(cursorX, cursorZ);
					}
				}
				else{
					if(gms.canIGoRight(cursorZ,cursorX)){
						Instantiate (water,new Vector3(xConvertionFactor+cursorX-0.25f,2f,zConvertionFactor-cursorZ), new Quaternion (90,90,0,0));
						this.transform.position= new Vector3(xConvertionFactor+cursorX,8f,zConvertionFactor-cursorZ);
						shootParalyzingBean();
						index =2;
					}
					else{
						startGameLoseProcess(cursorX, cursorZ);
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
	void  startGameLoseProcess(int cursorX, int cursorZ){
		waterPound = GameObject.FindGameObjectWithTag("Water");
		waterPound.transform.position = new Vector3 (xConvertionFactor + cursorX, 2f, zConvertionFactor - cursorZ);
		gms.gameLoseProcess ();
	}
	
	void shootParalyzingBean(){
		shootRay.origin = transform.position;
		shootRay.direction = transform.TransformDirection (Vector3.down);
		if (Physics.Raycast (shootRay, out shootHit, 10f)) {
			pipeMovement = shootHit.transform.GetComponent<PipeMovement> ();
		}
		if (pipeMovement != null) {
			pipeMovement.setUnpickable ();
			gms.addBlue();
		} else {
			gms.addGreen();
		}
	}

	public Vector3 getEmptySpace(){
		return gms.findRandomEmptySpace ();
	}
	
}

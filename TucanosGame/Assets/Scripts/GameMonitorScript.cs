using UnityEngine;
using System.Collections;

public class GameMonitorScript : MonoBehaviour {

	public int xConvertionFactor;
	public int zConvertionFactor;

	const int empty = 0;
	const int start = 1;
	const int verticalPipe = 2;
	const int horizontalPipe = 3;
	const int upRightCorner = 4;
	const int rightDownCorner = 5;
	const int downleftCorner = 6 ;
	const int leftUpCorner = 7;
	const int end = 8;


	int[,] numbers = new int[10, 6] { 	{1, 0, 0, 0, 6, 8},
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
		Debug.Log (numbers[1,2]);
	}

	public void setPipe(Vector3 position, int pipeType){
		numbers[zConvertionFactor-Mathf.RoundToInt(position.z),Mathf.RoundToInt(position.x)-xConvertionFactor]=pipeType;

	}

	public void getPipe(Vector3 position){
		numbers[zConvertionFactor-Mathf.RoundToInt(position.z),Mathf.RoundToInt(position.x)-xConvertionFactor]=empty;
	}

	public void checkPath(){

	}
}

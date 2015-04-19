using UnityEngine;
using System.Collections;

public class MatrixManager : MonoBehaviour {

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
	int[,] matriz;

	// Use this for initialization
	void Start () {
		if (Application.loadedLevelName.Equals("Level_01", System.StringComparison.OrdinalIgnoreCase)) {
			matriz = new int[10, 6] 
			{ 	{start, empty, empty, empty, downleftCorner, verticalEnd},
				{verticalPipe, empty, empty, empty, verticalPipe, empty},
				{empty, empty, verticalPipe, empty, empty, empty},
				{verticalPipe, empty, verticalPipe, empty, verticalPipe, empty},
				{verticalPipe, empty, verticalPipe, empty, upRightCorner, leftUpCorner},
				{empty, empty, verticalPipe, empty, empty, empty},
				{empty, empty, empty, empty, empty, empty},
				{empty, empty, empty, empty, empty, empty},
				{verticalPipe, empty, empty, empty, empty, empty},
				{upRightCorner, horizontalPipe, empty, empty, empty, empty}};
		} else if (Application.loadedLevelName.Equals("Level_02", System.StringComparison.OrdinalIgnoreCase)) {
			matriz = new int[10, 6] 
			{ 	{start, empty, empty, empty, empty, verticalEnd},
				{empty, empty, rightDownCorner, horizontalPipe, horizontalPipe, empty},
				{verticalPipe, empty, empty, empty, empty, empty},
				{upRightCorner, horizontalPipe, empty, empty, empty, empty},
				{empty, empty, verticalPipe, empty, verticalPipe, empty},
				{empty, empty, leftUpCorner, empty, verticalPipe, empty},
				{verticalPipe, empty, empty, empty, empty, empty},
				{upRightCorner, downleftCorner, empty, empty, empty, empty},
				{empty, empty, empty, empty, empty, empty},
				{empty, empty, empty, horizontalPipe, leftUpCorner, empty}};
		} else if (Application.loadedLevelName.Equals("Level_03", System.StringComparison.OrdinalIgnoreCase)) {
			matriz = new int[10, 9] 
			{ 	{start, empty, empty, empty, empty, empty, empty, empty, empty},
				{empty, empty, empty, horizontalPipe, horizontalPipe, downleftCorner, empty, empty, horizontalEnd},
				{empty, empty, empty, empty, empty, verticalPipe, empty, empty, empty},
				{verticalPipe, empty, empty, empty, empty, verticalPipe, empty, empty, empty},
				{verticalPipe, empty, empty, empty, empty, empty, empty, empty, empty},
				{upRightCorner, horizontalPipe, horizontalPipe, empty, empty, empty, empty, verticalPipe, empty},
				{empty, empty, empty, empty, empty, empty, empty, verticalPipe, empty},
				{empty, empty, empty, verticalPipe, empty, rightDownCorner, horizontalPipe, leftUpCorner, empty},
				{empty, empty, empty, verticalPipe, empty, empty, empty, empty, empty},
				{empty, empty, empty, upRightCorner, horizontalPipe, horizontalPipe, empty, empty, empty}};
		} else if (Application.loadedLevelName.Equals("Level_04", System.StringComparison.OrdinalIgnoreCase)) {
			matriz = new int[10, 9] 
			{ 	{start, empty, empty, empty, empty, empty, empty, empty, empty},
				{empty, empty, horizontalPipe, horizontalPipe, horizontalPipe, empty, rightDownCorner, downleftCorner, rightDownEnd},
				{empty, empty, empty, empty, empty, empty, empty, empty, empty},
				{empty, empty, empty, empty, empty, verticalPipe, verticalPipe, empty, empty},
				{empty, empty, rightDownCorner, empty, horizontalPipe, leftUpCorner, upRightCorner, horizontalPipe, empty},
				{empty, empty, verticalPipe, empty, empty, empty, empty, rightDownCorner, empty},
				{rightDownCorner, empty, leftUpCorner, empty, empty, empty, empty, verticalPipe, empty},
				{upRightCorner, empty, empty, empty, empty, empty, empty, empty, empty},
				{empty, empty, empty, empty, empty, verticalPipe, empty, empty, empty},
				{empty, empty, empty, empty, empty, upRightCorner, empty, empty, empty}};
		} else if (Application.loadedLevelName.Equals("Level_05", System.StringComparison.OrdinalIgnoreCase)) {
			matriz = new int[10, 12] 
			{ 	{start, empty, empty, empty, empty, empty, empty, empty, empty, empty, empty, empty},
				{verticalPipe, empty, rightDownCorner, horizontalPipe, horizontalPipe, horizontalPipe, empty, empty, empty, empty, empty, empty},
				{verticalPipe, empty, empty, empty, empty, empty, empty, empty, empty, empty, empty, empty},
				{empty, horizontalPipe, downleftCorner, empty, empty, empty, verticalPipe, empty, empty, empty, horizontalPipe, empty},
				{empty, empty, empty, empty, verticalPipe, empty, verticalPipe, empty, empty, empty, empty, upRightEnd},
				{empty, horizontalPipe, leftUpCorner, empty, verticalPipe, empty, verticalPipe, empty, empty, empty, empty, empty},
				{empty, empty, empty, empty, empty, empty, empty, empty, verticalPipe, empty, empty, empty},
				{upRightCorner, downleftCorner, empty, empty, empty, empty, empty, empty, verticalPipe, empty, empty, empty},
				{empty, empty, empty, empty, empty, empty, empty, empty, empty, empty, empty, empty},
				{empty, empty, empty, horizontalPipe, leftUpCorner, empty, upRightCorner, horizontalPipe, leftUpCorner, empty, empty, empty}};
		}else {
			Debug.Log("ERRO: MATRIZ DA FASE NAO EXISTE");
		}
	}

	
	// Update is called once per frame
	void Update () {
	
	}

	public int[,] getMatrix(){
		return matriz;
	}
}

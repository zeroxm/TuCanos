using UnityEngine;
using System.Collections;

public class GameStartScript : MonoBehaviour {

	public GameObject[] pipes;
	public Transform[] spawnPoints;
	//Quantos Corners tem que spawnar, o resto vai ser preenchido com pipes.
	public int numCorners;


	// Use this for initialization
	void Start () {
		int pipeIndex = 0, spawnPointIndex = 0, i=0, j=0;
		bool espacoVago = false;
		int[] usedIndexes = new int[spawnPoints.Length];
		for (i=0; i<spawnPoints.Length; i++) {
			usedIndexes[i]= -1;
		}

		for(i=0; i<spawnPoints.Length; i++){
			if(i==numCorners){
				pipeIndex++;
			}
			spawnPointIndex = Random.Range (0, spawnPoints.Length);
			while(!espacoVago){
				for(j=0;j<spawnPoints.Length;j++){
					if(usedIndexes[j]!=spawnPointIndex){
						espacoVago=true;
						continue;
					}
					else {
						espacoVago=false;
						break;
					}

				}
				if(!espacoVago){
					spawnPointIndex++;
					if(spawnPointIndex==spawnPoints.Length){
					spawnPointIndex=0;
					}
				}				
			}

			usedIndexes[i]= spawnPointIndex;
			if(pipeIndex==0)
				Instantiate (pipes[pipeIndex], spawnPoints[spawnPointIndex].position, new Quaternion(0,90,0,0));
			else
				Instantiate (pipes[pipeIndex], spawnPoints[spawnPointIndex].position, new Quaternion(90,0,0,90));
			espacoVago=false;
		}

	}
	
	// Update is called once per frame
	void Update () {
	}



}

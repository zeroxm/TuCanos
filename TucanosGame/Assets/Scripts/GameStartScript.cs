using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameStartScript : MonoBehaviour {

	public GameObject[] pipes;
	public Transform[] spawnPoints;
	public int numCorners;
	public GameObject HUD;
	Animator HUDAnimator;
	AudioSource bgm;
	TimerManager timerManager;
	//Quantos Corners tem que spawnar, o resto vai ser preenchido com pipes.

	GameMonitorScript gms;


	// Use this for initialization
	void Start () {
		//string NomeDaFase = Application.loadedLevelName;
		int pipeIndex = 0, spawnPointIndex = 0, i=0, j=0;
		bool espacoVago = false;
		gms = this.GetComponent<GameMonitorScript>();
		timerManager = HUD.GetComponentInChildren<TimerManager> ();

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
			if(pipeIndex==0){
				gms.setPipe(spawnPoints[spawnPointIndex].position, 6);
				Instantiate (pipes[pipeIndex], spawnPoints[spawnPointIndex].position, new Quaternion(0,90,0,0));
			}
			else{
				gms.setPipe(spawnPoints[spawnPointIndex].position, 2);
				Instantiate (pipes[pipeIndex], spawnPoints[spawnPointIndex].position, new Quaternion(90,0,0,90));
			}
			espacoVago=false;
		}
		HUDAnimator = HUD.GetComponent<Animator> ();
		HUDAnimator.SetTrigger ("Start");
		bgm = this.GetComponent<AudioSource> ();
		bgm.Play ();
	}
	
	// Update is called once per frame
	void Update () {
			if (HUDAnimator.GetCurrentAnimatorStateInfo (0).IsName ("GameStartClip")) 
			timerManager.restart();
	}



}

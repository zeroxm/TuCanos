using UnityEngine;
using System.Collections;

public class GameMesserScript : MonoBehaviour {

	public TimerManager timeManager;
	GameMonitorScript gms;
	int index = 1; // 1 - for the first half     2 - for the other half

	int timeInt;

	// Use this for initialization
	void Start () {
		gms = this.GetComponent<GameMonitorScript> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		if (((int)timeManager.getCurrentTime()) % 8 == 0) {
			spawnWaterElement();
		}
	
	}

	void spawnWaterElement(){

	}


}

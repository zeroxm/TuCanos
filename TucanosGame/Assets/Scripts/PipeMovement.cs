using UnityEngine;
using System.Collections;

public class PipeMovement : MonoBehaviour {

	bool picked =false;
	bool pickable = true;
	Vector3 targetPosition;
	GameObject gameMonitor;
	GameMonitorScript gms;
	public int pipeType;
	// Use this for initialization
	void Start () {
		gameMonitor = GameObject.FindGameObjectWithTag ("GameController");
		gms = gameMonitor.GetComponent<GameMonitorScript> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (picked) {
			targetPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
			targetPosition.y = 3.5f;
			this.transform.position = targetPosition;
		}
	}

	public bool togglePicked(){
		if(pickable)
		picked = !picked;
		return picked;
	}

	public void rotate(){
		this.transform.Rotate(0,90,0,0);
		if (this.pipeType < 4) {
			switch (pipeType) {
			case 2:
				pipeType = 3;
				break;
			case 3:
				pipeType = 2;
				break;
			}
		} else {
			switch (pipeType) {
			case 4:
				pipeType = 5;
				break;
			case 5:
				pipeType = 6;
				break;
			case 6:
				pipeType = 7;
				break;
			case 7:
				pipeType = 4;
				break;
			}
		}
	}

	public bool putDown(Vector3 currentPosition, Quaternion currentRotation){
		togglePicked ();
		float x = Mathf.Round (currentPosition.x);
		float y = Mathf.Round (currentPosition.y);
		float z = Mathf.Round (currentPosition.z);

		int angle = Mathf.RoundToInt (Quaternion.Angle (currentRotation, new Quaternion (0, 1.0f, 0, 0)));
		if (angle==0) {
			this.transform.position = new Vector3(x,y,z+1);
		}
		else if(angle==180){
			this.transform.position = new Vector3(x,y,z-1);
		}
		else{
			angle = Mathf.RoundToInt (Quaternion.Angle (currentRotation, new Quaternion (0, 0.7f, 0, 0.7f)));
		
		if (angle < 90) {
			this.transform.position = new Vector3(x-1,y,z);
		}
		if (angle > 90) {
			this.transform.position = new Vector3(x+1,y,z);
		}
		}
		return true;
	}

	public void sendPositionToMonitor(){
		gms.setPipe(this.transform.position, this.pipeType);
	}

	public void clearPositionOnMonitor(){
		gms.getPipe(this.transform.position);
	}

	public void setUnpickable(){
		pickable = false;
	}

}

using UnityEngine;
using System.Collections;

public class PipeMovement : MonoBehaviour {

	bool picked =false;
	Vector3 targetPosition;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (picked) {
			targetPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
			targetPosition.y = 3.5f;
			this.transform.position = targetPosition;
		}
	}

	public void togglePicked(){
		picked = !picked;
	}

	public void rotate(){
			this.transform.Rotate(0,90,0,0);
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
}

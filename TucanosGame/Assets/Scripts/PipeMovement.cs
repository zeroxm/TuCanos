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
		float x = Mathf.Round(currentPosition.x);
		float y = Mathf.Round(currentPosition.y);
		float z = Mathf.Round(currentPosition.z);
		if (currentRotation.Equals (new Quaternion (0, 1.0f, 0, 0))) {
			print("Cima");
		}
		return true;
	}
}

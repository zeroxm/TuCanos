using UnityEngine;
using System.Collections;

public class ItemPicker : MonoBehaviour {
	
	[SerializeField]
	public float range = 100f;
	Ray shootRay;
	RaycastHit shootHit;
	bool temPeca = false;
	PipeMovement pipeMovement;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Jump")) {
			if (!temPeca) {
				shootRay.origin = transform.position;
				shootRay.direction = transform.TransformDirection (Vector3.back);
				if (Physics.Raycast (shootRay, out shootHit, 1)) {
					pipeMovement = shootHit.transform.GetComponent<PipeMovement> ();
					if (pipeMovement != null) {
						pipeMovement.togglePicked ();
						temPeca = true;
					}
				}
			}
			else{
				shootRay.origin = transform.position;
				shootRay.direction = transform.TransformDirection (Vector3.back);
				if (Physics.Raycast (shootRay, out shootHit, 1))
					print("Too close to PutDown");
				else if(putDown())
					temPeca= false;
				}
		}
		if (Input.GetButtonDown ("Fire1")) {
			rotate();
				}
			}

	void rotate(){
		pipeMovement.rotate ();
	}

	bool putDown(){
		return pipeMovement.putDown (this.transform.position, this.transform.rotation);
}
}


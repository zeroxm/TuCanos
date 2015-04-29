using UnityEngine;
using System.Collections;

public class TrollCanoScript : MonoBehaviour {

	GameMesserScript troubleMaker;
	bool runAway;
	bool goAway;
	Transform mainTarget;
	float moveSpeed=3f;
	Quaternion fixedRotation;
	Vector3 fixedPosition;
	Ray shootRay;
	RaycastHit shootHit;
	PipeMovement pipeMovement;
	ItemPicker playerItemPicker;
	Vector3 runAwayTarget;
	Transform cameraTarget;
	AudioSource audio;
			
// Use this for initialization
	void Start () {
		troubleMaker = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameMesserScript> ();
		mainTarget = GameObject.FindWithTag ("Player").transform;
		cameraTarget = GameObject.FindWithTag ("MainCamera").transform;
		runAway = false;
		goAway = false;
		audio = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!runAway) {
			shootStealBean();
			if (Vector3.Distance(this.transform.position, mainTarget.position) > 2.7f){
			//Determina a rotaçao e entao conserta as coordenada que nao precisam mudar
				this.transform.LookAt (mainTarget.position);
			fixedRotation = this.transform.rotation;
			fixedRotation = Quaternion.Euler (30f, fixedRotation.eulerAngles.y, 0f);
			this.transform.rotation = fixedRotation;
			//Determina a posiçao e entao acerta a altura
			this.transform.position += this.transform.forward * moveSpeed * Time.deltaTime;
			fixedPosition = this.transform.position;
			fixedPosition.y = 4.7f;
			this.transform.position = fixedPosition;
			
		}
		} else if (!goAway) {
			//Determina a rotaçao e entao conserta as coordenada que nao precisam mudar
			this.transform.LookAt (runAwayTarget);
			fixedRotation = this.transform.rotation;
			fixedRotation = Quaternion.Euler (30f, fixedRotation.eulerAngles.y, 0f);
			this.transform.rotation = fixedRotation;
			//Determina a posiçao e entao acerta a altura
			this.transform.position += this.transform.forward * moveSpeed * Time.deltaTime;
			fixedPosition = this.transform.position;
			fixedPosition.y = 4.7f;
			this.transform.position = fixedPosition;
			if (Vector3.Distance(this.transform.position, runAwayTarget) < 4.71f){
				pipeMovement.dropDown(this.transform.position); 
				goAway =true;
			}
		} else {
			this.transform.LookAt (new Vector3(cameraTarget.position.x,cameraTarget.position.y,cameraTarget.position.z-10));
			fixedRotation = this.transform.rotation;
			fixedRotation = Quaternion.Euler (30f, fixedRotation.eulerAngles.y, 0f);
			this.transform.rotation = fixedRotation;
			//Determina a posiçao e entao acerta a altura
			this.transform.position += this.transform.forward * moveSpeed * Time.deltaTime;
			fixedPosition = this.transform.position;
			fixedPosition.y = 4.7f;
			this.transform.position = fixedPosition;
			if (Vector3.Distance(this.transform.position, mainTarget.position) > 9f){
				Object.Destroy(this.gameObject);
			}
		}
	
	}

	void shootStealBean(){
		shootRay.origin = transform.position;
		shootRay.direction = transform.TransformDirection (Vector3.down);
		if (Physics.Raycast (shootRay, out shootHit, 2f)) {
			pipeMovement = shootHit.transform.GetComponent<PipeMovement> ();
		}
		if (pipeMovement != null) {
			audio.Play();
			playerItemPicker = GameObject.FindGameObjectWithTag ("Player").GetComponent<ItemPicker> ();
			playerItemPicker.takePeca();
			pipeMovement.steal(this.transform);
			runAway = true;
			moveSpeed=5f;
			runAwayTarget = troubleMaker.getEmptySpace();
		} else {
		}
	}
}

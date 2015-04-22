using UnityEngine;
using System.Collections;

public class ItemPicker : MonoBehaviour {
	
	[SerializeField]
	public float range = 100f;
	Ray shootRay;
	RaycastHit shootHit;
	bool temPeca = false;
	PipeMovement pipeMovement;
	PlayerMovement playerMovement;
	GameObject mainCamera;
	Pause pause;
	bool disabled;
	AudioSource[] audioSources;
	
	// Use this for initialization
	void Start () {
		playerMovement = this.GetComponent<PlayerMovement> ();
		mainCamera = GameObject.FindGameObjectWithTag ("MainCamera");
		pause = mainCamera.GetComponent<Pause> ();
		audioSources = this.GetComponents<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (pause.isPaused())
			return;
		if (playerMovement.isDisabled())
			return;
		if (Input.GetButtonDown ("Jump")) {
			if (!temPeca) {
				shootRay.origin = transform.position;
				shootRay.direction = transform.TransformDirection (Vector3.back);
				if (Physics.Raycast (shootRay, out shootHit, 1.2f)) {
					pipeMovement = shootHit.transform.GetComponent<PipeMovement> ();
					if (pipeMovement != null) {
						if(pipeMovement.togglePicked ()){
							pipeMovement.clearPositionOnMonitor();
							temPeca = true;
							audioSources[1].Play();
						}
						else{
							audioSources[0].Play();
						}
					}
				}
			}
			else{
				shootRay.origin = transform.position;
				shootRay.direction = transform.TransformDirection (Vector3.back);
				if (Physics.Raycast (shootRay, out shootHit, 1.2f))
					audioSources[0].Play();
				else if(putDown()){
					temPeca= false;
					audioSources[1].Play();
				}
				}
		}
		if (Input.GetButtonDown ("Fire1")) {
			if(temPeca){
			rotate();
			audioSources[2].Play();
			}
			}
	}

	void rotate(){
		pipeMovement.rotate ();
	}

	bool putDown(){
		bool success = pipeMovement.putDown (this.transform.position, this.transform.rotation);
		if (success)
			pipeMovement.sendPositionToMonitor ();
		return success;

}
}


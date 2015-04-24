using UnityEngine;
using System.Collections;

public class TrollCanoScript : MonoBehaviour {

	GameMesserScript troubleMaker;

	// Use this for initialization
	void Start () {
		troubleMaker = GameObject.FindGameObjectWithTag ("Player").GetComponent<GameMesserScript> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

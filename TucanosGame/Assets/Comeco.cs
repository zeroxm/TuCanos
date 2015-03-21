using UnityEngine;
using System.Collections;

public class Comeco : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var renderer = this.GetComponent<Renderer>();
		var material = renderer.material;
		var color = material.color;

		Debug.Log("CRIAR TILES");
		GameObject Tile1 = GameObject.Find ("Tile1");
		GameObject Tile2 = GameObject.Find ("Tile2");
		Instantiate (Tile1);
		Instantiate (Tile2);
		//GameObject<Renderer>().material.color.a = 0.5f;
		//Tile1().material.color.a = 0.5f;
		//renderer.material.color.a = 0.4f;

		float TESTE = color.a;
		Debug.Log ("O ALPHA EH " + TESTE);
		color.a = 0.1f;
		Debug.Log ("O ALPHA EH " + color.a);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}

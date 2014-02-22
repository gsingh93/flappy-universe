using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {
	
	public int turnNumber = 0;
	public Hashtable resources;
	public List<Planet> planets;

	// Use this for initialization
	private void Start () {
		resources = new Hashtable ();
		resources.Add ("Energy", 100);
	}
	
	// Update is called once per frame
	private void Update () {
		
	}

	public void turnFinish () {
		turnNumber++;


	}

	public void turnStart() {

	}
}

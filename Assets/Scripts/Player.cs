using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {
	
	public int turnNumber = 0;
	public int resources = 100;
	public List<Planet> planets;

	// Use this for initialization
	private void Start () {

	}
	
	// Update is called once per frame
	private void Update () {
		
	}

	public void turnFinish () {
		turnNumber++;

		foreach (Planet p in planets) {
			resources += p.harvestEnergy();
		}
	}

	public void turnStart() {

	}
}

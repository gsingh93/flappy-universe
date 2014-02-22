using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {
	
	public int turnNumber = 0;
	public int resources = 100;
	public List<Planet> planets;

	public void claimPlanet(Planet planet) {
		planets.Add (planet);
		planet.claimed = true;
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

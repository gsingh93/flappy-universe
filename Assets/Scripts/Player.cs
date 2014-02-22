using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {
	
	public int turnNumber = 0;
	public int resources = 100;
	public List<Planet> planets;

	public List<Celestial> celestialBodies;

	public void claimPlanet(Planet planet) {
		planets.Add (planet);
		planet.claimed = true;
	}

	public void addCelestialBody(Celestial celest) {
		celestialBodies.Add (celest);
	}

	public void turnFinish () {
		turnNumber++;

		foreach (Planet p in planets) {
			resources += p.harvestEnergy();
		}

		
		for (int i=0; i<celestialBodies.Count; i++) {
			Celestial c = celestialBodies[i];

			c.turnsLeft--;
			if (c.turnsLeft <= 0) {
				celestialBodies.Remove(c);
				c.nextState();
				i--;
			}

		}
	}

	public void turnStart() {

	}

	public void hideLabels() {
		foreach (Celestial c in celestialBodies) {
			c.lblShowing = false;
		}
	}
	
	public void showLabels() {
		foreach (Celestial c in celestialBodies) {
			c.lblShowing = true;
		}
	}

}

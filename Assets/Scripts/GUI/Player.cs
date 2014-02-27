using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {
	
	public int turnNumber = 0;
	public int resources = 50;

	public List<Planet> planets;
	public List<GameObject> solarSystems;
	public List<Celestial> celestialBodies;
	
	public void claimPlanet(Planet planet) {
		planets.Add(planet);
		planet.claimed = true;

		GameObject s = planet.transform.parent.gameObject;
		if (!solarSystems.Contains(s)) {
			solarSystems.Add(s);
		}

		Celestial tmp = s.GetComponentInChildren<Celestial>();
		if (tmp.turnsLeft > 2) {
			tmp.starTypeStyle.normal.textColor = Color.green;
		}
	}

	public void addCelestialBody(Celestial celest) {
		celestialBodies.Add(celest);
	}

	public void turnFinish () {
		turnNumber++;

		foreach (Planet p in planets) {
			resources += p.harvestEnergy();
		}

		Celestial c;
		for (int i=0; i<celestialBodies.Count; i++) {
			c = celestialBodies[i];
			if (!c.permState && c.hasBeenSeen) {
				c.turnsLeft--;
				if (c.turnsLeft <= 0) {
					celestialBodies.Remove(c);
					c.nextState();
					i--;
				}
			}
		}
	}

	public int energyPerTurn() {
		int energy = 0;
		foreach (Planet p in planets) {
			energy += p.calculateEnergy(true);
		}
		return energy;
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

using UnityEngine;
using System.Collections;

public class StellarNebula : Celestial {

	private void Awake() {
		shouldGeneratePlanets = false;
	}

	private new void Start() {
		base.Start();

		foreach (Planet p in transform.parent.GetComponentsInChildren<Planet>()) {
			Destroy(p.gameObject);
		}
		
		stateType = "Stellar Nebula";
		nextStarState = "Star";

		solarOutput = 0;
	}
	
	public override void nextState() {
		// TODO: WTF
		if (prob < 1f) {
			nextStarState = "Star";
		} else {
			nextStarState = "Massive Star";
		}

		base.nextState();

		transform.parent.GetComponent<SolarSystem>().GenerateRandomPlanets ();
	}
}

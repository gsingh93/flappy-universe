using UnityEngine;
using System.Collections;

public class StellarNebula : Celestial {
	public static string StateType = "Stellar Nebula";

	private void Awake() {
		shouldGeneratePlanets = false;
	}

	new private void Start () {
		base.Start ();

		foreach (Planet p in transform.parent.GetComponentsInChildren<Planet> ()) {
			Destroy(p.gameObject);
		}
		
		stateType = StateType;
		nextStarState = "Star";

		solarOutput = 0;

		turnsLeft = Random.Range (10, 20);
	}
	
	override public void nextState() {
//		Debug.Log ("prob " + prob);
		if (prob < 1f) {
			nextStarState = "Star";
		} else {
			nextStarState = "Massive Star";
		}

		base.nextState ();

		transform.parent.GetComponent<SolarSystem> ().GenerateRandomPlanets ();
	}
}



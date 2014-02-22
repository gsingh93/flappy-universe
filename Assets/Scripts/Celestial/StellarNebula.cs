using UnityEngine;
using System.Collections;

public class StellarNebula : Celestial {

	private void Start () {
		base.Start ();
		
		stateType = "Stellar Nebula";
		nextStarState = "Planetary Nebula";
	}

	override public void nextState() {
		if (prob < 50) {

		} else if (prob < 1500) {

		} else if (prob < 1900) {

		} else {

		}
	}

}

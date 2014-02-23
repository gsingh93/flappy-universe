using UnityEngine;
using System.Collections;

public class StellarNebula : Celestial {

	new private void Start () {
		base.Start ();
		
		stateType = "Stellar Nebula";
		nextStarState = "Star";

		solarOutput = 0;
	}
	
	override public void nextState() {
//		Debug.Log ("prob " + prob);
		if (prob < 1f) {
			nextStarState = "Star";
		} else {
			nextStarState = "Massive Star";
		}
		
		base.nextState ();
	}
}



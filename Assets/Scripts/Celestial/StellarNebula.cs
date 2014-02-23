using UnityEngine;
using System.Collections;

public class StellarNebula : Celestial {

	new private void Start () {
		base.Start ();
		
		stateType = "Stellar Nebula";
		nextStarState = "Star";
	}
	
	override public void nextState() {
//		Debug.Log ("prob " + prob);
		if (prob < 1500) {
			nextStarState = "Star";
		} else {
			nextStarState = "Red Supergiant";
		}
		
		base.nextState ();
	}
}



using UnityEngine;
using System.Collections;

public class StellarNebula : Celestial {

	new private void Start () {
		base.Start ();
		
		stateType = "Stellar Nebula";
		nextStarState = "Star";
		
		Mathf.Clamp (prob, 0.5f, 2f);
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



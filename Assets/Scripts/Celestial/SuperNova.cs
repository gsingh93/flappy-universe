using UnityEngine;
using System.Collections;

public class SuperNova : Celestial {
	
	new private void Start () {
		base.Start ();
		
		stateType = "SuperNova";
		nextStarState = "?";

		turnsLeft = Random.Range (1, 5);

	}
	
	override public void nextState() {
		//		Debug.Log ("prob " + prob);
		if (prob < 1.6f) {
			nextStarState = "Stellar Nebula";
		} else if (prob < 1.7f) {
			nextStarState = "Neutron Star";
		} else {
			nextStarState = "Black Hole";
		}
		
		base.nextState ();
	}
}



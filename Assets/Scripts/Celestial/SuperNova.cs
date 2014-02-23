using UnityEngine;
using System.Collections;

public class SuperNova : Celestial {
	
	new private void Start () {
		base.Start ();
		
		stateType = "SuperNova";
		nextStarState = "?";

		turnsLeft = Random.Range (1, 5);
		
		Mathf.Clamp (prob, 1f, 2f);
	}
	
	override public void nextState() {
		//		Debug.Log ("prob " + prob);
		if (prob < 1.7f) {
			nextStarState = "Stellar Nebula";
		} else if (prob < 1.9f) {
			nextStarState = "Neutron Star";
		} else {
			nextStarState = "Black Hole";
		}
		
		base.nextState ();
	}
}



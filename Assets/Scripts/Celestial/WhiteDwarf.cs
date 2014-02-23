using UnityEngine;
using System.Collections;

public class WhiteDwarf : Celestial {
	
	new private void Start () {
		base.Start ();
		
		stateType = "White Dwarf";
		nextStarState = "?";
		starLabelOffset = 2.33f;

		solarOutput = 50;
	}

	override public void nextState() {
		//		Debug.Log ("prob " + prob);
		if (prob < 0.2f) {
			nextStarState = "Stellar Nebula";
		} else {
			nextStarState = "Black Dwarf";
		}
		
		base.nextState ();
	}
	
}
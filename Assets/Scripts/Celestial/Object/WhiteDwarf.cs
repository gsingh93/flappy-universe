using UnityEngine;
using System.Collections;

public class WhiteDwarf : Celestial {

	private float nebulaProbability = 0.2f;

	private new void Start () {
		base.Start();
		
		stateType = "White Dwarf";
		nextStarState = "?";
		starLabelOffset = 2.33f;

		solarOutput = 50;
	}

	public override void nextState() {
		if (prob < nebulaProbability) {
			nextStarState = "Stellar Nebula";
		} else {
			nextStarState = "Black Dwarf";
		}
		
		base.nextState();
	}
}

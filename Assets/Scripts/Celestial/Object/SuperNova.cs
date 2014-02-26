using UnityEngine;
using System.Collections;

public class SuperNova : Celestial {

	private new int minTurns = 1;
	private new int maxTurns = 5;

	private new void Start () {
		base.Start();
		
		stateType = "SuperNova";
		nextStarState = "?";

		turnsLeft = Random.Range(minTurns, maxTurns);
	}
	
	override public void nextState() {
		if (prob < 1.6f) {
			nextStarState = "Stellar Nebula";
		} else if (prob < 1.7f) {
			nextStarState = "Neutron Star";
		} else {
			nextStarState = "Black Hole";
		}
		
		base.nextState();
	}
}

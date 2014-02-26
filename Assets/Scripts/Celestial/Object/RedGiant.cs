using UnityEngine;
using System.Collections;

public class RedGiant : Celestial {

	private new int minTurns = 3;
	private new int maxTurns = 3;

	private new void Start() {
		base.Start();
		
		stateType = "Red Giant";
		nextStarState = "White Dwarf";
		starLabelOffset = 0f;
		turnsLeft = Random.Range(minTurns, maxTurns);

		solarOutput = 200;
	}
}
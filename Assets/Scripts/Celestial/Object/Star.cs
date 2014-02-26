using UnityEngine;
using System.Collections;

public class Star : Celestial {
	private new void Start() {
		base.Start();

		stateType = "Yellow Star";
		nextStarState = "Red Giant";
		starLabelOffset = 2.33f;

		solarOutput = 100;

		turnsLeft = Random.Range (7, 15);
	}
}
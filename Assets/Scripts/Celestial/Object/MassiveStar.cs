using UnityEngine;
using System.Collections;

public class MassiveStar : Celestial {
	private new void Start() {
		base.Start();
		
		stateType = "Massive Star";
		nextStarState = "Red Supergiant";
		starLabelOffset = 0.57f;
	
		solarOutput = 150;
	}
}
using UnityEngine;
using System.Collections;

public class RedSuperGiant : Celestial {
	private new void Start() {
		base.Start();
		
		stateType = "Red Supergiant";
		nextStarState = "Super Nova";
		starLabelOffset = 0f;

		solarOutput = 300;
	}
}
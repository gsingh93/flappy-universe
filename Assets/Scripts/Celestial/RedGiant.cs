using UnityEngine;
using System.Collections;

public class RedGiant : Celestial {


	new private void Start () {
		base.Start ();
		
		stateType = "Red Giant";
		nextStarState = "White Dwarf";
		starLabelOffset = 0f;
		turnsLeft = 3;

		solarOutput = 200;
	}

	
}
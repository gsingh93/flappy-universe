using UnityEngine;
using System.Collections;

public class RedSuperGiant : Celestial {
	
	
	new private void Start () {
		base.Start ();
		
		stateType = "Red Supergiant";
//		nextStarState = "Super Nova";
		nextStarState = "Stellar Nebula";
		starLabelOffset = 0f;
		solarOutput = 300;
	}
	
	
}
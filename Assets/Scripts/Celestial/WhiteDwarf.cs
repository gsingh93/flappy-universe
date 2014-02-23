using UnityEngine;
using System.Collections;

public class WhiteDwarf : Celestial {
	
	new private void Start () {
		base.Start ();
		
		stateType = "White Dwarf";
		starLabelOffset = 2.33f;

		solarOutput = 50;
	}

	
}
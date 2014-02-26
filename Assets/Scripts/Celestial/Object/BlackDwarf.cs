using UnityEngine;
using System.Collections;

public class BlackDwarf : Celestial {
	
	new private void Start () {
		base.Start ();
		
		stateType = "Black Dwarf";
		starLabelOffset = 2.33f;

		solarOutput = 0;
	}
	
	
}
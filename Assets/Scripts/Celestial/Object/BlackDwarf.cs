using UnityEngine;
using System.Collections;

public class BlackDwarf : Celestial {
	private new void Start () {
		base.Start ();
		
		stateType = "Black Dwarf";
		starLabelOffset = 2.33f;

		solarOutput = 0;
	}
}
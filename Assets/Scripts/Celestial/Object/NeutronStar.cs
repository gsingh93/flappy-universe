using UnityEngine;
using System.Collections;

public class NeutronStar : Celestial {
	private new void Start() {
		base.Start();
		
		stateType = "Neutron Star";
		starLabelOffset = 2.33f;

		solarOutput = 10;
	}
}
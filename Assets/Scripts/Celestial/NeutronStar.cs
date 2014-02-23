using UnityEngine;
using System.Collections;

public class NeutronStar : Celestial {
	new private void Start () {
		base.Start ();
		
		stateType = "Neutron Star";
		starLabelOffset = 2.33f;

	}
	
	
}
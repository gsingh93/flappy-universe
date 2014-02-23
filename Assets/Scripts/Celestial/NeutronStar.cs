using UnityEngine;
using System.Collections;

public class NeutronStar : Celestial {
	
	new private void Start () {
		base.Start ();
		
		stateType = "Neutron Star";
		starLabelOffset = 2.33f;
		
		Mathf.Clamp (prob, 1.7f, 1.9f);
	}
	
	
}
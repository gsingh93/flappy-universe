using UnityEngine;
using System.Collections;

public class WhiteDwarf : Celestial {
	
	new private void Start () {
		base.Start ();
		
		stateType = "White Dwarf";
		starLabelOffset = 2.33f;
		
		Mathf.Clamp (prob, 0.01f, 1f);
	}
	
	
}
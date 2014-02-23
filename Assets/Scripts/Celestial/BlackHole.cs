using UnityEngine;
using System.Collections;

public class BlackHole : Celestial {
	
	new private void Start () {
		base.Start ();
		
		stateType = "Black Hole";
		starLabelOffset = 2.33f;
	}
	
	
}
using UnityEngine;
using System.Collections;

public class BlackHole : Celestial {
	
	new private void Start () {
		base.Start ();
		
		stateType = "Black Hole";
		starLabelOffset = 2.33f;

		
		Mathf.Clamp (prob, 1.9f, 2f);
	}
	
	
}
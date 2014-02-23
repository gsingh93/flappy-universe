using UnityEngine;
using System.Collections;

public class RedGiant : Celestial {


	new private void Start () {
		base.Start ();
		
		stateType = "Red Giant";
		nextStarState = "White Dwarf";
		starLabelOffset = 0f;
		
		Mathf.Clamp (prob, 0.01f, 1f);
	}

	
}
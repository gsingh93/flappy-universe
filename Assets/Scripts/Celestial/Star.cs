using UnityEngine;
using System.Collections;

public class Star : Celestial {

	new private void Start () {
		base.Start ();

		stateType = "Yellow Star";
		nextStarState = "Red Giant";
		starLabelOffset = 2.33f;

		Mathf.Clamp (prob, 0.5f, 1f);
	}


}
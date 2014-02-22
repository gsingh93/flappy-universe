using UnityEngine;
using System.Collections;

public class RedGiant : Celestial {


	new private void Start () {
		base.Start ();
		
		stateType = "Red Giant";
		nextStarState = "Planetary Nebula";
		starLabelOffset = 8f;
	}
	
	override public void nextState() {
		GameObject nebula = (GameObject)Instantiate(Resources.Load("Star"), transform.position, transform.rotation);
		nebula.transform.parent = transform.parent;

		Destroy (gameObject);                   
	}
	
}
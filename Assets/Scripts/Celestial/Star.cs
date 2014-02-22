using UnityEngine;
using System.Collections;

public class Star : Celestial {


	new private void Start () {
		base.Start ();

		stateType = "Yellow Star";
		nextStarState = "Red Giant";
	}
	
	override public void nextState() {
		GameObject redgiant = (GameObject)Instantiate(Resources.Load("RedGiant"), transform.position, transform.rotation);
		redgiant.transform.parent = transform.parent;

		Destroy (gameObject);                   
	}

}
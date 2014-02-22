using UnityEngine;
using System.Collections;

public class RedGiant : Celestial {


	private void Start () {
		stateType = "Red Giant";
	}
	
	override public void nextState() {
		GameObject destroyedCarGameObject = (GameObject)Instantiate(Resources.Load("RedGiant"), transform.position, transform.rotation);
		Destroy (this);                   
	}
	
}
using UnityEngine;
using System.Collections;

public class Star : Celestial {


	private void Start () {
		stateType = "Yellow Star";
	}
	
	override public void nextState() {
		GameObject destroyedCarGameObject = (GameObject)Instantiate(Resources.Load("RedGiant"), transform.position, transform.rotation);
		Destroy (this);                   
	}
	
}
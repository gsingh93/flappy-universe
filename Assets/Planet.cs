using UnityEngine;
using System.Collections;

public class Planet : MonoBehaviour {
	public string planetName;

	// Use this for initialization
	private void Start () {
	
	}
	
	// Update is called once per frame
	private void Update () {
	
	}

	void OnMouseDown() {
		Debug.Log (planetName + " Clicked");


	}

	void OnGUI () {
		GUI.Box (new Rect (10, 10, 200, 150), "Loader Menu");

		if (GUI.Button (new Rect (20, 40, 150, 20), "Build Mine (30)")) {
			Debug.Log ("Building Mine On Planet " + planetName);
		}
	}

}

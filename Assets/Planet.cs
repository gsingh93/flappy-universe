using UnityEngine;
using System.Collections;

public class Planet : MonoBehaviour {
	public string planetName;
	public bool buttonClicked = false;

	public Vector2 origin;

	// Use this for initialization
	private void Start () {

	}
	
	// Update is called once per frame
	private void Update () {
	
	}

	void OnMouseDown() {

		Debug.Log (planetName + " Clicked");

		foreach (Planet p in transform.parent.gameObject.GetComponentsInChildren<Planet> ()) {
			if (p != this)
				p.buttonClicked = false;
		}

		buttonClicked = !buttonClicked;
	}

	void OnGUI () {

		if (buttonClicked) {
			origin = Camera.main.WorldToViewportPoint(transform.position);
			GUI.Box (new Rect (origin.x, origin.y, 200, 150), "Loader Menu");

			if (GUI.Button (new Rect (20, 40, 150, 20), "Build Mine (30)")) {
				Debug.Log ("Building Mine On Planet " + planetName);
			}
		}
	}

}

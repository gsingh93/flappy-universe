using UnityEngine;
using System.Collections;

public class Planet : MonoBehaviour {
       	public string planetName;

	public int speed;
	public int radius;

	// Use this for initialization
	private void Start () {

	}
	
	private void Update () {
		transform.position = radius * new Vector3(Mathf.Cos(Time.time), Mathf.Sin(Time.time), 0);
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

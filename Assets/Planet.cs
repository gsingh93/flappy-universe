using UnityEngine;
using System.Collections;

public class Planet : MonoBehaviour {
       	public string planetName;

	public int speed;
	public int radius;

    public const int maxSpeed = 1;
	public const int minSpeed = 5;

    GameObject parent;

	// Use this for initialization
	private void Start () {
	    parent = transform.parent.gameObject;
	}
	
	private void Update () {
		float angle = Time.time * speed;
		transform.position = parent.transform.position + radius * new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0);
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

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BlackHole : Celestial {

	List<Planet> planets;

	new private void Start () {
		base.Start ();
		
		stateType = "Black Hole";
		starLabelOffset = 2.33f;

		planets = new List<Planet> ();

		foreach (Planet p in transform.parent.GetComponentsInChildren<Planet> ()) {
			planets.Add(p);
		}
	}

	private void Update () {

		for (int i = 0; i < planets.Count; i++) {
			if (planets[i] == null) {
				planets.Remove(planets[i]);
				i--;
			} else {
				float rad = planets[i].GetComponent<Revolve> ().radius;
				if (rad > 0f)
					planets[i].GetComponent<Revolve> ().radius -= Time.deltaTime;
				else {
					planets.Remove(planets[i]);
					i--;
				}
			}
		}
	}

}
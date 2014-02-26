using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BlackHole : Celestial {

	private List<Planet> planets = new List<Planet>();

	private new void Start() {
		base.Start();
		
		stateType = "Black Hole";
		starLabelOffset = 2.33f;

		foreach (Planet p in transform.parent.GetComponentsInChildren<Planet>()) {
			planets.Add(p);
			p.GetComponent<LineRenderer>().enabled = false;
		}

		solarOutput = 0;
	}

	private void Update () {
		for (int i = 0; i < planets.Count; i++) {
			if (planets[i] == null) {
				planets.Remove(planets[i]);
				i--;
			} else {
				float rad = planets[i].GetComponent<Revolve>().radius;
				if (rad > 0f) {
					planets[i].GetComponent<Revolve>().radius -= Time.deltaTime * 0.5f;
				} else {
					planets.Remove(planets[i]);
					i--;
				}
			}
		}
	}
}

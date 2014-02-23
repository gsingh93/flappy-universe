using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BlackHole : Celestial {

	List<Planet> planets;

	new private void Start () {
		base.Start ();
		
		stateType = "Black Hole";
		starLabelOffset = 2.33f;

		foreach (Planet p in transform.parent.GetComponentsInChildren<Planet> ()) {
			planets.Add(p);
		}
	}

	new private void Update () {

		for (int i = 0; i < planets.Count; i++) {
			if (planets[i] == null) {
				planets.Remove(planets[i]);
				i--;
			} else {
				planets[i].gameObject.transform.position += new Vector3 (0f, 0f, 0f);
			}
		}
	}

}
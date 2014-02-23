using UnityEngine;
using System.Collections;

public class GenerateUniverse : MonoBehaviour {

	public int numSystems = 20;
	public SolarSystem solarSystemPrefab;

	void Start() {
		Debug.Log ("here");
		for (int i = 0; i < numSystems; i++) {
		Debug.Log ("here1");
			SolarSystem s = Instantiate(solarSystemPrefab) as SolarSystem;
			s.transform.parent = camera.transform;
		}
	}
}

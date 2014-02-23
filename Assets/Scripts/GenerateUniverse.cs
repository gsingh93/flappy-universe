using UnityEngine;
using System.Collections;

public class GenerateUniverse : MonoBehaviour {

	public int numSystems = 20;
	public SolarSystem solarSystemPrefab;

	void Start() {
		for (int i = 0; i < numSystems; i++) {
			Instantiate(solarSystemPrefab);
		}
	}
}

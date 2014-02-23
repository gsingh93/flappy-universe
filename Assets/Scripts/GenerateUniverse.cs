using UnityEngine;
using System.Collections;

public class GenerateUniverse : MonoBehaviour {

	public int numSystems = 2;
	public SolarSystem solarSystemPrefab;

	void Start() {
		SolarSystem s = Instantiate(solarSystemPrefab) as SolarSystem;
		s.transform.parent = transform;
		s.ourSolarSystem = true;
		
		for (int i = 0; i < numSystems - 1; i++) {
			s = Instantiate(solarSystemPrefab) as SolarSystem;
			s.transform.parent = transform; 
		}
	}
}

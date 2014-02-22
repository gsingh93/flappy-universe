using UnityEngine;
using System.Collections;

public class SolarSystem : MonoBehaviour {

	public Planet planetPrefab;

	public const int minPlanets = 6;
	public const int maxPlanets = 10;

	private int numPlanets;
	
	private void Start() {
		numPlanets = Random.Range(minPlanets, maxPlanets);

		for (int i = 0; i < numPlanets; i++) {
			Planet planet = Instantiate(planetPrefab) as Planet;
			planet.transform.parent = transform;
			planet.speed = Random.value * (Planet.maxSpeed - Planet.minSpeed) + Planet.minSpeed;
			planet.radius = i * 2;
		}
	}
	
	private void Update() {
	}
}

using UnityEngine;
using System.Collections;

public class SolarSystem : MonoBehaviour {

	public Planet planetPrefab;
	public bool ourSolarSystem = false;
	public Celestial[] celestialPrefabs;

	public Celestial celestial;

	public const int minPlanets = 6;
	public const int maxPlanets = 10;

	private int numPlanets;
	private string[] ourPlanets;

	public void GenerateOurSolarSystem() {
	}

	public void GenerateRandomSolarSystem() {
	}
	
	private void Start() {
		if (ourSolarSystem) {
			GenerateOurSolarSystem();
		} else {
			GenerateRandomSolarSystem();
		}
		int celestialIndex = (int) (Random.value * celestialPrefabs.Length);
		celestial = Instantiate (celestialPrefabs[celestialIndex]) as Celestial;
		celestial.transform.position = transform.position;

		ourPlanets = new string[] {"Mercury", "Venus", "Earth", "Mars", "Jupiter", "Saturn", "Uranus", "Neptune"};
		if (ourSolarSystem) 
			numPlanets = ourPlanets.Length;
		else
			numPlanets = Random.Range(minPlanets, maxPlanets);

		for (int i = 1; i <= numPlanets; i++) {
			Planet planet = Instantiate(planetPrefab) as Planet;
			planet.transform.parent = transform;
			Revolve revolution = planet.GetComponent<Revolve>();
			revolution.speed = Random.value * (Planet.maxSpeed - Planet.minSpeed) + Planet.minSpeed;
			revolution.radius = i * 2;

			if (ourSolarSystem && i < 9) {
				if (ourPlanets[i-1] == "Earth") {
					Camera.main.GetComponent<Player> ().claimPlanet(planet);
				}
				planet.planetName = ourPlanets[i-1];
				planet.gameObject.name = ourPlanets[i-1];
			}
		}
	}
	
	private void Update() {

	}
}

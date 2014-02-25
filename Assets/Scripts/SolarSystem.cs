using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SolarSystem : MonoBehaviour {

	public Planet planetPrefab;
	public bool ourSolarSystem = false;
	public Celestial[] celestialPrefabs;

	public Celestial celestial;
	public List<Planet> planets;

	public const int minPlanets = 6;
	public const int maxPlanets = 10;

	private int numPlanets;
	private HUD hud;

	private void Start() {
		if (ourSolarSystem) {
			GenerateOurSolarSystem();
		} else {
			GenerateRandomSolarSystem();
		}

		hud = Camera.main.GetComponent<HUD> ();
	}

	public float getSolarOutput() {
		return celestial.solarOutput;
	}
	
	public void GenerateOurSolarSystem() {
		celestial = Instantiate(celestialPrefabs[0]) as Celestial;
		celestial.transform.position = transform.position;
		celestial.transform.parent = transform;
		
		string[] ourPlanets = new string[] {"Mercury", "Venus", "Earth", "Mars", "Jupiter", "Saturn", "Uranus", "Neptune"};
		numPlanets = ourPlanets.Length;
		
		for (int i = 1; i <= numPlanets; i++) {
			Planet planet = Instantiate(planetPrefab) as Planet;
			Revolve revolution = planet.GetComponent<Revolve>();
			planet.transform.parent = transform;
			revolution.speed = Random.value * (Planet.maxSpeed - Planet.minSpeed) + Planet.minSpeed;
			revolution.radius = i * 2;
			
			if (i == 3) {
				Camera.main.GetComponent<Player>().claimPlanet(planet);
			}
			
			planet.planetName = ourPlanets[i-1];
			planet.gameObject.name = ourPlanets[i-1];
			
			planets.Add(planet);
		}
	}
	
	public void GenerateRandomSolarSystem() {
		int celestialIndex = (int) (Random.value * celestialPrefabs.Length);
		celestial = Instantiate (celestialPrefabs[celestialIndex]) as Celestial;
		celestial.transform.position = transform.position;
		celestial.transform.parent = transform;
		
		numPlanets = Random.Range(minPlanets, maxPlanets);

		if (celestial.shouldGeneratePlanets) {
			GenerateRandomPlanets();
		}
	}

	public void GenerateRandomPlanets() {
		float systemEdge = celestial.transform.localScale.x / 2;
		for (int i = 1; i <= numPlanets; i++) {
			Planet planet = Instantiate(planetPrefab) as Planet;
			planet.transform.parent = transform;
			Revolve revolution = planet.GetComponent<Revolve>();
			revolution.speed = Random.value * (Planet.maxSpeed - Planet.minSpeed) + Planet.minSpeed;
			
			float scale = Random.Range(1f, 1f);
			planet.transform.localScale = new Vector3(scale, scale, scale);

			float radius = systemEdge + scale / 2 + Random.Range(0.5f, 1.5f);
			
			revolution.radius = radius;
			systemEdge = radius + scale / 2;
			
			planets.Add(planet);
		}
	}

	private void OnMouseDown() {
		hud.startPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z - 30);
	}
}

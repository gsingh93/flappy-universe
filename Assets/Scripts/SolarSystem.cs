﻿using UnityEngine;
using System.Collections;

public class SolarSystem : MonoBehaviour {

	public Planet planetPrefab;
	public bool ourSolarSystem = false;

	public const int minPlanets = 6;
	public const int maxPlanets = 10;

	private int numPlanets;
	private string[] ourPlanets;
	
	private void Start() {
		ourPlanets = new string[] {"Mercury", "Venus", "Earth", "Mars", "Jupiter", "Saturn", "Uranus", "Neptune"};
		numPlanets = Random.Range(minPlanets, maxPlanets);

		for (int i = 1; i <= numPlanets; i++) {
			Planet planet = Instantiate(planetPrefab) as Planet;
			planet.transform.parent = transform;
			planet.speed = Random.value * (Planet.maxSpeed - Planet.minSpeed) + Planet.minSpeed;
			planet.radius = i * 2;
			if (ourSolarSystem && i < 9)
				planet.planetName = ourPlanets[i-1];
		}
	}
	
	private void Update() {
	}
}

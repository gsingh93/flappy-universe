using UnityEngine;
using System.Collections;

public class SolarSystem : MonoBehaviour {

	public GameObject planetPrefab;

	public const int minPlanets = 6;
	public const int maxPlanets = 10;

	private int numPlanets;
	
	private void Start() {
		numPlanets = Random.Range(minPlanets, maxPlanets);

		for (int i = 0; i < numPlanets; i++) {
			GameObject planet = Instantiate(planetPrefab) as GameObject;
			//planet.rigidbody.velocity = Random.Range(5, 10);
			planet.transform.position = Vector3.right * 2 * i;
		}
	}
	
	private void Update() {
	}
}

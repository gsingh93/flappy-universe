using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Keybindings : MonoBehaviour {
	private Player player;
	private HUD hud;
	public int currentSolarSystem = -1;
	public int currentPlanet = 0;

	private void Start() {
		player = GetComponent<Player>() as Player;
		hud = GetComponent<HUD>() as HUD;
	}

	private void Update() {
		if (Input.GetKeyDown(KeyCode.Tab)) {
			if (currentSolarSystem == -1 && player.solarSystems.Count > 0) {
				currentSolarSystem = 0;
			}

			if (currentSolarSystem == -1) {
				return;
			}
			if (Camera.main.transform.position.z >= -30) {
				// Cycle between planets
				SolarSystem s = player.solarSystems[currentSolarSystem].GetComponent<SolarSystem>();

				// Loop through all planets starting from the current one until you find one that's claimed
				for (int i = 1; i < s.planets.Count + 1; i++) {
					int index = (currentPlanet + i) % s.planets.Count;
					if (s.planets[index].claimed == true) {
						s.planets[index].OnMouseDown();
						currentPlanet = index;
						break;
					}
				}
			} else {
				// Cycle between solar systems
				currentSolarSystem = (currentSolarSystem + 1) % player.solarSystems.Count;
				GameObject s = player.solarSystems[currentSolarSystem];
				hud.cameraPosition = s.transform.position;
				hud.cameraPosition.z = -31;
				currentPlanet = 0;
			}
		}
	}
}

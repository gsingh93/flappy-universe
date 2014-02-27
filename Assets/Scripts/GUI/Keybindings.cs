using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Keybindings : MonoBehaviour {
	private Player player;
	private HUD hud;
	private int currentSolarSystem = -1;
	private int currentPlanet = -1;

	private void Start() {
		player = GetComponent<Player>() as Player;
		hud = GetComponent<HUD>() as HUD;
	}

	private void Update() {
		if (Input.GetKeyDown(KeyCode.Tab)) {
			if (Camera.main.transform.position.z > -30) {
				// Cycle between planets
				if (currentPlanet == -1 && player.planets.Count > 0) {
					currentPlanet = 0;
				}
				if (currentSolarSystem != -1) {
					currentSolarSystem = (currentSolarSystem + 1) % player.solarSystems.Count;
					GameObject s = player.solarSystems[currentSolarSystem];
					hud.cameraPosition = s.transform.position;
					hud.cameraPosition.z = -30;
				}
			} else {
				// Cycle between solar systems
				if (currentSolarSystem == -1 && player.solarSystems.Count > 0) {
					currentSolarSystem = 0;
				}
				if (currentSolarSystem != -1) {
					currentSolarSystem = (currentSolarSystem + 1) % player.solarSystems.Count;
					GameObject s = player.solarSystems[currentSolarSystem];
					hud.cameraPosition = s.transform.position;
					hud.cameraPosition.z = -30;
				}
			}
		}
	}
}

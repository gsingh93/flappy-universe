using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Keybindings : MonoBehaviour {
	private Player player;
	private HUD hud;
	private int index = -1;

	private void Start() {
		player = GetComponent<Player>() as Player;
		hud = GetComponent<HUD>() as HUD;
	}

	private void Update() {
		if (Input.GetKeyDown(KeyCode.Tab)) {
			if (Camera.main.transform.position.z > -30) {
				// Cycle between planets

			} else {
				// Cycle between solar systems
				if (index == -1 && player.solarSystems.Count > 0) {
					index = 0;
				}
				if (index != -1) {
					index = (index + 1) % player.solarSystems.Count;
					GameObject s = player.solarSystems[index];
					hud.cameraPosition = s.transform.position;
					hud.cameraPosition.z = -30;
				}
			}
		}
	}
}

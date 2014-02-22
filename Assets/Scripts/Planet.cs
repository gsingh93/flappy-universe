﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Planet : SelectableObject {
	public string planetName;
	public bool buttonClicked = false;

	private bool _claimed;
	public bool claimed {
		set {
			_claimed = value;
			(gameObject.GetComponent("Halo") as Behaviour).enabled = _claimed;
		}
		get {
			return _claimed;
		}
	}

	public const float maxSpeed = 0.2f;
	public const float minSpeed = 2f;

	public Mine minePrefab;
	public Ship shipPrefab;

	public float mineCost;

	public Texture[] textures;

	public Vector2 origin;
	
	public int totalResources = 200;
	public int totalSlots = 4;

	private List<Resource> resources = new List<Resource>();

	private static string OPTION_BUILD_MINE = "Build Mine";
	private static string OPTION_BUILD_SHIP = "Build Ship";
	private static MenuOption[] options = {
		new MenuOption (OPTION_BUILD_MINE, 25),
		new MenuOption (OPTION_BUILD_SHIP, 100)
	};

	new private void Start() {
		base.Start ();
		if (gameObject.name == "Earth")
			renderer.material.mainTexture = textures[4];
		else {
			int rndRngVal = Random.Range(0, textures.Length);

			while (rndRngVal == 4) {
				rndRngVal = Random.Range(0, textures.Length);
			}

			renderer.material.mainTexture = textures[rndRngVal];
		}
	}
	
	private int calculateEnergy(bool dryRun) {
		int numResources = 0;
		foreach (Resource r in resources) {
			numResources += r.harvestResources(this, dryRun);
		}
		return numResources;
	}

	public int harvestEnergy() {
		return calculateEnergy(false);
	}

	#region implemented abstract members of SelectableObject
	public override string getName() {
		return planetName;
	}

	public override string getDescription() {
		if (claimed) {
			return (totalSlots - resources.Count) + " empty building slots.\n" +
				"+" + calculateEnergy(true) + " energy per turn.\n" +
				totalResources + " minerals remaining in planet";
		} else {
			return "You haven't claimed this planet.";
		}
	}

	public override MenuOption[] getOptions() {
		if (claimed) {
			return options;
		} else {
			return new MenuOption[0];
		}
	}

	public override void OnOptionSelected(MenuOption option) {
		if (resources.Count >= totalSlots || option.cost > player.resources) {
			return;
		}

		player.resources -= option.cost;
		if (option.name == OPTION_BUILD_MINE) {
			float rad = (transform.eulerAngles.z + 90 * resources.Count) * Mathf.Deg2Rad;
			Vector3 pos = new Vector3(Mathf.Cos(rad) * 0.5f, Mathf.Sin(rad) * 0.5f, 0);
			Mine mine = Instantiate(minePrefab) as Mine;
			mine.transform.position = transform.position + pos;
			mine.transform.eulerAngles = transform.eulerAngles;
			mine.transform.parent = transform;

			resources.Add(mine);
		} else if (option.name == OPTION_BUILD_SHIP) {
			Ship ship = Instantiate(shipPrefab) as Ship;
			ship.transform.position = transform.position;
			ship.transform.parent = this.transform;
		}
	}
	#endregion
}

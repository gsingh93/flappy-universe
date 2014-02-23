using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class Planet : SelectableObject {
	public string planetName;

	public const float maxSpeed = 0.2f;
	public const float minSpeed = 2f;

	public SolarPanel solarPanelPrefab;
	public Mine minePrefab;
	public Ship shipPrefab;
	
	public Texture[] textures;

	private static MenuOption FLY_TO_PLANET_OPTION = new MenuOption("Fly To Planet", 50);

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
	
	public int totalResources = 200;
	public int totalSlots = 4;

	private List<Resource> resources = new List<Resource>();
	private List<Resource> dummyResources = new List<Resource>();

	private static string OPTION_BUILD_MINE = "Build Mine";
	private static string OPTION_BUILD_SOLAR_PANEL = "Build Solar Panel";
	private static string OPTION_BUILD_SHIP = "Build Ship";
	private static MenuOption[] options = {
		new MenuOption (OPTION_BUILD_MINE, 25),
		new MenuOption (OPTION_BUILD_SOLAR_PANEL, 25),
		new MenuOption (OPTION_BUILD_SHIP, 100)
	};

	new private void Start() {
		base.Start();
		if (gameObject.name == "Earth")
			renderer.material.mainTexture = textures[4];
		else {
			int rndRngVal = Random.Range(0, textures.Length);

			while (rndRngVal == 4) {
				rndRngVal = Random.Range(0, textures.Length);
			}

			renderer.material.mainTexture = textures[rndRngVal];
		}

		Mine m = Instantiate(minePrefab) as Mine;
		m.renderer.enabled = false;
		m.transform.parent = transform;
		m.name = "DummyMine";
		dummyResources.Add(m);

		SolarPanel s = Instantiate(solarPanelPrefab) as SolarPanel;
		s.renderer.enabled = false;
		s.transform.parent = transform;
		s.name = "DummySolarPanel";
		dummyResources.Add(s);
	}

	public void CreateRing() {
		LineRenderer line = GetComponent<LineRenderer>();

		float angle = 0;
		int segments = 200;
		line.SetVertexCount(segments);

		for (int i = 0; i < segments; i++) {
			float x = transform.parent.transform.position.x
				+ Mathf.Sin(Mathf.Deg2Rad * angle) * GetComponent<Revolve>().radius;
			float y = transform.parent.transform.position.y
				+ Mathf.Cos(Mathf.Deg2Rad * angle) * GetComponent<Revolve>().radius;
			
			line.SetPosition(i, new Vector3(x, y, 0));

			angle += 360f / segments;
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
		StringBuilder sb = new StringBuilder();
		if (claimed) {
			sb.Append(totalSlots - resources.Count)
				.Append(" empty building slots.\n")
					.Append(calculateEnergy(true))
					.Append(" energy per turn.\n")
					.Append(totalResources)
					.Append(" minerals remaining in planet\n");
		} else {
			sb.Append("You haven't claimed this planet.\n");
		}

		foreach (Resource r in dummyResources) {
			sb.Append(r.getName() + ": " + r.harvestResources(this, true) + " Energy\n");
		}

		return sb.ToString();
	}

	protected override void OnMouseDown() {
		base.OnMouseDown ();
		if (hud.shipToPickDestinationFor != null) {
			Ship ship = hud.shipToPickDestinationFor;
			float distance = 0f;
			if (ship.transform.parent.parent == transform.parent) {
				// Intra-stellar travel
				distance = Mathf.Abs(GetComponent<Revolve>().radius - ship.transform.parent.GetComponent<Revolve>().radius);
			} else {
				// Inter-stellar travel
				distance = Vector3.Distance(ship.transform.parent.parent.position, transform.parent.position) - GetComponent<Revolve>().radius;
			}

			FLY_TO_PLANET_OPTION.cost = (int) (distance * 5);
		}
	}

	public override MenuOption[] getOptions() {
		if (claimed) {
			return options;
		} else if (hud.shipToPickDestinationFor != null) {
			return new MenuOption[] {FLY_TO_PLANET_OPTION};
		} else {
			return new MenuOption[0];
		}
	}

	private void PlaceResource(Resource r) {
		float rad = (transform.eulerAngles.z + 90 * resources.Count) * Mathf.Deg2Rad;
		Vector3 pos = new Vector3(Mathf.Cos(rad) * 0.5f, Mathf.Sin(rad) * 0.5f, 0);
		r.transform.position = transform.position + pos;
		r.transform.eulerAngles = transform.eulerAngles;
		r.transform.parent = transform;
	}

	public override void OnOptionSelected(MenuOption option) {
		if (option.cost > player.resources) {
			return;
		}

		player.resources -= option.cost;
		if (option.name == OPTION_BUILD_MINE && resources.Count < totalSlots) {
			Mine mine = Instantiate(minePrefab) as Mine;
			PlaceResource(mine);
			resources.Add(mine);
		} if (option.name == OPTION_BUILD_SOLAR_PANEL  && resources.Count < totalSlots) {
			SolarPanel panel = Instantiate(solarPanelPrefab) as SolarPanel;
			PlaceResource(panel);
			resources.Add(panel);
		} else if (option.name == OPTION_BUILD_SHIP) {
			Ship ship = Instantiate(shipPrefab) as Ship;
			ship.transform.position = transform.position;
			ship.transform.parent = this.transform;
		} else if (option == FLY_TO_PLANET_OPTION) {
			Ship ship = hud.shipToPickDestinationFor;
			hud.shipToPickDestinationFor = null;
			Destroy(ship.gameObject);
			player.claimPlanet(this);
		}
	}
	#endregion
}

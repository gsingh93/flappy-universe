using UnityEngine;
using System.Collections;

public class SolarPanel : Resource {

	private Revolve r;
	private SolarSystem solarSystem;

	public void Start() {
		solarSystem = transform.parent.parent.GetComponent<SolarSystem> ();
	}

	public override int harvestResources(Planet p, bool dryRun) {
		if (r == null) {
			r = p.GetComponent<Revolve>();
		}
		float radius = r.radius;
		return (int) (solarSystem.getSolarOutput() / radius);
	}

	public override string getName() {
		return "Solar Panel";
	}
}

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

		solarSystem = transform.parent.parent.GetComponent<SolarSystem> ();
		return (int) (solarSystem.getSolarOutput() * 0.4f / Mathf.Sqrt(radius));
	}

	public override string getName() {
		return "Solar Panel";
	}
}

using UnityEngine;
using System.Collections;

public class SolarPanel : Resource {

	private Revolve r;

	public override int harvestResources(Planet p, bool dryRun) {
		if (r == null) {
			r = p.GetComponent<Revolve>();
		}
		float radius = r.radius;
		return (int) (100 / radius);
	}

	public override string getName() {
		return "Solar Panel";
	}
}

using UnityEngine;
using System.Collections;

public class SolarPanel : Resource {

	public override int harvestResources(Planet p, bool dryRun) {
		float distance = Vector3.Distance(p.transform.position, p.transform.parent.transform.position);
		return (int) (100 / distance);
	}
}

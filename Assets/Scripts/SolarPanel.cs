using UnityEngine;
using System.Collections;

public class SolarPanel : Resource {
	public override int harvestResources(Planet p, bool dryRun) {
		return 10;
	}
}

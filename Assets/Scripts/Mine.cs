using UnityEngine;
using System.Collections;

public class Mine : Resource {
	private const int numResources = 20;
	public override int harvestResources(Planet p, bool dryRun) {
		int resources = Mathf.Min(numResources, p.totalResources);
		if (!dryRun) {
			p.totalResources -= resources;
		}
		return resources;
	}

	
	public override string getName() {
		return "Mine";
	}
}

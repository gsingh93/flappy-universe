using UnityEngine;
using System.Collections;

public abstract class Resource : MonoBehaviour {
	public abstract int harvestResources(Planet p, bool dryRun);
	public abstract string getName();
}

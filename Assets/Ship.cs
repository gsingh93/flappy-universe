using UnityEngine;
using System.Collections;

public class Ship : SelectableObject { 

	private void Update() {
		Vector3 displacement = transform.position - transform.parent.position;
		float angle = Mathf.Atan2 (displacement.y, displacement.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
	}

	#region implemented abstract members of SelectableObject
	public override string getName ()
	{
		return "Ship";
	}
	public override string getDescription ()
	{
		return "";
	}
	#endregion
}

using UnityEngine;
using System.Collections;

public class Ship : SelectableObject {

	private static MenuOption OPTION_TRAVEL = new MenuOption ("Claim a new planet.", 0);
	public Planet IAmYourFather;

	private void Update() {
		Vector3 displacement = transform.position - transform.parent.position;
		float angle = Mathf.Atan2 (displacement.y, displacement.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
	}

	public override MenuOption[] getOptions () {
    	return new MenuOption[] {OPTION_TRAVEL};
	}

	public override void OnOptionSelected (MenuOption option) {
		if (option == OPTION_TRAVEL) {
			hud.PickPlanet(this);
		}
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

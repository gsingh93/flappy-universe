using UnityEngine;
using System.Collections;

public class Planet : SelectableObject {
	public string planetName;
	public bool buttonClicked = false;

	public Vector2 origin;

	#region implemented abstract members of SelectableObject
	public override string getName ()
	{
		return planetName;
	}

	public override string[] getOptions ()
	{
		return new string[] {"Build Mine"};
	}

	public override void OnOptionSelected (string option)
	{
		Debug.Log ("Planet " + planetName + " selected option " + option);
	}
	#endregion
}

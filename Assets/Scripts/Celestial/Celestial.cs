using UnityEngine;
using System.Collections;

public abstract class Celestial : SelectableObject {

	public string stateType;
	public int turnsLeft = 5;
	public GUIStyle starLabelStyle;
	public GUIStyle starTypeStyle;
	public int curState = 1;
	public string curStarState;
	public string nextStarState;
	public int bodyMass;
	protected int prob = 50;

	private int lblWidth = 80;
	private int lblHeight = 100;

	abstract public void nextState ();

	protected void Start () {
		base.Start ();

		turnsLeft = Random.Range (5, 15);
		bodyMass = Random.Range (1, 2000);

		Camera.main.GetComponent<Player> ().addCelestialBody(this);

//		smlStarStates = new string[] {"Stellar Nebula ", "Brown Dwarf"};
//		avgStarStates = new string[] {"Stellar Nebula ", "Yellow Star ", "Red Giant ", "Planetary Nebula ", "White Dwarf "};
//		msvStarStates = new string[] {"Stellar Nebula ", "Massive Star ", "Red SuperGiant ", "Planetary Nebula ", "White Dwarf "};
//		gntStarStates = new string[] {"Stellar Nebula ", "Supermassive Star ", "Red SuperGiant ", "Planetary Nebula ", "White Dwarf "};
	}

	private void Update () {

	}

//	private void OnGUI () {
//		Vector3 offset = new Vector3 (-transform.localScale.x * 2f, transform.localScale.y, 0);
//		var p = Camera.main.WorldToScreenPoint(transform.position + offset);
//
//		GUI.Box (new Rect(p.x,p.y,lblWidth,lblHeight), stateType, starTypeStyle);
//		GUI.Label(new Rect(p.x,p.y+25,lblWidth,lblHeight), (turnsLeft) + " Turns to " + nextStarState, starLabelStyle);
//	}


	#region implemented abstract members of SelectableObject

	public override string getName ()
	{
		return stateType;
	}

	public override string getDescription ()
	{
		return turnsLeft + " Turns to " + nextStarState;
	}

	public override MenuOption[] getOptions ()
	{
		return new MenuOption[0];
	}

	public override void OnOptionSelected (MenuOption option)
	{
		return;
	}

	#endregion
}

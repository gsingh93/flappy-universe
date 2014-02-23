using UnityEngine;
using System.Collections;

public abstract class Celestial : SelectableObject {

	public string stateType;
	public int turnsLeft = 5;
	public GUIStyle starLabelStyle;
	public GUIStyle starTypeStyle;
	public int curState = 1;
	public string nextStarState;
	public bool lblShowing = true;

	protected int prob = 50;
	protected float starLabelOffset;
	protected float transitionTime = 0.5f;
	protected int bodyMass;

	private int lblWidth = 80;
	private int lblHeight = 100;

	abstract public void nextState ();

	new protected void Start () {
		base.Start ();

		turnsLeft = Random.Range (5, 15);

		Camera.main.GetComponent<Player> ().addCelestialBody(this);

//		smlStarStates = new string[] {"Stellar Nebula ", "Brown Dwarf"};
//		avgStarStates = new string[] {"Stellar Nebula ", "Yellow Star ", "Red Giant ", "Planetary Nebula ", "White Dwarf "};
//		msvStarStates = new string[] {"Stellar Nebula ", "Massive Star ", "Red SuperGiant ", "Planetary Nebula ", "White Dwarf "};
//		gntStarStates = new string[] {"Stellar Nebula ", "Supermassive Star ", "Red SuperGiant ", "Planetary Nebula ", "White Dwarf "};
	}

	protected void Update () {

	}

	protected void OnGUI () {
		Vector3 offset = new Vector3 (-transform.lossyScale.x * starLabelOffset, transform.lossyScale.y * Screen.height/30f, 0);
		var p = Camera.main.WorldToScreenPoint(transform.position);
		p += offset;

		if (lblShowing) {
			starLabelStyle.fontSize = Screen.width / 60;
			starTypeStyle.fontSize = Screen.width / 50;
			GUI.Box (new Rect(p.x,p.y,lblWidth,lblHeight), stateType, starTypeStyle);
			GUI.Label(new Rect(p.x,p.y+Screen.height/20,lblWidth,lblHeight), (turnsLeft) + " Turns to " + nextStarState, starLabelStyle);
		}
	}

	protected void OnCollisionStay (Collision col) {
		print(col.gameObject.name);
		if (col.gameObject.tag != "Celestial")
			Destroy(col.gameObject);
	}

	protected void OnCollisionEnter (Collision col) {
		if (col.gameObject.tag != "Celestial")
			Destroy(col.gameObject);
	}

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

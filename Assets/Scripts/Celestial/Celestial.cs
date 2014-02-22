using UnityEngine;
using System.Collections;

public abstract class Celestial : MonoBehaviour {

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

	private void Start () {
		turnsLeft = Random.Range (5, 15);
		bodyMass = Random.Range (1, 2000);

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


	private void setCurState (int numStates) {
		if (curState < numStates)
			curState++;
	}
}

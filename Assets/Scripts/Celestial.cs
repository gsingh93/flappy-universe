using UnityEngine;
using System.Collections;

public class Celestial : MonoBehaviour {

	public int turnsLeft = 5;
	public GUIStyle starLabelStyle;
	public GUIStyle starTypeStyle;
	public string curState = "Yellow Star ";
	public string nextState = "Red Giant";

	public int lblWidth = 80;
	public int lblHeight = 100;

	private void Start () {
		turnsLeft = Random.Range (5, 25);
	}

	private void Update () {
	
	}

	private void OnGUI () {
		Vector3 offset = new Vector3 (-transform.localScale.x * 2f, transform.localScale.y, 0);
		var p = Camera.main.WorldToScreenPoint(transform.position + offset);

		GUI.Box (new Rect(p.x,p.y,lblWidth,lblHeight), curState, starTypeStyle);
		GUI.Label(new Rect(p.x,p.y+25,lblWidth,lblHeight), (turnsLeft) + " Turns to " + nextState, starLabelStyle);
	}
}

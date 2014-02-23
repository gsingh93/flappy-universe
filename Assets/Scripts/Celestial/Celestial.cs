﻿using UnityEngine;
using System.Collections;

public abstract class Celestial : SelectableObject {

	public string stateType;
	public int turnsLeft = 5;
	public GUIStyle starLabelStyle;
	public GUIStyle starTypeStyle;
	public string nextStarState;
	public bool lblShowing = true;
	public bool permState = false;
	public bool shouldGeneratePlanets = true;

	protected float prob = 50;
	public float starLabelOffset = 0f;
	protected float transitionTime = 0.5f;
	protected int bodyMass;
	public int solarOutput;
	protected GameObject nextCelestial;
	protected float finalScale;

	private int lblWidth = 1;
	private int lblHeight = 1;
	private Color prevColor;

	new protected void Start () {
		base.Start ();

		turnsLeft = Random.Range (5, 10);
		prob = Random.Range (0.01f, 2f);

		Camera.main.GetComponent<Player> ().addCelestialBody(this);
		if (Camera.main.GetComponent<Player> ().solarSystems.Contains(transform.parent.gameObject)) {
			starTypeStyle.normal.textColor = Color.green;
		}
	}

	protected void OnGUI () {

		if (lblShowing) {
			float distToCam = (transform.position.z - Camera.main.transform.position.z);

			Vector3 offset = new Vector3 (-transform.lossyScale.x * starLabelOffset, transform.lossyScale.y, 0);
			var p = Camera.main.WorldToScreenPoint(transform.position);
			p += offset;

//			starLabelStyle.fontSize = (int) (200f/distToCam*Screen.width/600f);
//			starTypeStyle.fontSize = (int) (250f/distToCam*Screen.width/550f);
			starLabelStyle.fontSize = (int) (Screen.width/60f);
			starTypeStyle.fontSize = (int) (Screen.width/50f);

			if (turnsLeft < 3) {
				prevColor = starTypeStyle.normal.textColor;
				if (Camera.main.GetComponent<Player> ().solarSystems.Contains(transform.parent.gameObject))
					starTypeStyle.normal.textColor = Color.red;
				else
					starTypeStyle.normal.textColor = Color.yellow;
			} 

			GUI.Box (new Rect(p.x,Screen.height-p.y+(200f/distToCam*Screen.height/125f)+transform.localScale.x/0.25f,lblWidth,lblHeight), stateType, starTypeStyle);
			if (!permState)
				GUI.Label(new Rect(p.x,Screen.height-p.y+(200f/distToCam*Screen.height/125f)+transform.localScale.x/0.25f+Screen.height/20f,lblWidth,lblHeight), (turnsLeft) + " Turns to " + nextStarState, starLabelStyle);
		}
	}

	protected void OnCollisionStay (Collision col) {
		if (col.gameObject.tag != "Celestial" && col.gameObject.transform.parent == transform.parent)
			Destroy(col.gameObject);
	}

	protected void OnCollisionEnter (Collision col) {
		if (col.gameObject.tag != "Celestial" && col.gameObject.transform.parent == transform.parent)
			Destroy(col.gameObject);
	}
	
	virtual public void nextState () {


		rigidbody.isKinematic = true;
		collider.isTrigger = true;
		renderer.enabled = false;
		(gameObject.GetComponent ("Halo") as Behaviour).enabled = false;
		lblShowing = false;
		starTypeStyle.normal.textColor = prevColor;
		
		nextCelestial = (GameObject)Instantiate(Resources.Load(nextStarState.Replace(" ", "")), transform.position, transform.rotation);
		finalScale = nextCelestial.transform.localScale.x;
		nextCelestial.transform.parent = transform.parent;

		Celestial temp = nextCelestial.GetComponent<Celestial> ();
		temp.lblShowing = false;
		temp.prob = prob;
		nextCelestial.transform.localScale = transform.localScale;

		transform.parent.GetComponent<SolarSystem> ().celestial = nextCelestial.GetComponent<Celestial>();

		StartCoroutine ("growStar");
	}
	
	virtual protected IEnumerator growStar () {
		float growTimer = 0f;
		float changeVel;
		Vector3 changeVect = new Vector3 ();

		if (finalScale > transform.localScale.x) {
			changeVel = (finalScale - transform.localScale.x) / transitionTime;
		} else {
			changeVel = (transform.localScale.x - finalScale) / transitionTime;
		}
		
		while (growTimer < transitionTime) {
			growTimer += Time.deltaTime;
			
			changeVect.x = changeVect.y = changeVect.z = Mathf.Clamp01(changeVel*growTimer)*(finalScale - transform.localScale.x)+transform.localScale.x;
			nextCelestial.transform.localScale = changeVect;
			
			yield return null;
		}
		
		nextCelestial.GetComponent<Celestial> ().lblShowing = true;
		Destroy (gameObject);  
	}

	#region implemented abstract members of SelectableObject

	public override string getName ()
	{
		return stateType;
	}

	public override string getDescription ()
	{
		string description = prob.ToString () + " Solar Masses";
		if (!permState) {
			description += "\n" + turnsLeft + " Turns to " + nextStarState;
		}

		return description;
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

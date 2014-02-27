using UnityEngine;
using System.Collections;

public abstract class Celestial : SelectableObject {

	public int minTurns = 5;
	public int maxTurns = 7;

	public string stateType;
	public int turnsLeft;
	public GUIStyle starLabelStyle;
	public GUIStyle starTypeStyle;
	public string nextStarState;
	public bool lblShowing = true;
	public bool permState = false;
	public bool shouldGeneratePlanets = true;
	public bool hasBeenSeen = false;

	protected float prob = 50;
	public float starLabelOffset = 0f;
	protected float transitionTime = 2f;
	public int solarOutput;
	protected GameObject nextCelestial;

	private int lblWidth = 1;
	private int lblHeight = 1;
	private Color prevColor;

	protected new void Start () {
		base.Start();

		turnsLeft = Random.Range(minTurns, maxTurns);
		prob = Random.Range(0.01f, 2f);

		Player p = Camera.main.GetComponent<Player>();
		p.addCelestialBody(this);
		if (p.solarSystems.Contains(transform.parent.gameObject)) {
			starTypeStyle.normal.textColor = Color.green;
		}
	}

	protected void OnGUI () {
		if (lblShowing) {
			float distToCam = transform.position.z - Camera.main.transform.position.z;

			Vector3 offset = new Vector3(-transform.lossyScale.x * starLabelOffset, transform.lossyScale.y, 0);
			var p = Camera.main.WorldToScreenPoint(transform.position);
			p += offset;

			starLabelStyle.fontSize = (int) (Screen.width / 60f);
			starTypeStyle.fontSize = (int) (Screen.width / 50f);

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
		if (col.gameObject.tag != "Celestial") {
			Destroy(col.gameObject);
		}
	}

	protected void OnCollisionEnter (Collision col) {
		if (col.gameObject.tag != "Celestial") {
			Destroy(col.gameObject);
		}
	}
	
	public virtual void nextState() {
		rigidbody.isKinematic = true;
		collider.isTrigger = true;
		renderer.enabled = false;
		(gameObject.GetComponent("Halo") as Behaviour).enabled = false;
		lblShowing = false;
		starTypeStyle.normal.textColor = prevColor;
		
		nextCelestial = (GameObject)Instantiate(
					Resources.Load(nextStarState.Replace(" ", "")), transform.position, transform.rotation);
		float finalScale = nextCelestial.transform.localScale.x;
		nextCelestial.transform.parent = transform.parent;

		Celestial temp = nextCelestial.GetComponent<Celestial>();
		temp.lblShowing = false;
		temp.prob = prob;
		nextCelestial.transform.localScale = transform.localScale;

		transform.parent.GetComponent<SolarSystem>().celestial = nextCelestial.GetComponent<Celestial>();

		StartCoroutine(growStar(finalScale));
	}
	
	protected virtual IEnumerator growStar(float finalScale) {
		hud.actionEnabled = false;

		float timePassed = 0;
		float percentPassed = 0;
		float scaleDifference = finalScale - transform.localScale.x;
		(nextCelestial.GetComponent("Halo") as Behaviour).enabled = false;
		while (timePassed < transitionTime) {
			timePassed += Time.deltaTime;
			percentPassed = timePassed / transitionTime;

			nextCelestial.transform.localScale = (transform.localScale.x + percentPassed * scaleDifference) * Vector3.one;

			yield return null;
		}

		(nextCelestial.GetComponent("Halo") as Behaviour).enabled = true;
		nextCelestial.GetComponent<Celestial>().lblShowing = true;
		Destroy(gameObject);  
		hud.actionEnabled = true;
	}

	void OnBecameVisible() {
		hasBeenSeen = true;
	}

	#region SelectableObject members

	public override string getName() {
		return stateType;
	}

	public override string getDescription()	{
		string description = prob.ToString () + " Solar Masses";
		if (!permState) {
			description += "\n" + turnsLeft + " Turns to " + nextStarState;
		}

		return description;
	}

	public override MenuOption[] getOptions() {
		return new MenuOption[0];
	}

	#endregion
}

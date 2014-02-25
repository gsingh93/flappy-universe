using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {

	private const int buttonWidth = 150;
	private const int maxZoom = -10;
	private const int minZoom = -200;
	public Rect HUDRect = new Rect (10, 10, 200, 150);
	public const int Dim = 200;

	private float years = 1.0f;

	private float turnTime = 0.5f;

	private GUILayer guilayer;
	
	private SelectableObject _selectedObject;
	public SelectableObject selectedObject
	{
		get { return _selectedObject; }
		set {
			_selectedObject = value;

			if (value == null)
				player.showLabels();
			else
				player.hideLabels();
		}

	}

	public GUIStyle style = new GUIStyle();
	public GUIStyle energyLabelStyle = new GUIStyle ();
	public float energyLabelStyleFontSize = 60f;

	public Ship shipToPickDestinationFor;

	public Player player;
	public float u = 0.5f;

	public float speed = 0.25f;

	public Vector3 startPosition;
	private Vector3 targetPosition;
	
	protected Vector3 point;
	protected GameObject gobject;

	public void PickPlanet(Ship ship) {
		shipToPickDestinationFor = ship;
		selectedObject = null;
	}
	
	private void Start() {
		startPosition = transform.position;
		player = GetComponent<Player>();
		style.fontSize = 31;
		point = new Vector3();
		guilayer = GetComponent<GUILayer> ();
	}

	public void Update() {
		if (selectedObject == null) {
			if (startPosition.z < maxZoom && Input.GetKey(KeyCode.Z)) {
				Camera.main.transform.position += Vector3.forward;
				startPosition = transform.position;
			} else if (startPosition.z > minZoom && Input.GetKey(KeyCode.X)) {
				Camera.main.transform.position += Vector3.back;
				startPosition = transform.position;
			} else if (startPosition.x < Dim && Input.GetAxis("Horizontal") > 0) {
				Camera.main.transform.position += speed * Vector3.right;
				startPosition = transform.position;
			} else if (startPosition.x > -1 * Dim && Input.GetAxis("Horizontal") < 0) {
				Camera.main.transform.position += speed * Vector3.left;
				startPosition = transform.position;
			} else if (startPosition.y < Dim && Input.GetAxis("Vertical") > 0) {
				Camera.main.transform.position += speed * Vector3.up;
				startPosition = transform.position;
			} else if (startPosition.y > -1 * Dim && Input.GetAxis("Vertical") < 0) {
				Camera.main.transform.position += speed * Vector3.down;
				startPosition = transform.position;
			}
		}

	}

	private void LateUpdate() {
		if (selectedObject != null) {
			targetPosition = selectedObject.transform.position +
				new Vector3(0, 0, -5 - selectedObject.transform.localScale.z);
		} else {
			targetPosition = startPosition;
		}
		transform.position = (1 - u) * transform.position + u * targetPosition;
	}

	private void OnGUI () {
		GUI.skin.button.wordWrap = true;
		if (selectedObject != null) {
			Vector3 pos = Camera.main.WorldToScreenPoint(selectedObject.gameObject.transform.position + new Vector3(selectedObject.gameObject.transform.localScale.x/1.2f, -1.5f*selectedObject.gameObject.transform.localScale.y, 0));
			HUDRect.x = pos.x;
			HUDRect.y = pos.y;
			HUDRect = GUI.Window(1, HUDRect, PlanetWindow, selectedObject.getName() + "\n" + selectedObject.getDescription());

			Event e = Event.current;
			
			if (e.type == EventType.MouseDown && !HUDRect.Contains(e.mousePosition))
			{
				selectedObject = null;
			}
		}

		if (GUI.Button(new Rect(Screen.width - 110, Screen.height - 30, 100, 20), "Advance Turn")) {
			player.turnFinish();
			years += turnTime;
		}

		energyLabelStyle.fontSize = 20;
		string text = "Energy: " + player.resources;
		int textHeight = (int) energyLabelStyle.CalcHeight(new GUIContent(text), 500);
		GUI.Label(new Rect(10, Screen.height - textHeight - 10, 100, 30), text, energyLabelStyle);

		text = "Planets: " + player.planets.Count;
		textHeight = (int) energyLabelStyle.CalcHeight(new GUIContent(text), 500);
		GUI.Label(new Rect(10, Screen.height - textHeight*2 - 10, 100, 30), text, energyLabelStyle);

		text = "Time elapsed: " + years + " billion years";
		textHeight = (int) energyLabelStyle.CalcHeight(new GUIContent(text), 500);
		GUI.Label(new Rect(Screen.width - 260, 10, textHeight, 30), text, energyLabelStyle);
	}

	private void PlanetWindow (int windowID) {
//		GUI.Box(new Rect(10, 10, HUDWidth, HUDHeight),
//		        selectedObject.getName() + "\n" + selectedObject.getDescription());
		
		MenuOption[] options = selectedObject.getOptions();
		for (int i = 0; i < options.Length; i++) {
			string buttonText = options[i].name;
			if (options[i].cost > 0) {
				buttonText += " (costs " + options[i].cost + " energy)";
			}
			if (player.resources < options[i].cost) {
				GUI.enabled = false;
			}
			float height = style.CalcHeight(new GUIContent(buttonText), buttonWidth);
			if (GUI.Button(new Rect (20, 70 + 40 * (i + 1), buttonWidth, height), buttonText)) {
				selectedObject.OnOptionSelected(options[i]);
			}
			GUI.enabled = true;
		}
		
//		if (GUI.Button(new Rect(180, 0, 20, 20), "x")) {
//
//		}

		GUI.DragWindow(new Rect(0, 0, 10000, 20));
	}
}

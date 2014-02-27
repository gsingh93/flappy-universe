using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {

	private const int buttonWidth = 185;
	private const int maxZoom = -10;
	private const int minZoom = -200;
	public Rect HUDRect;
	public const int Dim = 200;
	public bool actionEnabled = true;

	public float u = 0.5f;
	public float speed = 0.25f;

	private float years = 1.0f;
	private float turnTime = 0.5f;

	private SelectableObject _selectedObject;
	public SelectableObject selectedObject
	{
		get { return _selectedObject; }
		set {
			_selectedObject = value;

			if (value == null) {
				player.showLabels();
			} else {
				player.hideLabels();
			}
		}
	}

	public GUIStyle style = new GUIStyle();
	public GUIStyle energyLabelStyle = new GUIStyle();

	public Ship shipToPickDestinationFor;
	
	public Vector3 cameraPosition;
	private Vector3 targetPosition;

	private Player player;
	
	public void PickPlanet(Ship ship) {
		shipToPickDestinationFor = ship;
		selectedObject = null;
	}
	
	private void Start() {
		cameraPosition = transform.position;
		player = GetComponent<Player>();
	}

	public void Update() {
		// Handle camera movement if nothing is selected
		if (selectedObject == null) {
			Vector3 pos = Camera.main.transform.position;

			// Zooming
			if (cameraPosition.z < maxZoom && Input.GetKey(KeyCode.Z)) {
				pos += Vector3.forward;
				cameraPosition = pos;
			} else if (cameraPosition.z > minZoom && Input.GetKey(KeyCode.X)) {
				pos += Vector3.back;
				cameraPosition = pos;
			}

			if (cameraPosition.x < Dim && Input.GetAxis("Horizontal") > 0) {
				Camera.main.transform.position += speed * Vector3.right;
				cameraPosition = transform.position;
			}
			if (cameraPosition.x > -1 * Dim && Input.GetAxis("Horizontal") < 0) {
				Camera.main.transform.position += speed * Vector3.left;
				cameraPosition = transform.position;
			}
			if (cameraPosition.y < Dim && Input.GetAxis("Vertical") > 0) {
				Camera.main.transform.position += speed * Vector3.up;
				cameraPosition = transform.position;
			}
			if (cameraPosition.y > -1 * Dim && Input.GetAxis("Vertical") < 0) {
				Camera.main.transform.position += speed * Vector3.down;
				cameraPosition = transform.position;
			}

			Camera.main.transform.position = pos;
		}
	}

	private void LateUpdate() {
		// Zoom in on the selected object if not null
		if (selectedObject != null) {
			// We use the scale of the object to figure out how far away the camera should be. This is kind of hacky
			Transform t = selectedObject.transform;
			targetPosition = t.position + Vector3.back * (5 + t.localScale.z);
		} else {
			targetPosition = cameraPosition;
		}
		transform.position = (1 - u) * transform.position + u * targetPosition;
	}

	private void OnGUI () {
		// Draw the HUD window when an object is selected
		if (selectedObject != null) {
			Transform t = selectedObject.gameObject.transform;

			Vector3 pos = Camera.main.WorldToScreenPoint(t.position +
			                                             new Vector3(t.localScale.x / 1.2f, -1.5f * t.localScale.y, 0));
			HUDRect.x = pos.x;
			HUDRect.y = pos.y;
			HUDRect = GUI.Window(1, HUDRect, PlanetWindow,
			                     selectedObject.getName() + "\n\n" + selectedObject.getDescription() + "\n");

			// Dismiss window when click outside HUD
			Event e = Event.current;
			if (e.type == EventType.MouseDown && !HUDRect.Contains(e.mousePosition)) {
				selectedObject = null;
			}
		}
		
		GUI.enabled = actionEnabled;
		if (GUI.Button(new Rect(Screen.width - 110, Screen.height - 30, 100, 20), "Advance Turn")) {
			player.turnFinish();
			years += turnTime;
		}
		GUI.enabled = true;

		// Draw information labels
		string text = "Energy: " + player.resources + " (+" + player.energyPerTurn() + "/Turn)";
		int textHeight = (int) energyLabelStyle.CalcHeight(new GUIContent(text), 500);
		GUI.Label(new Rect(10, Screen.height - textHeight - 10, 100, 30), text, energyLabelStyle);

		text = "Planets: " + player.planets.Count;
		textHeight = (int) energyLabelStyle.CalcHeight(new GUIContent(text), 500);
		GUI.Label(new Rect(10, Screen.height - textHeight * 2 - 10, 100, 30), text, energyLabelStyle);

		text = "Time elapsed: " + years + " billion years";
		textHeight = (int) energyLabelStyle.CalcHeight(new GUIContent(text), 500);
		GUI.Label(new Rect(Screen.width - 270, 10, textHeight, 30), text, energyLabelStyle);
	}

	private void PlanetWindow(int windowID) {
		// Display all options in window
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
			if (GUI.Button(new Rect (20, 80 + 40 * (i + 1), buttonWidth, height), buttonText)) {
				selectedObject.OnOptionSelected(options[i]);
			}
			GUI.enabled = true;

			HUDRect.height = 135 + 40 * (i + 1);
		}

		if (options.Length == 0) {
			HUDRect.height = 105;
		}
	}
}

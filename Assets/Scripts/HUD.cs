using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {

	private const int buttonWidth = 150;
	private const int maxZoom = -15;
	private const int minZoom = -100;
	private const int HUDHeight = 150;
	private const int HUDWidth = 200;
	public const int Dim = 200;
	
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

	public Ship shipToPickDestinationFor;

	public Player player;
	public float u = 0.5f;

	public float speed = 0.25f;

	private Vector3 startPosition;
	private Vector3 targetPosition;

	public void PickPlanet(Ship ship) {
		shipToPickDestinationFor = ship;
		selectedObject = null;
	}
	
	private void Start() {
		startPosition = transform.position;
		player = GetComponent<Player>();
		style.fontSize = 31;
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
			targetPosition = selectedObject.transform.position + new Vector3(0, 0, -5f);
		} else {
			targetPosition = startPosition;
		}
		transform.position = (1 - u) * transform.position + u * targetPosition;
	}

	private void OnGUI () {
		GUI.skin.button.wordWrap = true;
		if (selectedObject != null) {
			GUI.Box(new Rect(0, 0, HUDWidth, HUDHeight),
			        selectedObject.getName() + "\n" + selectedObject.getDescription());

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

			if (GUI.Button(new Rect(180, 0, 20, 20), "x")) {
				selectedObject = null;
			}
		}

		if (GUI.Button(new Rect(Screen.width - 110, Screen.height - 30, 100, 20), "Advance Turn")) {
			player.turnFinish();
		}

		GUI.Label(new Rect(10, Screen.height - 30, 100, 30), ("Energy: " + player.resources));
	}
}

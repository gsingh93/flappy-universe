using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {

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
	public Player player;
	public float u = 0.5f;

	public float speed = 0.25f;

	private Vector3 startPosition;
	private Vector3 targetPosition;

	private void Start() {
		startPosition = transform.position;
		player = GetComponent<Player> ();
	}

	public void Update() {
		if (selectedObject == null) {
			if (Input.GetKey(KeyCode.Z)) {
				if (startPosition.z < -15) {
					Camera.main.transform.position += Vector3.forward;
				}
				startPosition = transform.position;
			} else if (Input.GetKey(KeyCode.X)) {
				if (startPosition.z > -100) {
					Camera.main.transform.position += Vector3.back;
				}
				startPosition = transform.position;
			} else if (Input.GetAxis("Horizontal") > 0) {
				Camera.main.transform.position += speed * Vector3.right;
				startPosition = transform.position;
			} else if (Input.GetAxis("Horizontal") < 0) {
				Camera.main.transform.position += speed * Vector3.left;
				startPosition = transform.position;
			} else if (Input.GetAxis("Vertical") > 0) {
				Camera.main.transform.position += speed * Vector3.up;
				startPosition = transform.position;
			} else if (Input.GetAxis("Vertical") < 0) {
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
		if (selectedObject != null) {
			GUI.Box (new Rect (0, 0, 200, 150), selectedObject.getName() + "\n" + selectedObject.getDescription());

			MenuOption[] options = selectedObject.getOptions();
			for (int i = 0; i < options.Length; i++) {
				string buttonText = options[i].name + " (" + options[i].cost + " energy)";
				if (player.resources < options[i].cost) {
					GUI.enabled = false;
				}
				if (GUI.Button (new Rect (20, 50 + 40*(i+1), 150, 20), buttonText)) {
					selectedObject.OnOptionSelected(options[i]);
				}
				GUI.enabled = true;
			}

			if (GUI.Button(new Rect(180, 0, 20, 20), "x")) {
				selectedObject = null;
			}
		}

		if (GUI.Button(new Rect(Screen.width-110, Screen.height-30, 100, 20), "End Turn")) {
			player.turnFinish();
		}

		GUI.Label (new Rect (10, Screen.height - 30, 100, 30), ("Energy: " + player.resources) );
	}
}

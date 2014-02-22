using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {
	public SelectableObject selectedObject;
	public float u = 0.5f;

	private Vector3 startPosition;
	private Vector3 targetPosition;

	private void Start() {
		startPosition = transform.position;
	}

	private void FixedUpdate() {
		if (selectedObject != null) {
			targetPosition = selectedObject.transform.position + new Vector3(0, 0, -5f);
		} else {
			targetPosition = startPosition;
		}
		transform.position = (1 - u) * transform.position + u * targetPosition;
	}

	private void OnGUI () {
		if (selectedObject != null) {
			GUI.Box (new Rect (0, 0, 200, 150), selectedObject.getName());

			string[] options = selectedObject.getOptions();
			for (int i = 0; i < options.Length; i++) {
				if (GUI.Button (new Rect (20, 40*(i+1), 150, 20), options[i])) {
					selectedObject.OnOptionSelected(options[i]);
				}
			}

			if (GUI.Button(new Rect(180, 0, 20, 20), "x")) {
				selectedObject = null;
			}
		}
	}
}

using UnityEngine;
using System.Collections;

public abstract class SelectableObject : MonoBehaviour {
	public HUD hud;

	protected void Start() {
		hud = Camera.main.GetComponent<HUD> ();
	}

	private void OnMouseDown() {
		hud.selectedObject = this;
	}

	public abstract string getName();
	public abstract string[] getOptions();
	public abstract void OnOptionSelected(string option);
}

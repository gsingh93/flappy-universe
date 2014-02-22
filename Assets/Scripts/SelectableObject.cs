using UnityEngine;
using System.Collections;

public abstract class SelectableObject : MonoBehaviour {
	public HUD hud;

	protected Player player;

	protected void Start() {
		hud = Camera.main.GetComponent<HUD> ();
		player = Camera.main.GetComponent<Player> ();
	}

	private void OnMouseDown() {
		hud.selectedObject = this;
	}

	public abstract string getName();
	public abstract string getDescription();
	public abstract MenuOption[] getOptions();
	public abstract void OnOptionSelected(MenuOption option);
}

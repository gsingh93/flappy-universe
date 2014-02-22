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
	public virtual MenuOption[] getOptions() { return new MenuOption[0]; }
	public virtual void OnOptionSelected(MenuOption option) {}
}

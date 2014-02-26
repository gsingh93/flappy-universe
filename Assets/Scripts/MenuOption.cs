using System;
public class MenuOption
{
	public string name;
	public int cost;
	public bool enabled;

	public MenuOption(string name, int cost) {
		Init(name, cost, true);
	}
	
	public MenuOption(string name, int cost, bool enabled) {
		Init(name, cost, enabled);
	}

	private void Init(string name, int cost, bool enabled) {
		this.name = name;
		this.cost = cost;
		this.enabled = enabled;
	}
}


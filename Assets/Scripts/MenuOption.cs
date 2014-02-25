using System;
public class MenuOption
{
	public string name;
	public int cost;
	public bool enabled;

	public MenuOption(string name, int cost, bool enabled = true) {
		this.name = name;
		this.cost = cost;
		this.enabled = enabled;
	}
}


using UnityEngine;
using System.Collections;

public class Planet : SelectableObject {
	public string planetName;
	public bool buttonClicked = false;

	public bool claimed;

	public float speed;
	public float radius;
	private float angularVelocity;

	public const float maxSpeed = 0.2f;
	public const float minSpeed = 2f;

	public Mine minePrefab;

	public float mineCost;

	public Texture[] textures;

	public Vector2 origin;

	private GameObject parent;

	private int numBuildings = 0;

	private static string OPTION_BUILD_MINE = "Build Mine";
	private static MenuOption[] options = {
		new MenuOption (OPTION_BUILD_MINE, 25)
	};

	new private void Start() {
		base.Start();
		parent = transform.parent.gameObject;
		if (gameObject.name == "Earth")
			renderer.material.mainTexture = textures[4];
		else {
			int rndRngVal = Random.Range(0, textures.Length);

			while (rndRngVal == 4) {
				rndRngVal = Random.Range(0, textures.Length);
			}

			renderer.material.mainTexture = textures[rndRngVal];
		}

		angularVelocity = speed / radius;
	}

	public int harvestEnergy() {
		return 10 * numBuildings;
	}

	private void Update() {
		float angle = Time.time * angularVelocity;
		transform.position = parent.transform.position + radius * new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0);
	}

	#region implemented abstract members of SelectableObject
	public override string getName ()
	{
		return planetName;
	}

	public override string getDescription ()
	{
		if (claimed) {
			return (4-numBuildings) + " empty building slots";
		} else {
			return "You haven't claimed this planet.";
		}
	}

	public override MenuOption[] getOptions ()
	{
		if (claimed) {
			return options;
		} else {
			return new MenuOption[0];
		}
	}

	public override void OnOptionSelected (MenuOption option)
	{
		if (numBuildings >= 4 || option.cost > player.resources) {
			return;
		}
		if (option.name == OPTION_BUILD_MINE) {
			player.resources -= option.cost;

			float rad = (transform.eulerAngles.z + 90 * numBuildings) * Mathf.Deg2Rad;
			Vector3 pos = new Vector3(Mathf.Cos(rad) * 0.5f, Mathf.Sin(rad) * 0.5f, 0);
			Mine mine = Instantiate(minePrefab) as Mine;
			mine.transform.position = transform.position + pos;
			mine.transform.eulerAngles = transform.eulerAngles;
			mine.transform.parent = transform;

			numBuildings++;
		}
	}
	#endregion
}

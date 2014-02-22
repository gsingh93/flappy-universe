using UnityEngine;
using System.Collections;

public class Planet : SelectableObject {
	public string planetName;
	public bool buttonClicked = false;

	public float speed;
	public float radius;
	private float angularVelocity;

	public const float maxSpeed = 0.2f;
	public const float minSpeed = 2f;

	public Mine minePrefab;

	public Texture[] textures;

	public Vector2 origin;

	private GameObject parent;

	private int numBuildings = 0;

	private static string OPTION_BUILD_MINE = "Build Mine";

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

	public override string[] getOptions ()
	{
		return new string[] {OPTION_BUILD_MINE};
	}

	public override void OnOptionSelected (string option)
	{
		if (option == OPTION_BUILD_MINE && numBuildings < 4) {
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
